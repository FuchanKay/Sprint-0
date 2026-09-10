using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Scripts.GameComponents;

public class AppleHandler
{
    private readonly int AppleLimit = 50;
    private readonly List<Apple> Apples = [];
    
    public void Draw(SpriteBatch sb)
    {
        foreach (var apple in Apples)
        {
            apple.Draw(sb);
        }
    }

    public void AddApple(Apple apple)
    {
        Apples.Add(apple);
        if (Apples.Count > AppleLimit)
        {
            Apples.RemoveAt(0);
        }
    }

    public void ClearApples()
    {
        Apples.Clear();
    }

}
