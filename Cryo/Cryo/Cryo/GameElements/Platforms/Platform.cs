using System.Collections.Generic;
using Cryo.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.GameElements.Platforms
{
    public class Platform : GameElement
    {
        public enum OrientationType
        {
            Horizontal,
            Vertical
        }

        public OrientationType Orientation { get; private set; }

        public Platform(TextureColor color, Vector2 position, float scale, OrientationType orientation)
        {
            var textures = new Dictionary<TextureColor, Dictionary<OrientationType, Texture2D>>
            {
                {
                    TextureColor.Red,
                    new Dictionary<OrientationType, Texture2D>
                    {
                        {OrientationType.Horizontal, Assets.Texture2Ds.Platforms.Red.Horizontal},
                        {OrientationType.Vertical, Assets.Texture2Ds.Platforms.Red.Vertical}
                    }
                },
                {
                    TextureColor.Green,
                    new Dictionary<OrientationType, Texture2D>
                    {
                        {OrientationType.Horizontal, Assets.Texture2Ds.Platforms.Green.Horizontal},
                        {OrientationType.Vertical, Assets.Texture2Ds.Platforms.Green.Vertical}
                    }
                },
                {
                    TextureColor.Blue,
                    new Dictionary<OrientationType, Texture2D>
                    {
                        {OrientationType.Horizontal, Assets.Texture2Ds.Platforms.Blue.Horizontal},
                        {OrientationType.Vertical, Assets.Texture2Ds.Platforms.Blue.Vertical}
                    }
                }
            };
            Texture = new GameTexture(textures[color][orientation], position, scale, 0f);

            Color = color;
            Orientation = orientation;
        }

        public TextureColor Color { get; set; }
    }
}