using Cryo.Engine;
namespace Cryo.GameElements
{
    public class Platform : GameElement
    {
        public TextureColor Color { get; set; }

        public Platform(TextureColor color, GameTexture texture)
        {
            Texture = texture;
            Color = color;
        }
    }
}