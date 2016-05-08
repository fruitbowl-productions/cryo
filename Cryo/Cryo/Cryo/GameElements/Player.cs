using System.Collections.Generic;
using Cryo.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Keyboard = Cryo.Engine.Keyboards.Keyboard;
using System.Linq;
using Cryo.GameElements.Platforms;

namespace Cryo.GameElements
{
    public class Player : GameElement
    {
        private bool jumping;

        private Vector2 velocity;

        private const float HorizontalMoveSpeed = 0.001f;

        private const float JumpSpeed = 0.125f;
        private const float Gravity = 0.001f;

        private TextureColor color;
        public TextureColor Color
        {
            get { return color; }
            set
            {
                color = value;
                Texture = new GameTexture(CurrentTexture2D, Texture.Position, Texture.Scale);
            }
        }

        private readonly Dictionary<TextureColor, Texture2D> textures;

        private Texture2D CurrentTexture2D => textures[Color];

        public Player(TextureColor startingColor, Dictionary<TextureColor, Texture2D> texturesInput, Vector2 position, float scale)
        {
            jumping = false;

            Texture = new GameTexture(null, position, scale);

            textures = texturesInput;
            Color = startingColor;

            velocity = Vector2.Zero;
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.IsKeyDown(Keys.Space))
            {
                Jump(gameTime);
            }

            UpdateGravity(gameTime);

            if (Keyboard.IsKeyDown(Keys.A))
            {
                velocity.X = -HorizontalMoveSpeed*(float) gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else if (Keyboard.IsKeyDown(Keys.D))
            {
                velocity.X = HorizontalMoveSpeed*(float) gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else
            {
                velocity.X = 0f;
            }

            Texture.Position += velocity;

            CheckCollisions();

            base.Update(gameTime);
        }

        private void UpdateGravity(GameTime gameTime)
        {
            velocity.Y += Gravity * (float) gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        private void Jump(GameTime gameTime)
        {
            if (jumping) return;
            jumping = true;
            velocity.Y -= JumpSpeed * (float) gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        private void CheckCollisions()
        {
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
                
                if (collision)
                {
                    velocity.Y = 0f;
                }
            }
        }
    }
}