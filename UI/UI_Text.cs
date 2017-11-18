using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace lazman
{
    static class UI_Text
    {

        static public void DrawString(SpriteFont inSpriteFont, string inString, Vector2 inPosition)
        {
            Renderer.batch.DrawString(inSpriteFont, inString, inPosition, Color.White);
        }
    }
}
