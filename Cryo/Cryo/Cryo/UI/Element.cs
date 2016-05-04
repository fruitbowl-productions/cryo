using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.UI
{
    public class Element
    {
        public Texture2D CurrentTexture;
        public Vector2 Location;
        public float ResizeFactor;
        protected SpriteEffects SpriteEffect;

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CurrentTexture, Location, null, Color.White, 0f, Vector2.Zero, ResizeFactor, SpriteEffect,
                0f);
        }
    }
}