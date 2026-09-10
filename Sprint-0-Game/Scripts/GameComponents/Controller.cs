using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Scripts.GameComponents.Input;

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
        Dictionary<Inputs, KeyCondition> InputKeyStateMap = new()
        {
            {Inputs.WalkNorth, new KeyCondition(Keys.W)},
            {Inputs.WalkEast, new KeyCondition(Keys.D)},
            {Inputs.WalkSouth, new KeyCondition(Keys.S)},
            {Inputs.WalkWest, new KeyCondition(Keys.A)},
            {Inputs.ExitGame, new KeyCondition(Keys.Escape)}
        };

        Dictionary<Inputs, ButtonCondition> InputMouseButtonMap = new()
        {
            {Inputs.SpawnApple, new ButtonCondition(MouseButtons.Left)}
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

        var spawnApple = MouseInput.IsPressed(Inputs.SpawnApple);

        Chick.HandleInputs(walkN, walkE, walkS, walkW);
        Chick.Update(dt);
    }
    public void Draw(SpriteBatch sb)
    {
        Chick.Draw(sb);
    }
}