using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.Engine.Components.ColorChange
{
    public class ColorChangeComponent : Component
    {
        public enum PlatformColor
        {
            Red,
            Green,
            Blue
        }

        private readonly IColorChange owner;

        private readonly Dictionary<PlatformColor, Texture2D> textures;

        public ColorChangeComponent(IColorChange ownerInput, Texture2D redTexture, Texture2D greenTexture,
            Texture2D blueTexture, PlatformColor startingColor)
        {
            owner = ownerInput;
            textures = new Dictionary<PlatformColor, Texture2D>
            {
                {PlatformColor.Red, redTexture},
                {PlatformColor.Green, greenTexture},
                {PlatformColor.Blue, blueTexture}
            };
            ownerInput.SetTexture2D(CurrentTexture2D);
        }

        private PlatformColor Color { get; set; }

        private Texture2D CurrentTexture2D => textures[Color];

        public override void Update(GameTime gameTime)
        {
        }
    }
}