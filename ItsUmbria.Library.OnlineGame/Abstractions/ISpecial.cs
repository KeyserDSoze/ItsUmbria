using ItsUmbria.Library.OnlineGame.Abstractions;

namespace ItsUmbria.Library.OnlineGame.Abstractions
{
    internal interface ISpecial
    {
        void DecreaseCoolDownIfNeeded();
        bool TrySpecialAbility(RigidBody target, int intensity);
    }
}