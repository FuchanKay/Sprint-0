using Microsoft.Xna.Framework.Graphics;

namespace Scripts.GameComponents;

public interface IPlayer
{
    void Update(int dt);

    void Draw(SpriteBatch sb);
}