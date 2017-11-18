using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

delegate void OnClickFunction();

namespace lazman
{
    class Button
    {

        Vector2 position;
        Vector2 textPosition;
        String text;
        SpriteFont spriteFont;
        Texture2D buttonImage;
        Texture2D hoverImage;
        Rectangle buttonRect;
        OnClickFunction function;
        Window parentWindow;

        public Button(String inText, OnClickFunction inOnClickFunction, Vector2 inPosition,
            Rectangle inButtonDimensions, int borderWidth, Color inBorderColor, Texture2D inButtonImage = null,
            Texture2D inHoverImage = null)
        {

            text = inText;
            spriteFont = ResourceManager.fonts["uiFont"];
            function = inOnClickFunction;
            buttonRect = inButtonDimensions;
            position = inPosition;
            buttonImage = inButtonImage;

            if (inButtonImage == null)
            {
                buttonImage = new Texture2D(Renderer.graphDevMan.GraphicsDevice, buttonRect.Width, buttonRect.Height);

                Color[] pixels = new Color[(buttonImage.Width * buttonImage.Height)];

                for (int i = 0; i < (buttonImage.Width * buttonImage.Height); i++)
                {
                    pixels[i] = Color.DimGray;
                }
                buttonImage.SetData<Color>(pixels);
            }

            // get the text position for the center of the button
            textPosition = new Vector2(position.X + buttonRect.Width / 2, position.Y + buttonRect.Height / 2);
            Vector2 textSize = spriteFont.MeasureString(text);
            textPosition = new Vector2(textPosition.X - textSize.X / 2, textPosition.Y - textSize.Y / 2);
        }

        public Rectangle ButtonRectangle {
            get { return new Rectangle((int)position.X, (int)position.Y, buttonRect.Width, buttonRect.Height); }
        }

        public void Draw()
        {
            Renderer.batch.Draw(buttonImage, position, Color.White);
            Renderer.batch.DrawString(spriteFont, text, textPosition, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
        }
        void DrawButtonText()
        {


        }

        public void SetParentWindow(Window inParentWindow)
        {
            parentWindow = inParentWindow;
        }

        public void OnClick()
        {
            if (function != null)
                function();
        }

        void CreateBorder(int borderWidth, Color inBorderColor, Color[] inPixels)
        {
            if (inBorderColor != Color.Transparent)
            {
                int verticalPasses = buttonImage.Height;
                for (int y = 0; y < verticalPasses; y++)
                {
                    for (int i = 0; i < borderWidth; i++)
                    {
                        inPixels[i + y * buttonImage.Width] = inBorderColor;
                        inPixels[y * buttonImage.Width + buttonImage.Width - 1 - i] = inBorderColor;
                    }
                }
            }
        }


    }
}
