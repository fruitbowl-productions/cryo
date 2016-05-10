using Microsoft.Xna.Framework.Input;

namespace Cryo.Engine.Keyboards
{
    public class Control
    {
        private readonly Keys key;

        public Control(Keys keyInput)
        {
            key = keyInput;
        }

        public bool IsDown => Keyboard.IsKeyDown(key);
    }
}