using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Cryo.UI
{
    public class Cursor : Element
    {
        public readonly Texture2D HoverTexture;
        public readonly Texture2D Texture;

        public Cursor(Texture2D texture, Texture2D hoverTexture, float resizeFactor, SpriteEffects spriteEffect)
        {
            CurrentTexture = Texture = texture;
            HoverTexture = hoverTexture;
            ResizeFactor = resizeFactor;
            SpriteEffect = spriteEffect;
        }

        public override void Update(GameTime gameTime)
        {
            Location.X = Mouse.GetState().X;
            Location.Y = Mouse.GetState().Y;
        }
    }
}