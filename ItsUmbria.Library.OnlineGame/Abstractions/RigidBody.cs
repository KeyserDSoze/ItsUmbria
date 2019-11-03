namespace ItsUmbria.Library.OnlineGame.Abstractions
{
    public abstract class RigidBody : GameObject, IPrintable, IMovable
    {
        protected RigidBody(string name) : base(name) { }
        public Vector Position { get; set; } = new Vector(0, 0);
        public virtual bool Move(Vector distance)
        {
            Position += distance;
            return true;
        }
    }
    
}
