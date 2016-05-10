using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.GameElements.Platforms
{
    public static class PlatformManager
    {
        public static List<Platform> Platforms { get; set; } = new List<Platform>();

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var platform in Platforms)
            {
                platform.Draw(spriteBatch);
            }
        }
    }
}