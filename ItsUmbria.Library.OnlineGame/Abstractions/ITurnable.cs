using ItsUmbria.Library.OnlineGame.Enum;

namespace ItsUmbria.Library.OnlineGame.Abstractions
{
    internal interface ITurnable
    {
        int PendingActions { get; }
        void RestoreActions();
        bool DoAction(ActionType action, RigidBody target, int intensity, Vector vector);
    }
}