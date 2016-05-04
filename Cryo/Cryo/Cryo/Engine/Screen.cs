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
    }
}