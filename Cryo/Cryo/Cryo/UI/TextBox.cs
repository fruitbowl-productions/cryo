using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.UI
{
    public class TextBox : Element
    {
        private readonly Color color;
        private readonly SpriteFont spriteFont;
        public int Length { get; set; }
        public string Text { get; set; }

        public Vector2 Dimensions => spriteFont.MeasureString(Text);

        public TextBox(string text, Vector2 location, SpriteFont spriteFont, Color color)
        {
            Text = text;
            Location = location;
            this.spriteFont = spriteFont;
            this.color = color;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, Text, Location, color);
        }
    }
}