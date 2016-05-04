using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.UI.ProgressBar
{
    public class ProgressBar : Element
    {
        private readonly ProgressBarBox[] boxes = new ProgressBarBox[10];

        public ProgressBar(Vector2 location, float boxPadding, float boxResizeFactor, Texture2D boxInactiveTexture,
            Texture2D boxActiveTexture)
        {
            Location = location;

            for (var i = 0; i < boxes.Length; i++)
            {
                boxes[i] = new ProgressBarBox(boxResizeFactor,
                    new Vector2(location.X + boxInactiveTexture.Width*boxResizeFactor*i + boxPadding*i, location.Y),
                    boxInactiveTexture, boxActiveTexture);
            }

            Progress = 0;
        }

        public float Progress { get; set; }

        public override void Update(GameTime gameTime)
        {
            foreach (var box in boxes)
            {
                box.Active = false;
            }

            for (var i = 0; i < Progress; i++)
            {
                boxes[i].Active = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var box in boxes)
            {
                box.Draw(spriteBatch);
            }
        }
    }
}