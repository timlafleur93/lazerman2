using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace lazman
{
    static class WindowManager
    {
        static public Window currentWindow;
        static Dictionary<string, Window> windows;
        static Game1 game1Reference;

        static public void Init(Game1 inGame1)
        {
            game1Reference = inGame1;
            windows = new Dictionary<string, Window>();

            windows.Add("mainMenu",
                new Window(new Rectangle(0, 0, Renderer.graphDevMan.PreferredBackBufferWidth,
                Renderer.graphDevMan.PreferredBackBufferHeight), false, true, Color.Transparent, "mainMenu2"));
            windows["mainMenu"].AddButton("button1",
                new Button("Editor", game1Reference.EnterEditorMode, new Vector2(320, 240), new Rectangle(0, 0, 100, 50), 2, Color.Transparent));
            currentWindow = windows["mainMenu"];

            windows.Add("mainMenu2",
                new Window(new Rectangle(0, 0, Renderer.graphDevMan.PreferredBackBufferWidth,
                    Renderer.graphDevMan.PreferredBackBufferHeight), true, true, 
                    new Color(.3f,.3f,.3f,1.0f), null, "mainMenu"));
            windows["mainMenu2"].AddButton("MainMenuButton2",
                new Button("Back", WindowManager.GoToPreviousWindow, new Vector2(100, 100), new Rectangle(0, 0, 200, 100), 0, Color.Transparent));
        }

        static public void SetCurrentWindow(string inKey)
        {
            currentWindow = windows[inKey];
        }

        static public void GoToNextWindow()
        {
            SetCurrentWindow(currentWindow.nextWindow);
        }

        static public void GoToPreviousWindow()
        {
            SetCurrentWindow(currentWindow.previousWindow);
        }

        static public void DrawCurrentWindow()
        {
            currentWindow.Draw();
        }

        static public void UpdateCurrentWindow()
        {
            currentWindow.HandleUIInputs();
        }

    }
}
