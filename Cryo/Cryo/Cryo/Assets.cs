using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo
{
    public static class Assets
    {
        private static ContentManager Content { get; set; }

        public static void Initialize(ContentManager contentManager)
        {
            Content = contentManager;

            Texture2Ds.Initialize();
            Fonts.Initialize();
        }

        public static class Texture2Ds
        {
            public static void Initialize()
            {
                Platforms.Initialize();
                Player.Initialize();
            }

            private static Texture2D LoadTexture2D(string path) => Content.Load<Texture2D>($"Texture2Ds\\{path}");

            public static class Platforms
            {
                public static Texture2D Horizontal { get; private set; }
                public static Texture2D Vertical { get; private set; }

                public static void Initialize()
                {
                    Horizontal = LoadPlatformTexture2D("Horizontal");
                    Vertical = LoadPlatformTexture2D("Vertical");
                }

                private static Texture2D LoadPlatformTexture2D(string path) => LoadTexture2D($"Platforms\\{path}");
            }

            public static class Player
            {
                public static List<Texture2D> Walk { get; private set; } = new List<Texture2D>();
                public static Texture2D Jump { get; private set; }

                public static void Initialize()
                {
                    Walk.Add(LoadPlayerTexture2D("Walk1"));
                }

                private static Texture2D LoadPlayerTexture2D(string path) => LoadTexture2D($"Player\\{path}");
            }
        }

        public static class Fonts
        {
            public static void Initialize()
            {
            }

            private static SpriteFont LoadFont(string path)
            {
                return Content.Load<SpriteFont>($"Fonts\\{path}");
            }
        }
    }
}