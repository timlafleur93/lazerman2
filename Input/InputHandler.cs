using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace lazman
{
  static class InputHandler
  {
    
    static public KeyboardState currentState;
    static KeyboardState previousState;

    static public void Update()
    {
      previousState = currentState;

      currentState = Keyboard.GetState();
    }

    static public bool FreshPress(Keys inKey)
    {
      if (currentState.IsKeyDown(inKey) && previousState.IsKeyUp(inKey)) {
        return true;
      } else return false;
    }

  }
}
