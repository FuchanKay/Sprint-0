namespace Scripts.GameComponents.Input;

using Microsoft.Xna.Framework.Input;
using Scripts.Enums;
public interface IInputManager
{
    void Update();
    bool IsHeld(Inputs input);
    bool IsPressed(Inputs input);
    bool IsReleased(Inputs input);
    void MapInput(Inputs input, int button);
}
