using Scripts.Enums;

namespace Scripts.GameComponents;

public class Utilities
{
    public static Directions RotateLeft(Directions direction)
    {
        return direction switch
        {
            Directions.North => Directions.West,
            Directions.East => Directions.North,
            Directions.South => Directions.East,
            Directions.West => Directions.South,
            _ => Directions.East,
        };
    }

    public static Directions RotateRight(Directions direction)
    {
        return direction switch
        {
            Directions.North => Directions.East,
            Directions.East => Directions.South,
            Directions.South => Directions.West,
            Directions.West => Directions.North,
            _ => Directions.East,
        };   
    }
    public static Directions Rotate180(Directions direction)
    {
        return direction switch
        {
            Directions.North => Directions.South,
            Directions.East => Directions.West,
            Directions.South => Directions.North,
            Directions.West => Directions.East,
            _ => Directions.East,
        };   
    }
}