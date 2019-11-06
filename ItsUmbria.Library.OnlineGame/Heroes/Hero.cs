using ItsUmbria.Library.OnlineGame.Abstractions;
using ItsUmbria.Library.OnlineGame.Enum;
using ItsUmbria.Library.OnlineGame.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ItsUmbria.Library.OnlineGame.Heroes
{
    public abstract class Hero : RigidBody, IAttacking, IMovable, IPrintable, ISpecial, IDamageable, IHealable, ITurnable
    {
        private WeaponType equippedWeaponType = WeaponType.Gun;
        private Weapon equippedWeapon = null;
        public Weapon EquippedWeapon
        {
            get
            {
                if (equippedWeapon == null)
                {
                    equippedWeapon = Inventory.TryGetValue(equippedWeaponType, out Weapon weapon)
                        ? weapon
                        : this.Inventory.LastOrDefault().Value;
                }
                return equippedWeapon;
            }
        }
        public Hero(string name, HeroClass heroClass) : base(name)
        {
            Health = MaxHealth;
            Class = heroClass;
            RestoreActions();
        }
        public HeroClass Class { get; }
        public int Health { get; private set; }
        public abstract int MaxHealth { get; }
        public abstract double Speed { get; }
        public int PendingActions { get; private set; }
        public virtual int ActionsPerTurn => 2;

        // Flyweight
        public Dictionary<WeaponType, Weapon> Inventory { get; } = new Dictionary<WeaponType, Weapon>()
        {
            { WeaponType.Gun, new Socom() },
            { WeaponType.Melee, new Knife() }
        };
        public int CurrentCooldown { get; private set; } = 0;
        public abstract int Cooldown { get; }
        public Weapon PickWeapon(Weapon weaponToEquip)
        {
            if (!Inventory.TryGetValue(weaponToEquip.WeaponType, out Weapon weapon))
            {
                Inventory.Add(weaponToEquip.WeaponType, weaponToEquip);
            }
            else
            {
                if (weapon is IRanged rangedWeapon) rangedWeapon.Reload(10);
            }
            return weapon;
        }
        public bool DropWeapon(WeaponType weaponType)
        {
            if (Inventory.ContainsKey(weaponType)) return Inventory.Remove(weaponType);
            else return false;
        }
        public bool ChooseWeapon(WeaponType weaponType)
        {
            if (Inventory.ContainsKey(weaponType))
            {
                equippedWeaponType = weaponType;
                equippedWeapon = null;
                return true;
            }
            else
            {
                return false;
            }

        }
        // ritorna true se è morto
        public bool GetDamage(int damage)
        {
            Health -= damage;
            return Health <= 0;
        }
        public void GetHealing(int heal)
        {
            Health = Health + heal >= MaxHealth ? MaxHealth : Health + heal;
        }
        public bool Attack(RigidBody target)
        {
            return this.EquippedWeapon.Attack(target);
        }
        public override void Print()
        {
            Console.WriteLine($"Name:{this.Name} - Healt:{this.Health}");
            Console.WriteLine($"Equip:{this.EquippedWeapon.Name} - Ammo:{(this.EquippedWeapon is RangedWeapon rangedWeapon ? rangedWeapon.Ammo.ToString() : "-")}\n");
        }
        public override bool Move(Vector vector)
        {
            if (this.Position.Distance(vector).Magnitude > Speed)
            {
                return false;
            }
            if (base.Move(vector))
            {
                foreach (RigidBody item in Inventory.Values)
                {
                    item.Position = this.Position;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        protected abstract bool DoSpecialAbility(RigidBody target, int intensity);
        public bool TrySpecialAbility(RigidBody target, int intensity)
        {
            if (CurrentCooldown == 0)
            {
                CurrentCooldown = Cooldown;
                return DoSpecialAbility(target, intensity);
            }
            return false;
        }
        public void DecreaseCoolDownIfNeeded()
        {
            if (Cooldown > 0) CurrentCooldown--;
        }
        public void RestoreActions()
        {
            PendingActions = ActionsPerTurn;
        }
        public bool DoAction(ActionType action, RigidBody target, int intensity, Vector vector)
        {
            bool result = false;
            if (PendingActions > 0)
            {
                switch (action)
                {
                    case ActionType.Move:
                        result = this.Move(vector);
                        break;
                    case ActionType.Special:
                        result = this.TrySpecialAbility(target, intensity);
                        break;
                    case ActionType.Attack:
                        result = this.Attack(target);
                        break;
                    default:
                        result = false;
                        break;
                }
                if (result) PendingActions--;
            }
            return result;
        }
        public bool ChangeName(string name)
        {
            Name = name;
            return true;
        }
    }
}
