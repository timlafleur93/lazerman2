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
    class Window
    {
        bool detectClicks;
        public Rectangle dimensions;
        public Texture2D windowBackground;
        public Dictionary<string, Window> childWindows;
        public Dictionary<string, Button> buttons;
        public string nextWindow;
        public string previousWindow;
        bool drawBackground;
        Color windowColor;

        public Window(Rectangle dimensions, bool inDrawBackGround, bool inDetectClicks, Color inColor,
            string inNextWindow = null, string inPreviousWindow = null, Texture2D inBackground = null)
        {
            this.dimensions = dimensions;
            drawBackground = inDrawBackGround;
            detectClicks = inDetectClicks;
            buttons = new Dictionary<string, Button>();
            nextWindow = inNextWindow;
            previousWindow = inPreviousWindow;
            windowColor = inColor;

            if (inBackground == null)
            {
                windowBackground = new Texture2D(Renderer.graphDevMan.GraphicsDevice, dimensions.Width, dimensions.Height);

                Color[] pixels = new Color[windowBackground.Bounds.Width * windowBackground.Bounds.Height];

                for (int i = 0; i < (windowBackground.Bounds.Width * windowBackground.Bounds.Height); i++)
                {
                    pixels[i] = inColor;
                }

                windowBackground.SetData(pixels);
            }

        }

        public void Draw()
        {
            if (drawBackground)
                Renderer.batch.Draw(windowBackground, new Vector2(dimensions.X, dimensions.Y), Color.White);

            for (int i = 0; i < buttons.Count; i++)
                buttons.ElementAt(i).Value.Draw();
        }

        public void HandleUIInputs()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    if (Utilities.PointIntersectsRectangle(Mouse.GetState().Position, buttons.ElementAt(i).Value.ButtonRectangle))
                    {
                        buttons.ElementAt(i).Value.OnClick();
                    }
            }
        }


        public void AddButton(string inKey, Button inButton)
        {
            inButton.SetParentWindow(this);
            if (childWindows != null)
            {
                buttons.Add(inKey, inButton);
            }
            else
            {
                buttons = new Dictionary<string, Button>();
                buttons.Add(inKey, inButton);
            }
        }

        public void AddWindow(string inKey, Window inWindow)
        {
            if (childWindows != null)
            {
                childWindows.Add(inKey, inWindow);
            }
            else
            {
                childWindows = new Dictionary<string, Window>();
                childWindows.Add(inKey, inWindow);
            }
        }


    }
}
