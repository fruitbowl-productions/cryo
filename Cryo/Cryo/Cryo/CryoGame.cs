using System;
using System.Collections.Generic;
using Cryo.Engine;
using Cryo.GameElements;
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

        public static List<Platform> Platforms;

        public CryoGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Screen.Initialize(graphics);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Assets.Initialize(Content);

            player = new Player(TextureColor.Red, new Dictionary<TextureColor, Texture2D>
            {
                {TextureColor.Red, Assets.Texture2Ds.Player.Red},
                {TextureColor.Green, Assets.Texture2Ds.Player.Green},
                {TextureColor.Blue, Assets.Texture2Ds.Player.Blue}
            }, Vector2.Zero, 1f);

            Platforms = new List<Platform>
            {
                new Platform(TextureColor.Blue, new GameTexture(Assets.Texture2Ds.Platforms.Blue, new Vector2(0f, 250f), 1f))
            };
        }

        protected override void Update(GameTime gameTime)
        {
            Keyboard.Update();

            if (Keyboard.IsKeyDown(Keys.Escape))
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

            foreach (var platform in Platforms)
            {
                platform.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}