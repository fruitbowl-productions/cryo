using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo
{
    public class Platform : ColorChangingGameElement
    {
        public Platform(PlatformColor startingColor, Texture2D redTexture, Texture2D greenTexture, Texture2D blueTexture,
            Vector2 position, float scale)
            : base(startingColor, redTexture, greenTexture, blueTexture, position, scale)
        { }
    }
}
