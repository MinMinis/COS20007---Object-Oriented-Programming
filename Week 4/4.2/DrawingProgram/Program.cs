using System;
using SplashKitSDK;

namespace DrawingProgram
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }
        public static void Main()
        {
            ShapeKind kindToAdd = ShapeKind.Circle;
            Drawing myDraw = new();
            Window window = new("Shape Drawer 3", 800, 600); //draw window
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.White);
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape myShape;
                    if (kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle myCircle = new();
                        myShape = myCircle;
                    } 
                    else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle myRect = new();
                        myShape = myRect;
                    }
                    else
                    {
                        MyLine myLine = new();
                        myShape = myLine;
                    }
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
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
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }
                myDraw.Draw();
                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("Shape Drawer 3"));
        }
    }
}
