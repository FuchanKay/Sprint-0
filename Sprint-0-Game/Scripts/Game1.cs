using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using Scripts.GameComponents;

namespace Scripts;

public class Game1 : Core
{
    private Controller Controller;
    private static readonly int ScreenWidth = 1280;
    private static readonly int ScreenHeight = 720;
    private static readonly bool IsFullScreen = false;
    private static readonly string WindowTitle = "Sprint-0-Game";

    public Game1() : base(WindowTitle, ScreenWidth, ScreenHeight, IsFullScreen)
    {
        
    }

    protected override void Initialize()
    {
        Controller = new Controller();
        Controller.Init();

        Chick.SetPlayerBoundaries(ScreenWidth, ScreenHeight);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        BindAllTextures();
        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        Controller.Update(gameTime.ElapsedGameTime.Milliseconds);
        if (Controller.ShouldExit)
        {
            Exit();
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);

        SpriteBatch.Begin();
        Controller.Draw(SpriteBatch);
        SpriteBatch.End();

        base.Draw(gameTime);
    }

    private void BindAllTextures()
    {
        Chick.Texture = Content.Load<Texture2D>("Images/chick");
    }
}
