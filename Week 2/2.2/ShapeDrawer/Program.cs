using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Shape myShape = new Shape();
            Window window = new Window("Shape Drawer", 800, 600); //draw window
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                myShape.Draw(); //after clear screen
                if (SplashKit.MouseClicked(MouseButton.LeftButton)) //mouse left clicked
                {
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                    myShape.Color = SplashKit.ColorGreen(); // color change to green
                }
                if (myShape.IsAt(SplashKit.MousePosition()))
                {
                    if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                    {
                        myShape.Color = SplashKit.RandomColor();
                    }
                }
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
