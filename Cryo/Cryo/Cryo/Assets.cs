using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo
{
    public static class Assets
    {
        private static ContentManager content { get; set; }

        public static void Initialize(ContentManager contentManager)
        {
            content = contentManager;

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

            private static Texture2D LoadTexture2D(string path) => content.Load<Texture2D>($"Texture2Ds\\{path}");

            public static class Platforms
            {
                public static void Initialize()
                {
                    Red.Initialize();
                    Green.Initialize();
                    Blue.Initialize();
                }

                private static Texture2D LoadPlatformTexture2D(string path) => LoadTexture2D($"Platforms\\{path}");

                public static class Red
                {
                    public static Texture2D Horizontal { get; private set; }
                    public static Texture2D Vertical { get; private set; }

                    public static void Initialize()
                    {
                        Horizontal = LoadRedPlatformTexture2D("Horizontal");
                        Vertical = LoadRedPlatformTexture2D("Vertical");
                    }

                    private static Texture2D LoadRedPlatformTexture2D(string path)
                        => LoadPlatformTexture2D($"Red\\{path}");
                }

                public static class Green
                {
                    public static Texture2D Horizontal { get; private set; }
                    public static Texture2D Vertical { get; private set; }

                    public static void Initialize()
                    {
                        Horizontal = LoadGreenPlatformTexture2D("Horizontal");
                        Vertical = LoadGreenPlatformTexture2D("Vertical");
                    }

                    private static Texture2D LoadGreenPlatformTexture2D(string path)
                        => LoadPlatformTexture2D($"Green\\{path}");
                }

                public static class Blue
                {
                    public static Texture2D Horizontal { get; private set; }
                    public static Texture2D Vertical { get; private set; }

                    public static void Initialize()
                    {
                        Horizontal = LoadBluePlatformTexture2D("Horizontal");
                        Vertical = LoadBluePlatformTexture2D("Vertical");
                    }

                    private static Texture2D LoadBluePlatformTexture2D(string path)
                        => LoadPlatformTexture2D($"Blue\\{path}");
                }
            }

            public static class Player
            {
                public static Texture2D Red { get; private set; }
                public static Texture2D Green { get; private set; }
                public static Texture2D Blue { get; private set; }

                public static void Initialize()
                {
                    Red = LoadPlayerTexture2D("Red");
                    Green = LoadPlayerTexture2D("Green");
                    Blue = LoadPlayerTexture2D("Blue");
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
                return content.Load<SpriteFont>($"Fonts\\{path}");
            }
        }
    }
}