using Microsoft.Xna.Framework.Input;

namespace Scripts.GameComponents.Input;

public class KeyCondition(Keys key)
{
    public Keys Key { get; } = key;
    public bool Previous { get; set; } = false;
    public bool Current { get; set; } = false;
}