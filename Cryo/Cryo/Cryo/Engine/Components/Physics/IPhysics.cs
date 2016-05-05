using Microsoft.Xna.Framework;

namespace Cryo.Engine.Components.Physics
{
    public interface IPhysics
    {
        Vector2 GetPosition();
        void SetPosition(Vector2 value);
    }
}
