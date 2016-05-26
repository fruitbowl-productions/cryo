using Microsoft.Xna.Framework;

namespace Cryo
{
    public static class Extensions
    {
        public static bool IntersectsOrTouches(this Rectangle a, Rectangle b)
            => b.X <= a.X + a.Width && a.X <= b.X + b.Width && b.Y <= a.Y + a.Height && a.Y <= b.Y + b.Height;
    }
}