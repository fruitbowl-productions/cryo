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
            var textures = new Dictionary<OrientationType, Texture2D>
            {
                { OrientationType.Horizontal, Assets.Texture2Ds.Platforms.Horizontal },
                { OrientationType.Vertical, Assets.Texture2Ds.Platforms.Vertical }
            };

            Texture = new GameTexture(textures[orientation], position, scale, 0f, color.ToColor());

            Orientation = orientation;
        }
    }
}