using System;
using Microsoft.Xna.Framework;

namespace Cryo.Engine.Timers
{
    public class Timer
    {
        protected readonly Action Action;
        protected TimeSpan Current;

        protected TimeSpan Delay;

        public Timer(Action action, TimeSpan delay)
        {
            Action = action;
            Delay = delay;
            Current = TimeSpan.Zero;
        }

        public virtual void Update(GameTime gameTime)
        {
            Current += gameTime.ElapsedGameTime;
            if (Current < Delay) return;
            Action.Invoke();
            Current = TimeSpan.Zero;
        }
    }
}