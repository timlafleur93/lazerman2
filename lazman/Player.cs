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
  class Player
  {
    public float moveSpeed = 5f;
    public Vector2 velocity;
    Vector2 position;
    Rectangle playerRect;
    Texture2D playerTex;

    public Player(Vector2 pos, Texture2D playerTex)
    {
      Position = pos;
      this.playerTex = playerTex;
    }

    public Vector2 Position
    {
      get { return position;}
      set 
      { 
        position = new Vector2(
          MathHelper.Clamp(position.X + value.X, Game1.WorldDims.X,Game1.WorldDims.Width - playerRect.Width),
          MathHelper.Clamp(position.Y + value.Y, Game1.WorldDims.Y,Game1.WorldDims.Height - playerRect.Height));
      }
    }

    public Vector2 CenterPoint
    {
      get { return new Vector2(position.X + playerRect.Width/2, position.Y + playerRect.Height / 2);}
    }

    public void Update()
    {
      velocity = Vector2.Zero;

      if (InputHandler.currentState.IsKeyDown(Keys.Left))
        velocity.X = -1;
      if (InputHandler.currentState.IsKeyDown(Keys.Right))
        velocity.X = 1;
      if (InputHandler.currentState.IsKeyDown(Keys.Up))
        velocity.Y = -1;
      if (InputHandler.currentState.IsKeyDown(Keys.Down))
        velocity.Y = 1;
      velocity *= moveSpeed;

     // Move();
    }
    
    public void Draw(SpriteBatch batch)
    {
      batch.Draw(playerTex, Position, Color.White);
    }

    public void Move()
    {
      position = new Vector2(
          MathHelper.Clamp(position.X + velocity.X, Game1.WorldDims.X, Game1.WorldDims.Width - playerRect.Width),
          MathHelper.Clamp(position.Y + velocity.Y, Game1.WorldDims.Y, Game1.WorldDims.Height - playerRect.Height));
    }

    public Camera.ScrollDirection checkScreenBounds(Camera inCam)
    {
      Camera.ScrollDirection direction = Camera.ScrollDirection.NONE;

      if(CenterPoint.X > inCam.ScreenRect.Width)
        direction = Camera.ScrollDirection.RIGHT;
      if (CenterPoint.X < inCam.ScreenRect.X)
        direction = Camera.ScrollDirection.LEFT;
      if (CenterPoint.Y > inCam.ScreenRect.Height)
        direction = Camera.ScrollDirection.DOWN;
      if (CenterPoint.Y < inCam.ScreenRect.Y)
        direction = Camera.ScrollDirection.UP;

        return direction;
    }
  }
}
