using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace Keyboard_Input_and_Mouse_Events
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        KeyboardState keyboardState;
        MouseState mouseState;

        Texture2D pacRightTexture, pacLeftTexture, pacUpTexture, pacDownTexture, pacSleepTexture;

        Texture2D currentPacTexture;
        Rectangle pacRect;

        Texture2D exitTexture;
        Rectangle exitRect;

        Texture2D barrierTexture;
        Rectangle barrierRect1, barrierRect2;

        Texture2D coinTexture;
        Rectangle coinRect;

        int pacSpeed;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            pacRect = new Rectangle(10, 10, 75, 75);

            barrierRect1 = new Rectangle(0, 250, 350, 75);
            barrierRect2 = new Rectangle(450, 250, 350, 75);

            coinRect = new Rectangle(400, 50, coinTexture.Width, coinTexture.Height);
            exitRect = new Rectangle(700, 380, 100, 100);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            pacRightTexture = Content.Load<Texture2D>("PacRight");
            pacLeftTexture = Content.Load<Texture2D>("PacLeft");
            pacUpTexture = Content.Load<Texture2D>("PacUp");
            pacDownTexture = Content.Load<Texture2D>("PacDown");
            pacSleepTexture = Content.Load<Texture2D>("PacSleep");
            currentPacTexture = pacRightTexture;

            barrierTexture = Content.Load<Texture2D>("rockBarrier");
            coinTexture = Content.Load<Texture2D>("coin");
            exitTexture = Content.Load<Texture2D>("hobbitDoor");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                pacRect.Y -= 2;
                currentPacTexture = pacUpTexture;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                pacRect.Y += 2;
                currentPacTexture = pacDownTexture;

            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                pacRect.X -= 2;
                currentPacTexture = pacLeftTexture;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                pacRect.X += 2;
                currentPacTexture = pacRightTexture;
            }
            
            if (pacRect.Intersects(coinRect))
            {
                coinRect.Location = new Point(800, 480);
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(currentPacTexture, pacRect, Color.White);
            _spriteBatch.Draw(barrierTexture, barrierRect1, Color.White);
            _spriteBatch.Draw(barrierTexture, barrierRect2, Color.White);
            _spriteBatch.Draw(exitTexture, exitRect, Color.White);
            _spriteBatch.Draw(coinTexture, coinRect, Color.White);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}