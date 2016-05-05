using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.Engine
{
    public class GameTexture
    {
        private readonly Texture2D texture;
        public Vector2 Position;

        public GameTexture(Texture2D texture, Vector2 position, float scale)
        {
            this.texture = texture;
            Position = position;
            Scale = scale;
        }

        public GameTexture(GameTexture other)
        {
            texture = other.texture;
            Position = other.Position;
            Scale = other.Scale;
        }

        public float Scale { get; set; }

        public float Width => texture.Width*Scale;
        public float Height => texture.Height*Scale;

        public float Left
        {
            get { return Position.X; }
            set { Position.X = value; }
        }

        public float Right
        {
            get { return Position.X + Width; }
            set { Position.X = value - Width; }
        }

        public float Top
        {
            get { return Position.Y; }
            set { Position.Y = value; }
        }

        public float Bottom
        {
            get { return Position.Y + Height; }
            set { Position.Y = value - Height; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, 0f, Vector2.Zero, Scale, SpriteEffects.None, 1f);
        }
    }
}