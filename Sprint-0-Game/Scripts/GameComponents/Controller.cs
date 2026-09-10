using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Scripts.GameComponents.Entity;
using Scripts.GameComponents.Input;

namespace Scripts.GameComponents;

public class Controller : IController
{
    public bool ShouldExit { get; set; }
    private Apple CursorApple;
    private AppleHandler Apples;
    private Chick Chick;
    private KeyboardInputManager KeyboardInput;
    private MouseInputManager MouseInput;
    private Random Random;

    public void Init()
    {
        Random = new();
        Chick = new Chick();
        Apples = new AppleHandler();

        Dictionary<Inputs, KeyCondition> InputKeyStateMap = [];
        Dictionary<Inputs, MouseButtonCondition> InputMouseButtonMap = [];

        KeyboardInput = new KeyboardInputManager(InputKeyStateMap);
        MouseInput =  new MouseInputManager(InputMouseButtonMap);

        CursorApple = new Apple(MouseInput.X(), MouseInput.Y(), Random);

        MapDefaultKeyboardKeyBinds();
        MapDefaultMouseKeyBinds();
    }

    public void Update(int dt)
    {
        KeyboardInput.Update();
        MouseInput.Update();

        CheckExitGame();

        UpdateAppleCursor();

        CheckSpawnApple();
        CheckClearApple();

        var chickContext = CreateChickContext();
        Chick.Update(chickContext, dt);
    }

    public void Draw(SpriteBatch sb)
    {
        Apples.Draw(sb);
        Chick.Draw(sb);
        CursorApple.Draw(sb);
    }

    private void MapDefaultKeyboardKeyBinds()
    {
        KeyboardInput.MapInput(Inputs.WalkNorth, (int) Keys.W);
        KeyboardInput.MapInput(Inputs.WalkEast, (int) Keys.D);
        KeyboardInput.MapInput(Inputs.WalkSouth, (int) Keys.S);
        KeyboardInput.MapInput(Inputs.WalkWest, (int) Keys.A);
        KeyboardInput.MapInput(Inputs.ExitGame, (int) Keys.Escape);
    }

    private void MapDefaultMouseKeyBinds()
    {
        MouseInput.MapInput(Inputs.SpawnApple, (int) MouseButtons.Left);
        MouseInput.MapInput(Inputs.ClearApples, (int) MouseButtons.Right);
    }

    private void CheckExitGame()
    {
        var exitGame = KeyboardInput.IsHeld(Inputs.ExitGame);
        ShouldExit = exitGame;
    }

    private void CheckSpawnApple()
    {
        var spawnApple = MouseInput.IsPressed(Inputs.SpawnApple);
        if (spawnApple)
        {
            var x = MouseInput.X();
            var y = MouseInput.Y();
            Apples.AddApple(CursorApple);
            CursorApple = new Apple(MouseInput.X(), MouseInput.Y(), Random);
        }
    }

    private void CheckClearApple()
    {
        var clearApple = MouseInput.IsPressed(Inputs.ClearApples);
        if (clearApple)
        {
            Apples.ClearApples();
        }
    }

    private void UpdateAppleCursor()
    {
        CursorApple.Coord = new Vector2(MouseInput.X(), MouseInput.Y());
    }

    private ChickContext CreateChickContext()
    {
        return new ChickContext(
            KeyboardInput.IsHeld(Inputs.WalkNorth),
            KeyboardInput.IsHeld(Inputs.WalkEast),
            KeyboardInput.IsHeld(Inputs.WalkSouth),
            KeyboardInput.IsHeld(Inputs.WalkWest)
        );
    }
}