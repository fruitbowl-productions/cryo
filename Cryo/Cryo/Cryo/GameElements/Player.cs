﻿using System;
using System.Collections.Generic;
using System.Linq;
using Cryo.Engine;
using Cryo.Engine.Keyboards;
using Cryo.GameElements.Platforms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Cryo.GameElements
{
    public class Player : GameElement
    {
        private const float JumpSpeed = 200f;
        private const float Gravity = 200f;

        private readonly Control jumpControl;

        private readonly Dictionary<TextureColor, Texture2D> textures;

        private TextureColor color;

        private Vector2 velocity;

        public bool Alive { get; private set; }

        public Player(TextureColor startingColor, Dictionary<TextureColor, Texture2D> texturesInput, Vector2 position,
            float scale)
        {
            Texture = new GameTexture(null, position, scale, 0f);

            textures = texturesInput;
            Color = startingColor;

            CanJump = false;

            velocity = Vector2.Zero;

            jumpControl = new Control(Keys.Space);

            Alive = true;
        }

        private bool CanJump { get; set; }

        public TextureColor Color
        {
            get { return color; }
            set
            {
                color = value;
                Texture = new GameTexture(CurrentTexture2D, Texture.Position, Texture.Scale, 0f);
            }
        }

        private Texture2D CurrentTexture2D => textures[Color];

        public override void Update(GameTime gameTime)
        {
            HandleUserInput();

            UpdatePhysics(gameTime);

            CheckCollisions();

            CheckFall();

            Screen.Constrain(Texture);

            base.Update(gameTime);
        }

        private void HandleUserInput()
        {
            if (jumpControl.IsDown)
            {
                Jump();
            }
        }

        private void UpdatePhysics(GameTime gameTime)
        {
            UpdateGravity(gameTime);
            ApplyVelocity(gameTime);
        }

        private void UpdateGravity(GameTime gameTime)
        {
            velocity.Y += Gravity*(float) gameTime.ElapsedGameTime.TotalSeconds;
        }

        private void ApplyVelocity(GameTime gameTime)
        {
            Texture.Position += velocity*(float) gameTime.ElapsedGameTime.TotalSeconds;
        }

        private void Jump()
        {
            if (!CanJump) return;
            velocity.Y -= JumpSpeed;
        }

        private void CheckCollisions()
        {
            CanJump = false;

            foreach (var platform in PlatformManager.Platforms.Where(CollidesWith))
            {
                var collision = false;

                var topInsideOther = Texture.Top <= platform.Texture.Bottom;
                var bottomOutsideOther = Texture.Bottom >= platform.Texture.Bottom;
                if (topInsideOther && bottomOutsideOther)
                {
                    Texture.Top = platform.Texture.Bottom;
                    collision = true;
                }

                var topOutsideOther = Texture.Top <= platform.Texture.Top;
                var bottomInsideOther = Texture.Bottom >= platform.Texture.Top;
                if (topOutsideOther && bottomInsideOther)
                {
                    Texture.Bottom = platform.Texture.Top;
                    collision = true;
                }

                if (!collision) continue;
                CanJump = true;
                velocity.Y = 0f;
            }
        }

        private void CheckFall()
        {
            if (Texture.Bottom >= Screen.Height)
            {
                Alive = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Alive)
            {
                base.Draw(spriteBatch);
            }
        }
    }
}