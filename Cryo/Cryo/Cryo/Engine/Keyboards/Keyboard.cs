using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace Cryo.Engine.Keyboards
{
    public static class Keyboard
    {
        private static KeyboardState currentState;
        private static KeyboardState previousState;

        static Keyboard()
        {
            currentState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            previousState = currentState;
        }

        public static List<Keys> PressedKeys => GetPressedKeys(currentState);

        public static bool IsKeyDown(Keys key) => currentState.IsKeyDown(key);
        public static bool IsKeyUp(Keys key) => currentState.IsKeyUp(key);

        public static bool IsKeyNowDown(Keys key) => currentState.IsKeyDown(key) && !previousState.IsKeyDown(key);
        public static bool IsKeyNowUp(Keys key) => currentState.IsKeyUp(key) && !previousState.IsKeyUp(key);

        public static bool IsAnyKeyDown() => PressedKeys.Count > 0;

        private static List<Keys> GetPressedKeys(KeyboardState keyboard)
            => keyboard.GetPressedKeys().Where(key => key != Keys.None).ToList();

        public static void Update()
        {
            previousState = currentState;
            currentState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
        }
    }
}