using System;
using System.Collections.Generic;
using Cryo.Engine;
using Cryo.Engine.Components;
using Cryo.Engine.Components.ColorChange;
using Cryo.Engine.Components.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Cryo
{
    public class CryoGame : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Player player;
        private Platform platform;

        public static Queue<Action<SpriteBatch>> DrawActions;

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

            player = new Player(ColorChangeComponent.PlatformColor.Red, Assets.Texture2Ds.Player.Blue, Assets.Texture2Ds.Player.Green, Assets.Texture2Ds.Player.Blue, Vector2.Zero, 1f);
            player.FindComponent<PhysicsComponent>().Velocity = new Vector2(0.01f);

            platform = new Platform(ColorChangeComponent.PlatformColor.Blue, Assets.Texture2Ds.Platform.Red,
                Assets.Texture2Ds.Platform.Green, Assets.Texture2Ds.Player.Blue, Vector2.Zero, 1f);
        }

        protected override void Update(GameTime gameTime)
        {
            Engine.Keyboards.Keyboard.Update();

            if (Engine.Keyboards.Keyboard.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            
            player.Draw(spriteBatch);

            while (DrawActions.Count != 0)
            {
                DrawActions.Dequeue().Invoke(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}