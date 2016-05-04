using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo
{
    public static class Assets
    {
        private static ContentManager content;

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
            }

            private static Texture2D LoadTexture2D(string path)
            {
                return content.Load<Texture2D>($"Textures\\{path}");
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