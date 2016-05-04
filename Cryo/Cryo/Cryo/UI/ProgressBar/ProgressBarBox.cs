using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo.UI.ProgressBar
{
    public class ProgressBarBox : Element
    {
        private readonly Texture2D activeTexture;
        private readonly Texture2D inactiveTexture;

        public ProgressBarBox(float resizeFactor, Vector2 location, Texture2D inactiveTexture, Texture2D activeTexture)
        {
            ResizeFactor = resizeFactor;
            this.inactiveTexture = inactiveTexture;
            this.activeTexture = activeTexture;
            Active = false;
            Location = location;
        }

        public bool Active
        {
            set { CurrentTexture = value ? activeTexture : inactiveTexture; }
        }
    }
}