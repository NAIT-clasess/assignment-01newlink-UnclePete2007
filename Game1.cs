using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimpleAnimationNamespace;

namespace Assignment_01;

public class Game1 : Game
{

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _backGroundClouds;

    private SimpleAnimation _sonicAnimation;

    private Texture2D _marioHead;

    private SpriteFont _comicSans;

    private string _output = "The quick brown fox jumped over the lazy dog";

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _graphics.PreferredBackBufferWidth = 640;
        _graphics.PreferredBackBufferHeight = 320;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here

        _marioHead = Content.Load<Texture2D>("Mario");

        _backGroundClouds = Content.Load<Texture2D>("Background");

        _comicSans = Content.Load<SpriteFont>("SansFont");

        _sonicAnimation = new SimpleAnimation(
            Content.Load<Texture2D>("Sonic"),
            132,
            145,
            4,
            8
        );
        
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here


        _sonicAnimation.Update(gameTime);

        base.Update(gameTime);

    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        // TODO: Add your drawing code here

        //Draws a Background
        _spriteBatch.Draw(_backGroundClouds, Vector2.Zero, Color.White);

        // Draws a Static Sprite of Mario
        _spriteBatch.Draw(_marioHead, new Vector2(300, 140), Color.White);

        // Draws test Font
        _spriteBatch.DrawString(_comicSans,_output, new Vector2(20,200), Color.White);

        // Draws an Animated Sprite of Sonic
        _sonicAnimation.Draw(_spriteBatch, new Vector2(100, 200), SpriteEffects.None);

        _spriteBatch.End();

        base.Draw(gameTime);

       
    }
}
