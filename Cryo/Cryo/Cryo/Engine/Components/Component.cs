using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Cryo.Engine.Components
{
    public abstract class Component
    {
        private static readonly List<Component> ComponentRegistry = new List<Component>();

        protected Component()
        {
            ComponentRegistry.Add(this);
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public static IEnumerable<T> AllComponents<T>() where T : Component => ComponentRegistry.OfType<T>();
    }
}