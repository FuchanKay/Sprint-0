using Microsoft.Xna.Framework.Graphics;

namespace Scripts.GameComponents;

public interface IController
{
    void Init();

    void Update(int dt);

    void Draw(SpriteBatch sb);

}