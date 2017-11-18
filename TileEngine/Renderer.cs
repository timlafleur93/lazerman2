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
        static public GraphicsDeviceManager graphDevMan;
        static public SpriteBatch batch;
        static public RenderTarget2D renderTarget;
        static public void SetRendererReferences(SpriteBatch inBatch, GraphicsDeviceManager inGraphDevMan)
        {
            batch = inBatch;
            graphDevMan = inGraphDevMan;
            InitRenderTarget(new Point(640, 480));
            
        }

        static public void InitRenderTarget(Point dimensions)
        {
            renderTarget = new RenderTarget2D(graphDevMan.GraphicsDevice, dimensions.X,dimensions.Y);
        }

        static public void Render(GameTime time)
        {
            graphDevMan.GraphicsDevice.SetRenderTarget(renderTarget);
            graphDevMan.GraphicsDevice.Clear(Color.Black);
        }

    }
}
