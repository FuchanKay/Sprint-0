using System;
using System.Diagnostics.Contracts;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Scripts.Enums;
using Scripts.Player;

namespace Scripts.Player;

public class ChickPlayer : IPlayer
{
    private readonly int TextureWidth = 128;
    private readonly int TextureSwapRate = 250;
    public Texture2D Texture { get; set;}
    private Rectangle TextureRect;
    private int AnimationMs;
    private Direction Direction;
    public Vector2 Coord {get; set;}
    public ChickPlayer()
    {
        AnimationMs = 0;
        Coord = new Vector2(0, 0);
        TextureRect = new Rectangle(0, 0, TextureWidth, TextureWidth);
        Direction = Direction.East;
    }
    public void Update(GameTime dt)
    {
        AnimationMs += dt.ElapsedGameTime.Milliseconds;
    }

    public void Draw(SpriteBatch sb)
    {
        UpdateTextureRect();
        sb.Draw(
            Texture,
            Vector2.Zero,
            TextureRect,
            Color.White,
            0f,
            Coord,  
            1.0f,
            SpriteEffects.None,
            0.0f
        );
    }

    private void UpdateTextureRect()
    {
        var animationToggle = AnimationMs % (TextureSwapRate * 2) > TextureSwapRate;
        var textureXOffset = GetTextureOffset(animationToggle);
        TextureRect = new Rectangle(textureXOffset, 0, TextureWidth, TextureWidth);
    }

    private int GetTextureOffset(bool animationToggle)
    {
        var animationOffset = animationToggle ? 1 : 0;
        return TextureWidth * ((int) Direction * 2 + animationOffset);
    }
}