namespace ItsUmbria.Library.OnlineGame.Abstractions
{
    internal interface IDamageable
    {
        bool GetDamage(int damage);
        int Health { get; }
    }
}