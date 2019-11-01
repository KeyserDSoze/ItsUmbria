using ItsUmbria.Library.OnlineGame.Abstractions;
using ItsUmbria.Library.OnlineGame.Enum;
using ItsUmbria.Library.OnlineGame.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ItsUmbria.Library.OnlineGame.Heroes
{
    #region Heroes
    public abstract class Hero : GameObject, IAttacking, IMovable, IPrintable
    {
        private static readonly WeaponFactory weaponFactory = new WeaponFactory();
        public Weapon EquippedWeapon => this.Inventory.LastOrDefault().Value;
        public Hero(string name, HeroClass heroClass)
        {
            Health = MaxHealth;
            Name = name;
            Class = heroClass;
        }
        public HeroClass Class { get; }
        public int Health { get; private set; }
        public abstract int MaxHealth { get; }
        public abstract double Speed { get; }
        // Flyweight
        public Dictionary<WeaponType, Weapon> Inventory { get; } = new Dictionary<WeaponType, Weapon>() { { WeaponType.Melee, new Knife() }};
        public int CurrentCooldown { get; private set; } = 0;
        public abstract int Cooldown { get; }
        public void PickWeapon(Weapon weaponToEquip)
        {
            if (!Inventory.TryGetValue(weaponToEquip.WeaponType, out Weapon weapon))
            {
                Inventory.Add(weaponToEquip.WeaponType, weaponToEquip);
            }
            else
            { 
                if(weapon is IRanged rangedWeapon) rangedWeapon.Reload(10);
            }
        }
        public void DropWeapon(WeaponType weaponType)
        {
            if (Inventory.ContainsKey(weaponType)) Inventory.Remove(weaponType);
        }
        // ritorna true se è morto
        internal bool GetDamage(int damage)
        {
            Health -= damage;
            return Health <= 0;
        }
        internal void GetHealing(int heal)
        {
            Health = Health + heal >= MaxHealth ? MaxHealth : Health + heal;
        }
        public bool Attack(GameObject target)
        {
            return this.EquippedWeapon.Attack(target);
        }
        public override void Print()
        {
            Console.WriteLine($"Name:{this.Name} - Healt:{this.Health}");
            Console.WriteLine($"Equip:{this.EquippedWeapon.Name} - Ammo:{(this.EquippedWeapon is RangedWeapon rangedWeapon ? rangedWeapon.Ammo.ToString() : "-")}\n");
        }
        public override void Move(Vector vector)
        {
            if (this.Position.Distance(vector).Magnitude > Speed)
            {
                vector -= vector - this.Position;
            }
            base.Move(vector);
            foreach (GameObject item in Inventory.Values)
            {
                item.Position = this.Position;
            }
        }
        public void DecreaseCoolDown()
        {
            if(Cooldown > 0) CurrentCooldown--;
        }
        public bool TrySpecialAbility(GameObject target, int intensity)
        {
            if (CurrentCooldown == 0)
            {
                CurrentCooldown = Cooldown;
                return DoSpecialAbility(target, intensity);
            }
            return false;
        }
        protected abstract bool DoSpecialAbility(GameObject target, int intensity);
    }
    #endregion
}
