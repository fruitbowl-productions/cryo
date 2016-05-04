using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.UI
{
    public class Animation : Element
    {
        private const double FrameDuration = 0.075;
        private readonly Texture2D[] frames;
        private readonly bool loop;
        private readonly PictureBox pictureBox;
        private int currentFrame;
        private double elapsedTime;

        public Animation(string folder, int frameNum, Vector2 location, float resizeFactor, ContentManager content,
            bool loop)
        {
            this.loop = loop;
            frames = new Texture2D[frameNum];
            Location = location;
            ResizeFactor = resizeFactor;
            currentFrame = 0;
            elapsedTime = 0;

            for (var i = 0; i < frameNum; i ++)
            {
                frames[i] = content.Load<Texture2D>(folder + "/" + (i + 1));
            }

            pictureBox = new PictureBox(frames[currentFrame], Location, ResizeFactor, SpriteEffects.None);
        }

        public override void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;

            if (elapsedTime <= FrameDuration) return;

            elapsedTime -= FrameDuration;
            currentFrame++;

            if (loop && currentFrame == frames.Length)
            {
                currentFrame = 0;
            }

            pictureBox.CurrentTexture = frames[currentFrame];

            pictureBox.Location = Location;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            pictureBox.Draw(spriteBatch);
        }
    }
}