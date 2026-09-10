using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Scripts.GameComponents;

public class Apple : IEntity
{
    private static readonly int TextureWidth = 64;
    private static readonly Vector2 TextureCenter = new(TextureWidth / 2, TextureWidth / 2);
    public static Texture2D Texture { get; set; }
    private readonly Rectangle TextureRect;
    private readonly float MinimumScale = 0.5f;
    private readonly float Scale;
    public Vector2 Coord { get; set; }
    public Apple(int x, int y, Random r)
    {
        Coord = new(x, y);
        Scale = RandomizeScale(r);
        TextureRect = new Rectangle(0, 0, TextureWidth, TextureWidth);
    }

    public void Update(IContext c, int dt)
    {
        return;
    }

    public void Draw(SpriteBatch sb)
    {
        sb.Draw(
            Texture,
            Coord,
            TextureRect,
            Color.White,
            0f,
            TextureCenter,
            Scale,
            SpriteEffects.None,
            0.0f
        );
    }

    private float RandomizeScale(Random r)
    {
        return (float) r.NextDouble() + MinimumScale;
    }
}
