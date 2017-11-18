using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace lazman
{
    static class Editor
    {
        static Window backgroundWindow;


        static public void Init()
        {
            backgroundWindow = new Window(new Rectangle(640, 0, 240, 480), true, true, new Color(.3f,.3f,.3f,1.0f));
        }

        static public void DrawEditor()
        {
            backgroundWindow.Draw();

            UI_Text.DrawString(ResourceManager.fonts["uiFont"], "Sprite position",
                new Vector2(backgroundWindow.dimensions.X + (backgroundWindow.dimensions.Width * .05f), 10f));
        }

        static public void UpdateEditor()
        {
            
        }

    }
}
