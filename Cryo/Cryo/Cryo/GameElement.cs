using System.Collections.Generic;
using System.Linq;
using Cryo.Engine;
using Cryo.Engine.Components;
using Cryo.Engine.Components.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo
{
    public abstract class GameElement : IPhysics
    {
        protected GameElement()
        {
            Components = new List<Component>();
        }

        public List<Component> Components { get; set; }

        public GameTexture Texture { get; set; }

        public GameTexture GetTexture() => Texture;

        public virtual void Update(GameTime gameTime)
        {
            foreach (var component in Components)
            {
                component.Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Texture.Draw(spriteBatch);
        }

        public virtual Rectangle GetRectangle()
            => new Rectangle((int)Texture.Left, (int)Texture.Top, (int)Texture.Width, (int)Texture.Height);

        public bool CollidesWith(IPhysics other) => GetRectangle().Intersects(other.GetRectangle());

        public IEnumerable<T> FindComponents<T>() where T : Component => Components.OfType<T>();
        public T FindComponent<T>() where T : Component => FindComponents<T>().First();
    }
}