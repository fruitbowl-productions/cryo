using System;
using System.Collections.Generic;
using Cryo.Engine;
using Cryo.Engine.Components.ColorChange;
using Cryo.Engine.Components.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Keyboard = Cryo.Engine.Keyboards.Keyboard;

namespace Cryo
{
    public class CryoGame : Game
    {
        public static Queue<Action<SpriteBatch>> DrawActions;
        private readonly GraphicsDeviceManager graphics;
        private Platform platform;

        private Player player;
        private SpriteBatch spriteBatch;

        public CryoGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Screen.Initialize(graphics);

            DrawActions = new Queue<Action<SpriteBatch>>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Assets.Initialize(Content);

            player = new Player(ColorChangeComponent.PlatformColor.Red, Assets.Texture2Ds.Player.Blue,
                Assets.Texture2Ds.Player.Green, Assets.Texture2Ds.Player.Blue, Vector2.Zero, 1f);

            platform = new Platform(ColorChangeComponent.PlatformColor.Blue, Assets.Texture2Ds.Platform.Red,
                Assets.Texture2Ds.Platform.Green, Assets.Texture2Ds.Player.Blue, new Vector2(0f, 250f), 1f);
        }

        protected override void Update(GameTime gameTime)
        {
            Keyboard.Update();

            if (Keyboard.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            player.Update(gameTime);
            platform.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            player.Draw(spriteBatch);
            platform.Draw(spriteBatch);

            while (DrawActions.Count != 0)
            {
                DrawActions.Dequeue().Invoke(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}