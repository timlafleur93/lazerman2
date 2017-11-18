using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace lazman
{
    class Camera
    {

        public enum ScrollState { SCROLLING, FIXED }
        public ScrollState cameraState = ScrollState.SCROLLING;
        public enum ScrollDirection { UP, DOWN, LEFT, RIGHT, NONE }


        public Rectangle targetWindowRectangle = new Rectangle(0, 0, 640, 480);
        public Point screenDims = new Point(640, 480);
        public Rectangle cameraRect;

        Player playerRef;

        Vector2 position = new Vector2(0, 0);
        double moveSpeed = 2;

        public Camera()
        {
            cameraRect = new Rectangle(0, 0, screenDims.X, screenDims.Y);
        }


        public void SetPlayerReference(Player playr)
        {
            playerRef = playr;
        }

        public Rectangle ScreenRect {
            get {
                int x = (int)(Position.X / screenDims.X);
                int y = (int)(Position.Y / screenDims.Y);
                return new Rectangle(x, y, x + screenDims.X, y + screenDims.Y);
            }
        }

        public void Update(GameTime time)
        {
            Vector2 vel = Vector2.Zero;

            if (InputHandler.currentState.IsKeyDown(Keys.Left))
                vel.X = -1;
            if (InputHandler.currentState.IsKeyDown(Keys.Right))
                vel.X = 1;
            if (InputHandler.currentState.IsKeyDown(Keys.Up))
                vel.Y = -1;
            if (InputHandler.currentState.IsKeyDown(Keys.Down))
                vel.Y = 1;

            if (vel != Vector2.Zero)
                Move(vel, time);
        }

        public Vector2 Position {
            get { return position; }
            set {
                position = new Vector2(
                MathHelper.Clamp(value.X + position.X, Game1.WorldDims.X, Game1.WorldDims.Width - screenDims.X),
                MathHelper.Clamp(value.Y + position.Y, Game1.WorldDims.Y, Game1.WorldDims.Height - screenDims.Y));
            }
        }

        public void Move(Vector2 vel, GameTime time)
        {
            if (playerRef == null)
            {
                vel *= (float)(moveSpeed);// * time.ElapsedGameTime.TotalSeconds);
                //vel = vel * (float)time.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                vel = playerRef.velocity;
            }


            position = new Vector2(
              MathHelper.Clamp(vel.X + position.X,
                  LevelManager.currentLevel.levelWorldDims.X * TileEngine.tileDims.X, LevelManager.currentLevel.levelWorldDims.Width - screenDims.X),
              MathHelper.Clamp(vel.Y + position.Y,
                  LevelManager.currentLevel.levelWorldDims.Y * TileEngine.tileDims.Y, LevelManager.currentLevel.levelWorldDims.Height - screenDims.Y));
        }

    }
}
