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

        public readonly Vector2 Gravity;

        public Vector2 Acceleration;

        private readonly IPhysics owner;

        public Vector2 Velocity;

        public PhysicsComponent(IPhysics ownerInput, PhysicsType physics)
        {
            Gravity = new Vector2(0f, 0.0001f);

            owner = ownerInput;
            Velocity = Vector2.Zero;
            Physics = physics;

            switch (physics)
            {
                case PhysicsType.Dynamic:
                    Acceleration = Gravity;
                    break;
                case PhysicsType.Static:
                    Acceleration = Vector2.Zero;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public PhysicsType Physics { get; set; }

        public override void Update(GameTime gameTime)
        {
            owner.GetTexture().Position += Velocity*new Vector2((float) gameTime.ElapsedGameTime.TotalMilliseconds);
            Velocity += Acceleration*new Vector2((float) gameTime.ElapsedGameTime.TotalMilliseconds);

            switch (Physics)
            {
                case PhysicsType.Dynamic:
                    CheckCollisions();
                    break;
                case PhysicsType.Static:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void CheckCollisions()
        {
            foreach (var component in AllComponents<PhysicsComponent>())
            {
                if (this == component) continue;
                if (!owner.CollidesWith(component.owner)) continue;
                switch (component.Physics)
                {
                    case PhysicsType.Static:
                        var topInsideOther = owner.GetTexture().Top <= component.owner.GetTexture().Bottom;
                        var bottomOutsideOther = owner.GetTexture().Bottom >= component.owner.GetTexture().Bottom;
                        if (topInsideOther && bottomOutsideOther)
                        {
                            owner.GetTexture().Top = component.owner.GetTexture().Bottom;
                        }

                        var topOutsideOther = owner.GetTexture().Top <= component.owner.GetTexture().Top;
                        var bottomInsideOther = owner.GetTexture().Bottom >= component.owner.GetTexture().Top;
                        if (topOutsideOther && bottomInsideOther)
                        {
                            owner.GetTexture().Bottom = component.owner.GetTexture().Top;
                        }

                        break;
                    case PhysicsType.Dynamic:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}