using System.Collections.Generic;
using Cryo.Engine;
using Cryo.Engine.Components;
using Cryo.Engine.Components.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cryo
{
    public abstract class GameElement : IPhysics
    {
        public List<Component> Components { get; set; }

        public GameTexture Texture { get; set; }
        
        public virtual Rectangle Rectangle => new Rectangle((int)Texture.Left, (int)Texture.Top, (int)Texture.Width, (int)Texture.Height);

        protected GameElement()
        {
            Components = new List<Component>();
        }

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

        public bool CollidesWith(GameElement other) => Rectangle.Intersects(other.Rectangle);

        public T FindComponent<T>() where T : Component
        {
            return Components.Find(x => x is T) as T;
        }

        public Vector2 GetPosition()
        {
            return Texture.Position;
        }

        public void SetPosition(Vector2 value)
        {
            Texture.Position = value;
        }
    }
}
