using System.Collections.Generic;
using System.Linq;
using Cryo.Engine;
using Cryo.GameElements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo
{
    public class Background : GameElement
    {
        private const int ImagesNum = 5;
        private const float ScrollSpeed = 5f;

        private readonly List<Image> images;

        public Background(GameTexture texture)
        {
            images = new List<Image>();

            texture.Left = Screen.Width - texture.Width;
            images.Add(new Image(texture));

            PopulateImages();
        }

        public override void Update(GameTime gameTime)
        {
            Scroll();

            if (images.Where(x => x.Texture.Left < 0).ToList().Count == 0)
            {
                PopulateImages();
            }
        }

        private void PopulateImages()
        {
            var lastItem = images[images.Count - 1];
            var currentX = lastItem.Texture.Left - lastItem.Texture.Width;

            for (var i = 0; i < ImagesNum; ++i)
            {
                var tempTexture = new GameTexture(Texture) {Left = currentX};
                images.Add(new Image(tempTexture));
                currentX -= tempTexture.Width;
            }
        }

        private void Scroll()
        {
            foreach (var image in images)
            {
                image.Texture.Left += ScrollSpeed;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var image in images)
            {
                image.Draw(spriteBatch);
            }
        }
    }
}