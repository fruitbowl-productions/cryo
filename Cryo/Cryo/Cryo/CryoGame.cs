using System.Collections.Generic;
using Cryo.Engine;
using Cryo.GameElements;
using Cryo.GameElements.Platforms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Keyboard = Cryo.Engine.Keyboards.Keyboard;

namespace Cryo
{
    public class CryoGame : Game
    {
        private readonly GraphicsDeviceManager graphics;

        private Player player;
        private SpriteBatch spriteBatch;

        public CryoGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            SetupScreen();
            PlatformManager.Initialize();

            base.Initialize();
        }

        private void SetupScreen()
        {
            Screen.Initialize(graphics);
            Screen.Height = 500;
            Screen.Width = 900;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Assets.Initialize(Content);

            player = new Player(TextureColor.Red, Assets.Texture2Ds.Player.Walk, Assets.Texture2Ds.Player.Jump, new Vector2(100f, 0f), 1f);

            PlatformManager.AddPlatform(TextureColor.Blue, Platform.OrientationType.Horizontal);
            PlatformManager.AddPlatform(TextureColor.Green, Platform.OrientationType.Horizontal);
            PlatformManager.AddPlatform(TextureColor.Red, Platform.OrientationType.Vertical);
        }

        protected override void Update(GameTime gameTime)
        {
            Keyboard.Update();

            if (Keyboard.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            player.Update(gameTime);

            PlatformManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            player.Draw(spriteBatch);

            PlatformManager.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}