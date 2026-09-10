using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Scripts.GameComponents;

public class Chick : IPlayer
{
    private static readonly int TextureWidth = 128;
    private static readonly int TextureHeight = 140;
    private static int LeftBoundary;
    private static int TopBoundary;
    private static int RightBoundary;
    private static int BottomBoundary;
    private readonly float PlayerSpeed = 8;
    private readonly float DiagonalSpeedCoefficient = MathF.Sqrt(2.0f) / 2.0f;
    private readonly int TextureSwapRate = 100;
    private bool Moving;
    public static Texture2D Texture { get; set; }
    private Rectangle TextureRect;
    private int AnimationMs;
    private Directions Direction;
    public Vector2 Coord;
    public Chick()
    {
        Moving = false;
        AnimationMs = 0;
        Coord = new Vector2(0, 0);
        TextureRect = new Rectangle(0, 0, TextureWidth, TextureHeight);
        Direction = Directions.East;
    }

    public void Update(IContext c, int dt)
    {
        var context = c as ChickContext;
        Moving = IsMoving(context.N, context.E, context.S, context.W);
        if (!Moving)
        {
            return;
        }
        switch (Direction)
        {
            case Directions.North:
                HandleMove(context.W, context.N, context.E, context.S);
                break;
            case Directions.East:
                HandleMove(context.N, context.E, context.S, context.W);
                break;
            case Directions.South:
                HandleMove(context.E, context.S, context.W, context.N);
                break;
            case Directions.West:
                HandleMove(context.S, context.W, context.N, context.E);
                break;
            default:
                break;
        }
        if (Moving)
        {
            AnimationMs += dt;
        }
        UpdateTextureRect();
    }

    public void Draw(SpriteBatch sb)
    {
        sb.Draw(
            Texture,
            Coord,
            TextureRect,
            Color.White,
            0f,
            Vector2.Zero,
            1.0f,
            SpriteEffects.None,
            0.0f
        );
    }

    private static bool IsMoving(bool n, bool e, bool s, bool w)
    {
        return ((n || e || s || w) && (n || !e || s || !w) && (!n || e || !s || w));
    }

    private void HandleMove(bool left, bool front, bool right, bool back)
    {
        var couldRotate = !front && (left || back || right);
        if (couldRotate)
        {
            HandleRotation(left, back, right);
        }
        Move(left, back, right);
    }

    private void HandleRotation(bool left, bool back, bool right)
    {
        if (left && !back && !right)
        {
            Direction = Utilities.RotateLeft(Direction);
        }
        else if (!left && back && !right)
        {
            Direction = Utilities.Rotate180(Direction);
        }
        else if (!left && !back && right)
        {
            Direction = Utilities.RotateRight(Direction);
        }
    }

    private void Move(bool left, bool back, bool right)
    {
        var mainStride = PlayerSpeed;
        var sideStride = 0.0f;
        if (left && !right && !back)
        {
            mainStride = PlayerSpeed * DiagonalSpeedCoefficient;
            sideStride = -PlayerSpeed * DiagonalSpeedCoefficient;
        }
        if (!left && right && !back)
        {
            mainStride = PlayerSpeed * DiagonalSpeedCoefficient;
            sideStride = PlayerSpeed * DiagonalSpeedCoefficient;
        }
        if (back)
        {
            mainStride = 0;
        }

        switch (Direction)
        {
            case Directions.North:
                Coord.Y -= mainStride;
                Coord.X += sideStride;
                break;
            case Directions.East:
                Coord.X += mainStride;
                Coord.Y += sideStride;
                break;
            case Directions.South:
                Coord.Y += mainStride;
                Coord.X -= sideStride;
                break;
            case Directions.West:
                Coord.X -= mainStride;
                Coord.Y -= sideStride;
                break;
            default:
                break;
        }

        CheckBoundaries();
    }

    private void UpdateTextureRect()
    {
        var animationFrame = 0;
        if (AnimationMs % (TextureSwapRate * 2) > TextureSwapRate)
        {
            animationFrame = 1;
        } 
        var textureXOffset = GetTextureOffset(animationFrame);

        TextureRect = new Rectangle(textureXOffset, 0, TextureWidth, TextureHeight);
    }

    private int GetTextureOffset(int animationFrame)
    {
        var animationOffset = animationFrame * TextureWidth;
        var directionOffset = (int) Direction * TextureWidth * 2;

        return directionOffset + animationOffset;
    }

    private void CheckBoundaries()
    {
        if (Coord.X < LeftBoundary)
        {
            Coord.X = LeftBoundary;
        }
        if (Coord.X > RightBoundary)
        {
            Coord.X = RightBoundary;
        }
        if (Coord.Y < TopBoundary)
        {
            Coord.Y = TopBoundary;
        }
        if (Coord.Y > BottomBoundary)
        {
            Coord.Y = BottomBoundary;
        }
    }

    public static void SetPlayerBoundaries(int screenWidth, int screenHeight)
    {
        LeftBoundary = 0;
        TopBoundary = 0;
        RightBoundary = screenWidth - TextureWidth;
        BottomBoundary = screenHeight - TextureHeight;
    }
}