using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.GameElements.Platforms
{
    public static class PlatformManager
    {
        public static List<Platform> Platforms { get; set; } = new List<Platform>();

        private const float PlatformHorizontalOffset = 10f;
        private const float PlatformVerticalLocation = 300f;
        private const float PlatformHorizontalSpeed = -1f;

        private static float NextHorizontalPosition
        {
            get
            {
                if (Platforms.Count > 0)
                {
                    return Platforms[Platforms.Count - 1].Texture.Right + PlatformHorizontalOffset;
                }

                return PlatformHorizontalOffset;
            }
        }

        public static void AddPlatform(TextureColor color)
        {
            Platforms.Add(new Platform(color, new Vector2(NextHorizontalPosition, PlatformVerticalLocation), 1f));
        }

        public static void Update(GameTime gameTime)
        {
            foreach (var platform in Platforms)
            {
                platform.Texture.Position.X += PlatformHorizontalSpeed;
            }

            PruneInactivePlatforms();
        }

        private static void PruneInactivePlatforms()
        {
            var tempPlatforms = new List<Platform>(Platforms);

            foreach (var platform in Platforms)
            {
                if (platform.Texture.Right < 0)
                {
                    tempPlatforms.Remove(platform);
                }
            }

            Platforms = tempPlatforms;
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var platform in Platforms)
            {
                platform.Draw(spriteBatch);
            }
        }
    }
}