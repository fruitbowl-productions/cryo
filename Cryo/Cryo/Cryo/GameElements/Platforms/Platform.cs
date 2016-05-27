using System.Collections.Generic;
using Cryo.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.GameElements.Platforms
{
    public class Platform : GameElement
    {
        private readonly Dictionary<TextureColor, Texture2D> textures;

        public enum Orientation
        {
            Horizontal,
            Vertical
        }

        private readonly Orientation orientation;
        
        public Platform(TextureColor color, Vector2 position, float scale, Orientation orientation)
        {
            textures = new Dictionary<TextureColor, Texture2D>
            {
                {TextureColor.Red, Assets.Texture2Ds.Platforms.Red},
                {TextureColor.Green, Assets.Texture2Ds.Platforms.Green},
                {TextureColor.Blue, Assets.Texture2Ds.Platforms.Blue}
            };

            Texture = new GameTexture(textures[color], position, scale, 0f);
            
            Color = color;

            this.orientation = orientation;

            if (orientation == Orientation.Vertical)
            {
                Texture.HorizontalToVertical();
            }
        }

        public TextureColor Color { get; set; }
    }
}