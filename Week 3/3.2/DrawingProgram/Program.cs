using System;
using SplashKitSDK;

namespace DrawingProgram
{
    public class Program
    {
        public static void Main()
        { 
            Drawing myDraw = new();
            Window window = new("Shape Drawer 2", 800, 600); //draw window
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.White);
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape myShape = new()
                    {
                        X = SplashKit.MouseX(), //change the myShape's X value
                        Y = SplashKit.MouseY() //change the myShape's Y value
                    };
                    myDraw.AddShape(myShape);
                }
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDraw.Background = SplashKit.RandomColor();
                }
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDraw.SelectShapesAt(SplashKit.MousePosition());
                }
                List<Shape> select = new();
                select = myDraw.SelectedShapes;
                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape s in select)
                    {
                        myDraw.RemoveShape(s);
                    }
                }
                myDraw.Draw();
                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("Shape Drawer 2")) ;
        }
        
    }
}
