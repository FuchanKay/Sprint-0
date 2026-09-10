using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Scripts.GameComponents.Input;

public class MouseInputManager(Dictionary<Inputs, ButtonCondition> map) : IInputManager
{
    private readonly Dictionary<Inputs, ButtonCondition> InputButtonStateMap = map;

    public void Update()
    {
        foreach (var inputButtonState in InputButtonStateMap)
        {
            var buttonState = inputButtonState.Value;
            var mouse = Mouse.GetState();
            
            buttonState.Previous = buttonState.Current;
            switch (buttonState.Button)
            {
                case MouseButtons.Left:
                    buttonState.Current = mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed;
                    break;
                case MouseButtons.Right:
                    buttonState.Current = mouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed;
                    break;
                case MouseButtons.Middle:
                    buttonState.Current = mouse.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed;
                    break;
                default: 
                    break;
            }
        }
    }
    public int X()
    {
        return Mouse.GetState().Position.X;
    }

    public int Y()
    {
        return Mouse.GetState().Position.Y;
    }

    public bool IsHeld(Inputs input)
    {
        if (InputButtonStateMap.TryGetValue(input, out var buttonState))
        {
            return buttonState.Current;
        }
        return false;
    }

    public bool IsPressed(Inputs input)
    {
        if (InputButtonStateMap.TryGetValue(input, out var buttonState))
        {
            return !buttonState.Previous && buttonState.Current;
        }
        return false;   
    }

    public bool IsReleased(Inputs input)
    {
        if (InputButtonStateMap.TryGetValue(input, out var buttonState))
        {
            return buttonState.Previous && !buttonState.Current;
        }
        return false;
    }

    public void MapInput(Inputs input, int button)
    {
        var buttonEnum = (MouseButtons) button;
        if (!InputButtonStateMap.TryAdd(input, new ButtonCondition(buttonEnum)))
        {
            InputButtonStateMap[input] = new ButtonCondition(buttonEnum);
        }
    }
}