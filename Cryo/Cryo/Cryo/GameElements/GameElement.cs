using Cryo.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.GameElements
{
    public abstract class GameElement
    {
        public GameTexture Texture { get; set; }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Texture.Draw(spriteBatch);
        }

        public virtual Rectangle Rectangle => new Rectangle((int)Texture.Left, (int)Texture.Top, (int)Texture.Width, (int)Texture.Height);

        public bool CollidesWith(GameElement other) => Rectangle.IntersectsOrTouches(other.Rectangle);
    }
}