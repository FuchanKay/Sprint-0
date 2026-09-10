using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Scripts.GameComponents;

public class Apple
{
    private static readonly int TextureWidth = 64;
    private static readonly Vector2 TextureCenter = new Vector2(TextureWidth / 2, TextureWidth / 2);
    public static Texture2D Texture { get; set; }
    private readonly float MinimumScale = 0.5f;
    private readonly float Scale;
    private Vector2 Coord;
    public Apple(int x, int y)
    {
        var random = new Random();
        Coord = new(x, y);
        Scale = (float) random.NextDouble() + MinimumScale;
    }

    public void Draw(SpriteBatch sb)
    {
        sb.Draw(
            Texture,
            Coord,
            new Rectangle(0, 0, TextureWidth, TextureWidth),
            Color.White,
            0f,
            TextureCenter,
            Scale,
            SpriteEffects.None,
            0.0f
        );
    }
}
