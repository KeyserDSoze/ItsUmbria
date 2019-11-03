namespace ItsUmbria.Library.OnlineGame.Abstractions
{
    internal interface IHealable : IDamageable
    {
        void GetHealing(int heal);
    }
}