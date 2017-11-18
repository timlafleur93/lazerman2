using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace lazman
{
  static class Renderer
  {
    static GraphicsDeviceManager graphDevMan;
    static SpriteBatch batch;
    static public void SetRendererReferences(SpriteBatch inBatch, GraphicsDeviceManager inGraphDevMan)
    {
      batch = inBatch;
      graphDevMan = inGraphDevMan;
    }

    static public void Render(GameTime time)
    {
      graphDevMan.GraphicsDevice.Clear(Color.Black);
    }

  }
}
