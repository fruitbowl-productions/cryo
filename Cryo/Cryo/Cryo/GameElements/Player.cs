using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        private const float JumpSpeed = 300f;
        private const float Gravity = 500f;

        private readonly Control jumpControl;

        private readonly List<Texture2D> walkTextures;
        private readonly Texture2D jumpTexture;

        private Vector2 velocity;

        public Player(TextureColor startingColor, List<Texture2D> walkTextures, Texture2D jumpTexture, Vector2 position,
            float scale)
        {
            Texture = new GameTexture(walkTextures[0], position, scale, 0f, startingColor.ToColor());

            this.walkTextures = walkTextures;
            this.jumpTexture = jumpTexture;

            Color = startingColor;

            CanJump = false;

            velocity = Vector2.Zero;

            jumpControl = new Control(Keys.Space);

            Alive = true;
        }

        public bool Alive { get; private set; }

        private bool CanJump { get; set; }

        public TextureColor Color
        {
            get { return Texture.Tint.ToTextureColor(); }
            set { Texture.Tint = value.ToColor(); }
        }

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

                switch (platform.Orientation)
                {
                    case Platform.OrientationType.Horizontal:
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

                        break;
                    case Platform.OrientationType.Vertical:
                        Alive = false;
                        break;
                    default:
                        throw new System.ArgumentOutOfRangeException();
                }
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