using System.Collections.Generic;
using Cryo.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo
{
    public abstract class ColorChangingGameElement : GameElement
    {
        public enum PlatformColor
        {
            Blue,
            Red,
            Green
        }

        private PlatformColor Color { get; set; }

        private readonly Dictionary<PlatformColor, Texture2D> textures;

        private Texture2D CurrentTexture2D => textures[Color];

        public ColorChangingGameElement(PlatformColor startingColor, Texture2D redTexture, Texture2D greenTexture, Texture2D blueTexture, Vector2 position, float scale)
        {
            textures = new Dictionary<PlatformColor, Texture2D>
            {
                {PlatformColor.Red, redTexture},
                {PlatformColor.Green, greenTexture},
                {PlatformColor.Blue, blueTexture}
            };

            Color = startingColor;

            Texture = new GameTexture(CurrentTexture2D, position, scale);
        }
    }
}
