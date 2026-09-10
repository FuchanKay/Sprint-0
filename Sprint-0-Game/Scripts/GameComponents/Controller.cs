using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Scripts.Enums;

namespace Scripts.GameComponents;

public class Controller : IController
{
    public bool ShouldExit { get; set; }
    private Chick Chick;
    private KeyboardInputManager KeyboardInput;
    private MouseInputManager MouseInput;
    public void Init()
    {
        Chick = new Chick();
        Dictionary<Inputs, KeyState> InputKeyStateMap = new()
        {
            {Inputs.WalkNorth, new KeyState(Keys.W)},
            {Inputs.WalkEast, new KeyState(Keys.D)},
            {Inputs.WalkSouth, new KeyState(Keys.S)},
            {Inputs.WalkWest, new KeyState(Keys.A)},
            {Inputs.ExitGame, new KeyState(Keys.Escape)}
        };

        Dictionary<Inputs, ButtonState> InputMouseButtonMap = new()
        {
            {Inputs.SpawnApple, new ButtonState(MouseButtons.Left)}
        };

        KeyboardInput = new KeyboardInputManager(InputKeyStateMap);
        MouseInput =  new MouseInputManager(InputMouseButtonMap);
    }
    public void Update(int dt)
    {
        KeyboardInput.Update();
        MouseInput.Update();
        
        var exitGame = KeyboardInput.IsHeld(Inputs.ExitGame);
        ShouldExit = exitGame;

        var walkN = KeyboardInput.IsHeld(Inputs.WalkNorth);
        var walkE = KeyboardInput.IsHeld(Inputs.WalkEast);
        var walkS = KeyboardInput.IsHeld(Inputs.WalkSouth);
        var walkW = KeyboardInput.IsHeld(Inputs.WalkWest);

        var spawnApple = MouseInput.IsReleased(Inputs.SpawnApple);
        
        Chick.HandleInputs(walkN, walkE, walkS, walkW);
        Chick.Update(dt);
    }
    public void Draw(SpriteBatch sb)
    {
        Chick.Draw(sb);
    }
}