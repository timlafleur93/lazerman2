using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace lazman
{
    public struct FPSCounter {
        SpriteFont font;
        int totalFrames;
        float elapsedTime;
        int fps;
        public void Init(){
            font = ResourceManager.fonts["uiFont"];
            totalFrames = 0;
            elapsedTime = 0;
            fps = 0;
        }

        public void Update(GameTime inTime)
        {
            elapsedTime += (float)inTime.ElapsedGameTime.TotalMilliseconds;

            if(elapsedTime >= 1000.0f){
                fps = totalFrames;
                totalFrames = 0;
                elapsedTime = 0;
            }
        }

        public void Draw(GameTime inTime, Vector2 position){
            totalFrames++;
            Renderer.batch.DrawString(font, string.Format("FPS {0}", fps), position, Color.LimeGreen);
        }

    };

    public struct Utilities
    {
        static public bool PointIntersectsRectangle(Point point, Rectangle rect)
        {
            if (point.X < rect.X)
                return false;
            else if (point.X > rect.X + rect.Width)
                return false;
            else if (point.Y < rect.Y)
                return false;
            else if (point.Y > rect.Y + rect.Width)
                return false;

            return true;
        }

        static public void EnterEditorMode(){
            
        }

    };

}
