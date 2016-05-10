using Microsoft.Xna.Framework;

namespace Cryo.Engine
{
    public static class Screen
    {
        private static GraphicsDeviceManager graphicsDeviceManager;

        public static int Width
        {
            get { return graphicsDeviceManager.GraphicsDevice.Viewport.Width; }
            set
            {
                graphicsDeviceManager.PreferredBackBufferWidth = value;
                graphicsDeviceManager.ApplyChanges();
            }
        }

        public static int Height
        {
            get { return graphicsDeviceManager.GraphicsDevice.Viewport.Height; }
            set
            {
                graphicsDeviceManager.PreferredBackBufferHeight = value;
                graphicsDeviceManager.ApplyChanges();
            }
        }

        public static bool FullScreen
        {
            get { return graphicsDeviceManager.IsFullScreen; }
            set
            {
                graphicsDeviceManager.IsFullScreen = value;
                graphicsDeviceManager.ApplyChanges();
            }
        }

        public static void Initialize(GraphicsDeviceManager graphicsDeviceManagerInput)
        {
            graphicsDeviceManager = graphicsDeviceManagerInput;
        }

        public static void Constrain(GameTexture texture)
        {
            texture.Position.X = MathHelper.Clamp(texture.Position.X, 0, Width - texture.Width);
            texture.Position.Y = MathHelper.Clamp(texture.Position.Y, 0, Height - texture.Height);
        }
    }
}