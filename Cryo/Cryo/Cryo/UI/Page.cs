using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.UI
{
    public abstract class Page
    {
        public List<Element> Elements { get; set; } = new List<Element>();
        private Color backgroundColor;
        private Cursor cursor;

        public virtual void Initialize(Color backgroundColorInput, Cursor cursorInput)
        {
            backgroundColor = backgroundColorInput;
            cursor = cursorInput;
        }

        public virtual void Update(GameTime gameTime)
        {
            cursor.CurrentTexture = cursor.Texture;
            cursor.Update(gameTime);

            foreach (var element in Elements)
            {
                element.Update(gameTime);

                if (element is Button)
                {
                    var button = new Rectangle((int) element.Location.X, (int) element.Location.Y,
                        (int) (element.CurrentTexture.Width*element.ResizeFactor - (element as Button).Padding),
                        (int) (element.CurrentTexture.Height*element.ResizeFactor - (element as Button).Padding));
                    var cursorRect = new Rectangle((int) cursor.Location.X, (int) cursor.Location.Y, 1, 1);
                    if (button.Intersects(cursorRect))
                        cursor.CurrentTexture = cursor.HoverTexture;
                }
                else if (element is PictureSelector.PictureSelector)
                {
                    var button = new Rectangle((int) (element as PictureSelector.PictureSelector).Right.Location.X,
                        (int) (element as PictureSelector.PictureSelector).Right.Location.Y,
                        (int)
                            ((element as PictureSelector.PictureSelector).Right.CurrentTexture.Width*
                             (element as PictureSelector.PictureSelector).Right.ResizeFactor -
                             (element as PictureSelector.PictureSelector).Right.Padding),
                        (int)
                            ((element as PictureSelector.PictureSelector).Right.CurrentTexture.Height*
                             (element as PictureSelector.PictureSelector).Right.ResizeFactor -
                             (element as PictureSelector.PictureSelector).Right.Padding));
                    var cursorRect = new Rectangle((int) cursor.Location.X, (int) cursor.Location.Y, 1, 1);
                    if (button.Intersects(cursorRect))
                        cursor.CurrentTexture = cursor.HoverTexture;
                    var button2 = new Rectangle((int) (element as PictureSelector.PictureSelector).Left.Location.X,
                        (int) (element as PictureSelector.PictureSelector).Left.Location.Y,
                        (int)
                            ((element as PictureSelector.PictureSelector).Left.CurrentTexture.Width*
                             (element as PictureSelector.PictureSelector).Left.ResizeFactor -
                             (element as PictureSelector.PictureSelector).Left.Padding),
                        (int)
                            ((element as PictureSelector.PictureSelector).Left.CurrentTexture.Height*
                             (element as PictureSelector.PictureSelector).Left.ResizeFactor -
                             (element as PictureSelector.PictureSelector).Left.Padding));
                    if (button2.Intersects(cursorRect))
                        cursor.CurrentTexture = cursor.HoverTexture;
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            graphicsDevice.Clear(backgroundColor);

            foreach (var element in Elements)
                element.Draw(spriteBatch);

            cursor.Draw(spriteBatch);
        }
    }
}