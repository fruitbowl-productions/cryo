using Cryo.Engine;

namespace Cryo.GameElements
{
    public class Platform : GameElement
    {
        public Platform(TextureColor color, GameTexture texture)
        {
            Texture = texture;
            Color = color;
        }

        public TextureColor Color { get; set; }
    }
}