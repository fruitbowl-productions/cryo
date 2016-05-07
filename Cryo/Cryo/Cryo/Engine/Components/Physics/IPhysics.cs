using Microsoft.Xna.Framework;

namespace Cryo.Engine.Components.Physics
{
    public interface IPhysics
    {
        Rectangle GetRectangle();
        bool CollidesWith(IPhysics other);

        GameTexture GetTexture();
    }
}