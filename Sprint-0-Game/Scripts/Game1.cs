using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using Scripts.Player;

namespace Scripts;

public class Game1 : Core
{
    private IPlayer Player;
    private Texture2D ChickTexture;
    private static readonly int ScreenWidth = 1280;
    private static readonly int ScreenHeight = 720;
    private static readonly bool IsFullScreen = false;
    private static readonly string WindowTitle = "Sprint-0-Game";

    public Game1() : base(WindowTitle, ScreenWidth, ScreenHeight, IsFullScreen)
    {
        
    }

    protected override void Initialize()
    {
        Player = new ChickPlayer();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        ChickTexture = Content.Load<Texture2D>("Images/chick");
        (Player as ChickPlayer).Texture = ChickTexture;
        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        Player.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);

        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin();

        // Draw the logo texture
        Player.Draw(SpriteBatch);

        // Always end the sprite batch when finished.
        SpriteBatch.End();


        base.Draw(gameTime);
    }
}
