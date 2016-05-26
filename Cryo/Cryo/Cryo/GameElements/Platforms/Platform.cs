using System.Collections.Generic;
using Cryo.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.GameElements.Platforms
{
    public class Platform : GameElement
    {
        private readonly Dictionary<TextureColor, Texture2D> textures;

        public Platform(TextureColor color, Vector2 position, float scale)
        {
            textures = new Dictionary<TextureColor, Texture2D>
            {
                {TextureColor.Red, Assets.Texture2Ds.Platforms.Red},
                {TextureColor.Green, Assets.Texture2Ds.Platforms.Green},
                {TextureColor.Blue, Assets.Texture2Ds.Platforms.Blue}
            };

            Texture = new GameTexture(textures[color], position, scale);
            
            Color = color;
        }

        public TextureColor Color { get; set; }
    }
}