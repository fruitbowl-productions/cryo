using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.UI.PictureSelector
{
    public class PictureSelectorBox : PictureBox
    {
        public PictureSelectorBox(Texture2D texture, SpriteEffects spriteEffect, string id)
            : base(texture, Vector2.Zero, 1f, spriteEffect)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}