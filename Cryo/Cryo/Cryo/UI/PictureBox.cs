using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.UI
{
    public class PictureBox : Element
    {
        public PictureBox(Texture2D texture, Vector2 location, float resizeFactor, SpriteEffects spriteEffect)
        {
            Location = location;
            CurrentTexture = texture;
            ResizeFactor = resizeFactor;
            SpriteEffect = spriteEffect;
        }
    }
}