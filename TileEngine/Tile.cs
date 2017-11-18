using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace lazman
{
    class TileUnit
    {
        public TileUnit(TileArt inTileArt)
        {
            tileArt = inTileArt;
        }

        public TileArt tileArt;

        delegate void Update();

        delegate void DrawTileUnit(Vector3 position);

        public void Draw(Vector2 position)
        {
            Renderer.batch.Draw(
            tileArt.texture,
            position,
            tileArt.frames[tileArt.currentFrame],
            Color.White);
        }
    }

    public struct TileArt
    {
        public TileArt(Texture2D inTexture, float inFrameRate, int numOfFrames, int inCurrentFrame)
        {
            texture = inTexture;
            framerate = inFrameRate;
            frames = new List<Rectangle>();
            currentFrame = inCurrentFrame;

            int framesX, framesY;

            framesX = texture.Width / TileEngine.tileDims.X;
            framesY = texture.Height / TileEngine.tileDims.Y;

            bool getFramesComplete = false;

            for(int y = 0; y < framesY || !getFramesComplete; y++)
            {
                for (int x = 0; x < framesX || !getFramesComplete; x++)
                {
                    frames.Add(new Rectangle(x * TileEngine.tileDims.X,
                                                y * TileEngine.tileDims.Y,
                                                TileEngine.tileDims.X, TileEngine.tileDims.Y));
                    if(frames.Count >= numOfFrames)
                    {
                        getFramesComplete = true;
                    }
                }
            }

        }
        public Texture2D texture;
        public List<Rectangle> frames;
        public float framerate;
        public int currentFrame;
    }
}
