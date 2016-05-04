using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.UI.PictureSelector
{
    public class PictureSelector : Element
    {
        public delegate void ClickHandler(PictureSelectorBox image);

        private readonly float buttonDistance;
        private readonly float buttonResizeFactor;
        private readonly Texture2D buttonTexture;
        private readonly int imageHeight;
        private readonly PictureSelectorBox[] images;
        public readonly Button Left;
        public readonly Button Right;
        private readonly bool staticLocation;
        private PictureSelectorBox currentImage;
        private int imageIndex;

        public PictureSelector(Vector2 location, float buttonDistance, Texture2D buttonTexture, float buttonResizeFactor,
            int buttonPadding, bool staticLocation, int imageHeight, ClickHandler clicked,
            params PictureSelectorBox[] images)
        {
            Clicked += clicked;
            this.imageHeight = imageHeight;
            this.staticLocation = staticLocation;
            this.buttonResizeFactor = buttonResizeFactor;
            this.buttonTexture = buttonTexture;
            this.buttonDistance = buttonDistance;
            this.images = images;
            Location = location;
            currentImage = this.images[imageIndex];
            InitializeImages();
            Left = new Button(buttonTexture, buttonTexture,
                new Vector2(
                    location.X - currentImage.CurrentTexture.Width*currentImage.ResizeFactor/2 - buttonDistance -
                    buttonTexture.Width*buttonResizeFactor,
                    location.Y + currentImage.CurrentTexture.Height*currentImage.ResizeFactor/2 -
                    buttonTexture.Height*buttonResizeFactor/2), SwitchImageLeft,
                buttonResizeFactor, buttonPadding, SpriteEffects.None, true);
            Right = new Button(buttonTexture, buttonTexture,
                new Vector2(location.X + currentImage.CurrentTexture.Width*currentImage.ResizeFactor/2 + buttonDistance,
                    location.Y + currentImage.CurrentTexture.Height*currentImage.ResizeFactor
                    /2 - buttonTexture.Height*buttonResizeFactor/2), SwitchImageRight,
                buttonResizeFactor, buttonPadding, SpriteEffects.FlipHorizontally, true);
            Clicked?.Invoke(currentImage);
        }

        public string CurrentImage => currentImage.Id;

        public event ClickHandler Clicked;

        private void InitializeImages()
        {
            SetImageSizes();
            SetImageLocations();
        }

        private void SetImageLocations()
        {
            foreach (var image in images)
            {
                image.Location.X = Location.X - image.CurrentTexture.Width*image.ResizeFactor/2;
                image.Location.Y = Location.Y;
            }
        }

        private void SetImageSizes()
        {
            foreach (var image in images)
            {
                image.ResizeFactor = imageHeight/(float) image.CurrentTexture.Height;
            }
        }

        private void UpdateButtonLocations()
        {
            Clicked?.Invoke(currentImage);

            if (staticLocation) return;

            Left.Location.X = Location.X - currentImage.CurrentTexture.Width*currentImage.ResizeFactor/2 -
                              buttonDistance -
                              buttonTexture.Width*buttonResizeFactor;
            Right.Location.X = Location.X + currentImage.CurrentTexture.Width*currentImage.ResizeFactor/2 +
                               buttonDistance;
        }

        private void SwitchImageRight()
        {
            currentImage = images[++imageIndex%images.Length];
            UpdateButtonLocations();
        }

        private void SwitchImageLeft()
        {
            if (images.Length > 1 && --imageIndex < 0)
            {
                imageIndex = images.Length - 1;
            }

            currentImage = images[imageIndex];

            UpdateButtonLocations();
        }

        public override void Update(GameTime gameTime)
        {
            Right.Update(gameTime);
            Left.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Right.Draw(spriteBatch);
            Left.Draw(spriteBatch);

            currentImage.Draw(spriteBatch);
        }

        #region Unused Constructors

        // NOTE The automatic button position won't work as it hasn't been updated. See button positions on above constructor for correct positions.

        public PictureSelector(Vector2 location, float rightDistance, float leftDistance, Texture2D rightTexture,
            Texture2D leftTexture, float rightResizeFactor, float leftResizeFactor, int rightPadding, int leftPadding,
            params PictureSelectorBox[] images)
        {
            this.images = images;
            Right = new Button(rightTexture, rightTexture,
                new Vector2(location.X - rightDistance,
                    location.Y + this.images[0].CurrentTexture.Height/2 - rightTexture.Height*rightResizeFactor/2),
                SwitchImageRight,
                rightResizeFactor, rightPadding, SpriteEffects.None, true);
            Left = new Button(leftTexture, leftTexture,
                new Vector2(location.X + leftDistance,
                    location.Y + this.images[0].CurrentTexture.Height/2 - leftTexture.Height*leftResizeFactor/2),
                SwitchImageLeft,
                leftResizeFactor, leftPadding, SpriteEffects.None, true);
            currentImage = this.images[imageIndex];
            InitializeImages();
        }

        public PictureSelector(Vector2 location, Texture2D buttonTexture, Vector2 rightLocation, Vector2 leftLocation,
            float buttonResizeFactor, int buttonPadding, params PictureSelectorBox[] images)
        {
            this.images = images;
            Location = location;
            Right = new Button(buttonTexture, buttonTexture, rightLocation, SwitchImageRight, buttonResizeFactor,
                buttonPadding,
                SpriteEffects.FlipHorizontally, true);
            Left = new Button(buttonTexture, buttonTexture, leftLocation, SwitchImageLeft, buttonResizeFactor,
                buttonPadding,
                SpriteEffects.None, true);
            currentImage = this.images[imageIndex];
            InitializeImages();
        }

        public PictureSelector(Vector2 location, Texture2D rightTexture, Texture2D leftTexture, Vector2 rightLocation,
            Vector2 leftLocation, float rightResizeFactor, float leftResizeFactor, int rightPadding, int leftPadding,
            params PictureSelectorBox[] images)
        {
            this.images = images;
            Location = location;
            Right = new Button(rightTexture, rightTexture, rightLocation, SwitchImageRight, rightResizeFactor,
                rightPadding,
                SpriteEffects.None, true);
            Left = new Button(leftTexture, leftTexture, leftLocation, SwitchImageLeft, leftResizeFactor, leftPadding,
                SpriteEffects.None, true);
            currentImage = this.images[imageIndex];
            InitializeImages();
        }

        #endregion
    }
}