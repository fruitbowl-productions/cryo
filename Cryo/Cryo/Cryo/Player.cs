using Cryo.Engine;
using Cryo.Engine.Components.ColorChange;
using Cryo.Engine.Components.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo
{
    public class Player : GameElement, IColorChange
    {
        public Player(ColorChangeComponent.PlatformColor startingColor, Texture2D redTexture, Texture2D greenTexture, Texture2D blueTexture, Vector2 position, float scale)
        {
            Texture = new GameTexture(null, position, scale);

            Components.Add(new PhysicsComponent(this, PhysicsComponent.PhysicsType.Dynamic));
            Components.Add(new ColorChangeComponent(this, redTexture, greenTexture, blueTexture, startingColor));
        }

        public void SetTexture2D(Texture2D value)
        {
            Texture.Texture = value;
        }
    }
}
