
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimpleAnimationNamespace;

namespace Assignment_01;

public class Game1 : Game
{

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    // Static Objects

        // Mario
            private Texture2D _marioHead;
            public float marioScale = 0.25f;
        // Background
            private Texture2D _backGroundClouds;
            private float backGroundScale = 0.4f;
        // Sample Text
            private SpriteFont _comicSans;
            private string _output = "The quick brown fox jumped over the lazy dog";

    // Animated Objects

        // Sonic
            private Vector2 sonicPosition;
            private SimpleAnimation _sonicAnimation;
        // Coin
            private Vector2 coinPosition;
            private SimpleAnimation _coinAnimation;

    
    

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        // Sets Window Borders
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 320;
            _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here


        // Loads the mario Head
            _marioHead = Content.Load<Texture2D>("Mario");

        // Loads the Background
            _backGroundClouds = Content.Load<Texture2D>("Background");

        // Loads the Font
            _comicSans = Content.Load<SpriteFont>("SansFont");

        // Loads the Sonic SpriteSheet
            _sonicAnimation = new SimpleAnimation(
                Content.Load<Texture2D>("Sonic"),
                132,
                155,
                4,
                8
            );

        // Sets Sonics Y position to the bottom of the screen
            sonicPosition.Y = 175f;


        // Loads the Coin Spritesheet
            _coinAnimation = new SimpleAnimation(
                Content.Load<Texture2D>("Coin"),
                168,
                148,
                4,
                8
            );

        // Sets the Coins Position to the middle of the screen
            coinPosition.X = 320;
            coinPosition.Y = 160;
        
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

     


        // Updates the position of the moving sprites
            _sonicAnimation.Update(gameTime);
            _coinAnimation.Update(gameTime);

        // Increases Sonics X position every update
            sonicPosition.X += 10;

        // Checks if Sonic is past the wall to teleport him back to the left 
            if(sonicPosition.X > 620f)
            {
                sonicPosition.X = -20f;
            }


        
        // Moves Up
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                coinPosition.Y -= 4;
            }
        // Moves Down
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                coinPosition.X -= 4;
            }
        // Moves Left
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                coinPosition.Y += 4;
            }
        // Moves Right
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                coinPosition.X += 4;
            }

        base.Update(gameTime);

    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        // TODO: Add your drawing code here

        //Draws a Background
            _spriteBatch.Draw(_backGroundClouds, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, backGroundScale, SpriteEffects.None, 0.1f);

        // Draws a Static Sprite of Mario
            _spriteBatch.Draw(_marioHead, new Vector2(520, 5), null, Color.White, 0f, Vector2.Zero, marioScale, SpriteEffects.None, 0.2f);

        // Draws test Font
            _spriteBatch.DrawString(_comicSans,_output, new Vector2(15,10), Color.Black);

        // Draws an Animated Sprite of Sonic
            _sonicAnimation.Draw(_spriteBatch, sonicPosition, SpriteEffects.None);

        // Draws an Animated Sprite of a Coin for User Control
            _coinAnimation.Draw(_spriteBatch, coinPosition, SpriteEffects.None);

        _spriteBatch.End();

        base.Draw(gameTime);

       
    }
}
