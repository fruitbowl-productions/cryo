using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.Engine
{
    public class GameTexture
    {
        public Vector2 Position;
        public Texture2D Texture;

        public GameTexture(Texture2D texture, Vector2 position, float scale, float rotation)
        {
            Texture = texture;
            Position = position;
            Scale = scale;
            Rotation = rotation;
        }

        public GameTexture(GameTexture other)
        {
            Texture = other.Texture;
            Position = other.Position;
            Scale = other.Scale;
        }

        public float Scale { get; set; }
        public float Rotation { get; set; }

        public float Width => Texture.Width*Scale;
        public float Height => Texture.Height*Scale;

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
            spriteBatch.Draw(Texture, Position, null, Color.White, Rotation, Vector2.Zero, Scale, SpriteEffects.None, 1f);
        }

        public void HorizontalToVertical()
        {
            Rotation = 90f;
            Top = Bottom + Width;
        }
    }
}