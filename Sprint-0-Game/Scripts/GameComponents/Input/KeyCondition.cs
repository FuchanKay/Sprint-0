using Microsoft.Xna.Framework.Input;

namespace Scripts.GameComponents;

public class KeyCondition(Keys key)
{
    public Keys Key { get; } = key;
    public bool Previous { get; set; } = false;
    public bool Current { get; set; } = false;
}