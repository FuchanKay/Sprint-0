using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Scripts.GameComponents;

public class KeyboardInputManager(Dictionary<Inputs, KeyCondition> map) : IInputManager
{
    private readonly Dictionary<Inputs, KeyCondition> InputKeyStateMap = map;
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
        if (InputKeyStateMap.TryGetValue(input, out KeyCondition keyState))
        {
            return keyState.Current;
        }
        return false;
    }

    public bool IsPressed(Inputs input)
    {
        if (InputKeyStateMap.TryGetValue(input, out KeyCondition keyState))
        {
            return keyState.Current && !keyState.Previous;
        }
        return false;
    }

    public bool IsReleased(Inputs input)
    {
        if (InputKeyStateMap.TryGetValue(input, out KeyCondition keyState))
        {
            return !keyState.Current && keyState.Previous;
        }
        return false;
    }

    public void MapInput(Inputs input, int key)
    {
        var keyEnum = (Keys) key;
        if (!InputKeyStateMap.TryAdd(input, new KeyCondition(keyEnum)))
        {
            InputKeyStateMap[input] = new KeyCondition(keyEnum);
        }
    }
}