using Microsoft.Xna.Framework.Graphics;

namespace Scripts.GameComponents;

public interface IEntity
{
    void Update(IContext context, int dt);

    void Draw(SpriteBatch sb);
}