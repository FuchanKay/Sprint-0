using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Scripts.Enums;

namespace Scripts.GameComponents;

public class KeyboardInputManager : IInputManager
{
    private readonly Dictionary<Inputs, KeyState> InputKeyStateMap;
    public KeyboardInputManager(Dictionary<Inputs, KeyState> map)
    {
        InputKeyStateMap = map;
    }
    public void Update()
    {
        foreach (var inputKeyState in InputKeyStateMap)
        {
            var keyState = inputKeyState.Value;
            keyState.Previous = keyState.Current;
            keyState.Current = Keyboard.GetState().IsKeyDown(keyState.Key);
        }
    }
    public bool IsHeld(Inputs input)
    {
        if (InputKeyStateMap.TryGetValue(input, out KeyState keyState))
        {
            return keyState.Current;
        }
        return false;
    }

    public bool IsPressed(Inputs input)
    {
        if (InputKeyStateMap.TryGetValue(input, out KeyState keyState))
        {
            return keyState.Current && !keyState.Previous;
        }
        return false;
    }

    public bool IsReleased(Inputs input)
    {
        if (InputKeyStateMap.TryGetValue(input, out KeyState keyState))
        {
            return !keyState.Current && keyState.Previous;
        }
        return false;
    }

    public void MapInput(Inputs input, int key)
    {
        var keyEnum = (Keys) key;
        if (!InputKeyStateMap.TryAdd(input, new KeyState(keyEnum)))
        {
            InputKeyStateMap[input] = new KeyState(keyEnum);
        }
    }
}