using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Cryo.Engine.Components
{
    public abstract class Component
    {
        public virtual void Update(GameTime gameTime)
        {
        }

        public static T FindComponent<T>(List<Component> components) where T : Component
        {
            return components.Find(component => component is T) as T;
        }
    }
}