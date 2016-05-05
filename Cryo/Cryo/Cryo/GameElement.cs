using Cryo.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo
{
    public abstract class GameElement
    {
        public GameTexture Texture { get; set; }

        public bool OnScreen => (Texture.Right > 0 && Texture.Left < Screen.Width);
        public virtual Rectangle Rectangle => new Rectangle((int)Texture.Left, (int)Texture.Top, (int)Texture.Width, (int)Texture.Height);

        public GameElement(GameTexture texture)
        {
            Texture = texture;
        }

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (OnScreen)
            {
                Texture.Draw(spriteBatch);
            }
        }
    }
}
