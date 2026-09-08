using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Scripts.Player;

public interface IPlayer
{
    void Update(GameTime dt);

    void Draw(SpriteBatch sb);
}