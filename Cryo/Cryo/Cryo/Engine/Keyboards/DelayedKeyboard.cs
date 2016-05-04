using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Cryo.Engine.Keyboards
{
    public static class DelayedKeyboard
    {
        private static readonly Dictionary<Keys, TimeSpan> Delays;
        private static readonly List<Keys> CurrentlyPressed;
        private static readonly TimeSpan DefaultDelay = TimeSpan.FromMilliseconds(250);

        static DelayedKeyboard()
        {
            Delays = new Dictionary<Keys, TimeSpan>();
            CurrentlyPressed = new List<Keys>();

            foreach (var key in Enum.GetValues(typeof(Keys)))
            {
                Delays[(Keys) key] = DefaultDelay;
            }
        }

        public static IEnumerable<Keys> PressedKeys => CurrentlyPressed;

        public static bool IsKeyDown(Keys key) => CurrentlyPressed.Contains(key);
        public static bool IsKeyUp(Keys key) => !IsKeyDown(key);

        public static bool IsAnyKeyDown() => CurrentlyPressed.Count > 0;

        private static IEnumerable<Keys> GetPressedKeys(KeyboardState keyboard)
            => keyboard.GetPressedKeys().Where(key => key != Keys.None);

        public static void Update(GameTime gameTime)
        {
            CurrentlyPressed.Clear();

            foreach (var key in GetPressedKeys(Microsoft.Xna.Framework.Input.Keyboard.GetState()))
            {
                if (Delays[key] > TimeSpan.Zero) continue;
                Delays[key] = DefaultDelay;
                CurrentlyPressed.Add(key);
            }

            var tempDelays = new Dictionary<Keys, TimeSpan>(Delays);
            foreach (var key in tempDelays.Keys)
            {
                Delays[key] -= gameTime.ElapsedGameTime;
            }
        }
    }
}