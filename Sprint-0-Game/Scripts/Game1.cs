using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;

namespace Scripts;

public class Game1 : Core
{

    private Texture2D _tetrisClub;

    private static readonly int ScreenWidth = 1280;
    private static readonly int ScreenHeight = 720;
    private static readonly bool IsFullScreen = false;
    private static readonly string WindowTitle = "Sprint-0-Game";
    public Game1() : base(WindowTitle, ScreenWidth, ScreenHeight, IsFullScreen)
    {
        
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _tetrisClub = Content.Load<Texture2D>("Images/tetris_logo");
        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);

        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin();

        // Draw the logo texture
        // SpriteBatch.Draw(_tetrisClub, Vector2.Zero, Color.White);
        SpriteBatch.Draw(
            _tetrisClub,
            Vector2.Zero,
            null,
            Color.White,
            0f,
            Vector2.Zero,  
            0.25f,
            SpriteEffects.None,
            0.0f
        );

        // Always end the sprite batch when finished.
        SpriteBatch.End();


        base.Draw(gameTime);
    }
}
