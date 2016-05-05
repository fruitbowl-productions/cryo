using Cryo.Engine.Components.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo
{
    public class Player : ColorChangingGameElement, IPhysics
    {
        public Player(PlatformColor startingColor, Texture2D redTexture, Texture2D greenTexture, Texture2D blueTexture, Vector2 position, float scale)
            : base(startingColor, redTexture, greenTexture, blueTexture, position, scale)
        {
            Components.Add(new PhysicsComponent(this));
        }

        public Vector2 GetPosition()
        {
            return Texture.Position;
        }

        public void SetPosition(Vector2 value)
        {
            Texture.Position = value;
        }
    }
}
