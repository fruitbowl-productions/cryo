using Microsoft.Xna.Framework;

namespace Cryo.Engine.Components.Physics
{
    public class PhysicsComponent : Component
    {
        public const float Gravity = 10f;

        public Vector2 Velocity;
        public Vector2 Acceleration;

        private IPhysics owner;

        public PhysicsComponent(IPhysics ownerInput)
        {
            owner = ownerInput;
            Velocity = Vector2.Zero;
            Acceleration = Vector2.Zero;
        }

        public override void Update(GameTime gameTime)
        {
            owner.SetPosition(owner.GetPosition() + Velocity*new Vector2((float) gameTime.ElapsedGameTime.TotalMilliseconds));
            Velocity += Acceleration*new Vector2((float) gameTime.ElapsedGameTime.TotalMilliseconds);
        }
    }
}
