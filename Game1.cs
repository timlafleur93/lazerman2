using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace lazman
{


    public enum GameState { MainMenu, LevelEditor, GameMode};

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        static public Rectangle WorldDims = new Rectangle(0, 0, 6400, 4800);
        FPSCounter frameCounter;


        Camera player1Cam = new Camera();

        static GameState currentState = GameState.MainMenu;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            graphics.SynchronizeWithVerticalRetrace = true;
            //graphics.IsFullScreen = true;
            graphics.PreferredBackBufferHeight = 480;
            graphics.PreferredBackBufferWidth = 640;

            graphics.ApplyChanges();




            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ResourceManager.setContentRef(Content);
            Renderer.SetRendererReferences(spriteBatch, graphics);
            TileEngine.Init();
            TileEngine.AddCamera("player1", player1Cam);
            LevelManager.Init();

            WindowManager.Init(this);
            frameCounter.Init();

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            frameCounter.Update(gameTime);

            InputHandler.Update();

            switch (currentState)
            {
                case GameState.GameMode:
                    player1Cam.Update(gameTime);
                    break;
                case GameState.MainMenu:
                    WindowManager.UpdateCurrentWindow();
                    break;

                case GameState.LevelEditor:
                    player1Cam.Update(gameTime);
                    break;
            }




            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Renderer.Render(gameTime);

            switch (currentState)
            {
                case GameState.GameMode:
                    Renderer.batch.Begin();



                    TileEngine.Draw(gameTime);
                    Renderer.batch.End();
                    break;
                case GameState.MainMenu:
                    Renderer.batch.Begin();
                    WindowManager.DrawCurrentWindow();
                    Renderer.batch.End();
                    break;

                case GameState.LevelEditor:
                    Renderer.batch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);



                    TileEngine.Draw(gameTime);

                    Editor.DrawEditor();
                    frameCounter.Draw(gameTime, new Vector2(680,30));
                    Renderer.batch.End();
                    break;
            }



            // TODO: Add your drawing code here
            Renderer.graphDevMan.GraphicsDevice.SetRenderTarget(null);
            Renderer.batch.Begin(SpriteSortMode.Texture, null, SamplerState.PointClamp);
            Renderer.batch.Draw(Renderer.renderTarget, graphics.GraphicsDevice.Viewport.Bounds, Color.White);
            Renderer.batch.End();

            base.Draw(gameTime);
        }

        // Utility Functions
        public void EnterEditorMode()
        {
            Editor.Init();

            currentState = GameState.LevelEditor;

            graphics.PreferredBackBufferHeight = 480;
            graphics.PreferredBackBufferWidth = 880;
            graphics.SynchronizeWithVerticalRetrace = true;
            //graphics.PreferMultiSampling = false;
            GraphicsDevice.PresentationParameters.PresentationInterval = PresentInterval.One;
          
            graphics.ApplyChanges();

            Renderer.InitRenderTarget(new Point(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));
        }
    }
}
