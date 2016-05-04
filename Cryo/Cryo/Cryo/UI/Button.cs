using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Cryo.UI
{
    public delegate void ClickHandler();

    public class Button : Element
    {
        private readonly bool clickOnce;
        private readonly Texture2D hoverTexture;
        public readonly int Padding;
        private readonly Texture2D texture;
        private bool previousClickState;

        public Button(Texture2D texture, Texture2D hoverTexture, Vector2 location, ClickHandler clickHandler,
            float resizeFactor, int padding, SpriteEffects spriteEffect)
        {
            Clicked += clickHandler;
            Location = location;
            CurrentTexture = this.texture = texture;
            this.hoverTexture = hoverTexture;
            ResizeFactor = resizeFactor;
            Padding = padding;
            SpriteEffect = spriteEffect;
            previousClickState = false;
        }

        public Button(Texture2D texture, Texture2D hoverTexture, Vector2 location, ClickHandler clickHandler,
            float resizeFactor, int padding, SpriteEffects spriteEffect, bool clickOnce)
            : this(texture, hoverTexture, location, clickHandler, resizeFactor, padding, spriteEffect)
        {
            this.clickOnce = clickOnce;
        }

        public event ClickHandler Clicked;

        public override void Update(GameTime gameTime)
        {
            var cursor = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);
            var button = new Rectangle((int) Location.X, (int) Location.Y,
                (int) (CurrentTexture.Width*ResizeFactor - Padding),
                (int) (CurrentTexture.Height*ResizeFactor - Padding));

            CurrentTexture = cursor.Intersects(button) ? hoverTexture : texture;

            if (!clickOnce)
            {
                if (cursor.Intersects(button) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Clicked?.Invoke();
                }
            }
            else
            {
                if (previousClickState && cursor.Intersects(button) &&
                    Mouse.GetState().LeftButton == ButtonState.Released)
                {
                    Clicked?.Invoke();
                }

                if (cursor.Intersects(button) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    previousClickState = true;
                }
                else
                {
                    previousClickState = false;
                }
            }
        }
    }
}