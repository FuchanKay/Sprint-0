using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Scripts.GameComponents;

public class Controller : IController
{
    private IPlayer Player;
    public void Init()
    {
        Player = new ChickPlayer();
    }
    public void Update(int dt)
    {
        Player.Update(dt);
    }
    public void Draw(SpriteBatch sb)
    {
        Player.Draw(sb);
    }
}