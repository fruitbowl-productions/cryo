using System.Collections.Generic;
using Cryo.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.GameElements.Platforms
{
    public static class PlatformManager
    {
        private const float PlatformHorizontalOffset = 10f;
        private static float PlatformVerticalBottom;
        private const float PlatformHorizontalSpeed = -50f;
        public static List<Platform> Platforms { get; private set; } = new List<Platform>();

        public static void Initialize()
        {
            PlatformVerticalBottom = Screen.Height*3f/4f;
        }

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

        public static void AddPlatform(TextureColor color, Platform.OrientationType orientation)
        {
            var platform = new Platform(color, new Vector2(NextHorizontalPosition, 0f), 1f, orientation)
            {
                Texture = {Bottom = PlatformVerticalBottom}
            };
            Platforms.Add(platform);
        }

        public static void Update(GameTime gameTime)
        {
            foreach (var platform in Platforms)
            {
                platform.Texture.Position.X += PlatformHorizontalSpeed*(float) gameTime.ElapsedGameTime.TotalSeconds;
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