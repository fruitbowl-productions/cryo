using System;
using Microsoft.Xna.Framework;

namespace Cryo.Engine.Components.Physics
{
    public class PhysicsComponent : Component
    {
        public enum PhysicsType
        {
            Static,
            Dynamic
        }

        public const float Gravity = 10f;
        public Vector2 Acceleration;

        private readonly IPhysics owner;

        public Vector2 Velocity;

        public PhysicsComponent(IPhysics ownerInput, PhysicsType physics)
        {
            owner = ownerInput;
            Velocity = Vector2.Zero;
            Acceleration = Vector2.Zero;
            Physics = physics;
        }

        public PhysicsType Physics { get; set; }

        public override void Update(GameTime gameTime)
        {
            owner.SetPosition(owner.GetPosition() +
                              Velocity*new Vector2((float) gameTime.ElapsedGameTime.TotalMilliseconds));
            Velocity += Acceleration*new Vector2((float) gameTime.ElapsedGameTime.TotalMilliseconds);

            switch (Physics)
            {
                case PhysicsType.Dynamic:
                    UpdateGravity();
                    break;
                case PhysicsType.Static:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateGravity()
        {
            throw new NotImplementedException();
        }
    }
}