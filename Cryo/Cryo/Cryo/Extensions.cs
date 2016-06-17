using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Cryo
{
    public static class Extensions
    {
        public static bool IntersectsOrTouches(this Rectangle a, Rectangle b)
            => b.X <= a.X + a.Width && a.X <= b.X + b.Width && b.Y <= a.Y + a.Height && a.Y <= b.Y + b.Height;

        public static Dictionary<TValue, TKey> Invert<TKey, TValue>(this Dictionary<TKey, TValue> dictionary) =>
            dictionary.ToDictionary(x => x.Value, x => x.Key);

        private static Dictionary<TextureColor, Color> ColorMapping = new Dictionary<TextureColor, Color>
        {
            {TextureColor.Blue, Color.Blue},
            {TextureColor.Green, Color.Green},
            {TextureColor.Red, Color.Red}
        };

        public static Color ToColor(this TextureColor color) => ColorMapping[color];

        public static TextureColor ToTextureColor(this Color color)
            => ColorMapping.Invert()[color];
    }
}