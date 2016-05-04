using System;
using Microsoft.Xna.Framework;

namespace Cryo.Engine.Timers
{
    public class DelayedTimer : Timer
    {
        private readonly Action offAction;

        public DelayedTimer(Action action, Action offAction, TimeSpan delay) : base(action, delay)
        {
            this.offAction = offAction;
        }

        public override void Update(GameTime gameTime)
        {
            Current += gameTime.ElapsedGameTime;

            if (Current >= Delay)
            {
                if (Current >= Delay + Delay)
                {
                    Current = TimeSpan.Zero;
                }
                else
                {
                    Action.Invoke();
                }
            }
            else
            {
                offAction.Invoke();
            }
        }
    }
}