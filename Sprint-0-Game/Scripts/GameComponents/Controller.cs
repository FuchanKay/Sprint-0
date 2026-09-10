using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Scripts.GameComponents.Input;

namespace Scripts.GameComponents;

public class Controller : IController
{
    public bool ShouldExit { get; set; }
    private AppleHandler Apples;
    private Chick Chick;
    private KeyboardInputManager KeyboardInput;
    private MouseInputManager MouseInput;
    public void Init()
    {
        Chick = new Chick();
        Apples = new AppleHandler();

        Dictionary<Inputs, KeyCondition> InputKeyStateMap = [];
        Dictionary<Inputs, ButtonCondition> InputMouseButtonMap = [];

        KeyboardInput = new KeyboardInputManager(InputKeyStateMap);
        MouseInput =  new MouseInputManager(InputMouseButtonMap);

        KeyboardInput.MapInput(Inputs.WalkNorth, (int) Keys.W);
        KeyboardInput.MapInput(Inputs.WalkEast, (int) Keys.D);
        KeyboardInput.MapInput(Inputs.WalkSouth, (int) Keys.S);
        KeyboardInput.MapInput(Inputs.WalkWest, (int) Keys.A);
        KeyboardInput.MapInput(Inputs.ExitGame, (int) Keys.Escape);

        MouseInput.MapInput(Inputs.SpawnApple, (int) MouseButtons.Left);
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
        if (spawnApple)
        {
            var x = MouseInput.X();
            var y = MouseInput.Y();
            var apple = new Apple(x, y);
            Apples.AddApple(apple);

        }

        Chick.HandleInputs(walkN, walkE, walkS, walkW);
        Chick.Update(dt);
    }
    public void Draw(SpriteBatch sb)
    {
        Apples.Draw(sb);
        Chick.Draw(sb);
    }
}