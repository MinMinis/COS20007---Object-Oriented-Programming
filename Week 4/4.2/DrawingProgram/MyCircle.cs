using SplashKitSDK;
using Color = SplashKitSDK.Color;

namespace DrawingProgram
{
    public class MyCircle : Shape
    {
        private int _radius;
        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }
        public MyCircle()
        {
            X = 0;
            Y = 0;
            _radius = 50;
            Color = SplashKit.ColorBlue();
        }
        public MyCircle (Color color, int x , int y, int radius)
        {
            Color = color;
            X = x;
            Y = y;
            _radius = radius;
        }
        public override void Draw()
        {
            if (Selected) DrawOutline();
            SplashKit.FillCircle(Color, X, Y, _radius);
        }
        public override void DrawOutline() //overidde
        {
            SplashKit.FillCircle(SplashKit.ColorBlack(), X , Y, _radius + 2); //draw shape
        }
        public override bool IsAt(Point2D pt)
        {
             //check if the mouse point in the circle or not /  return the centered point of circle
            /*if (SplashKit.PointInCircle(pt, SplashKit.CircleAt(X + Radius, Y + Radius, Radius)))
            {
                return true;
            }
            else
            {
                return false;
            } */
            
            //Pythagorean theorem
            double distancex = pt.X - X; // x-coor and cirlce center
            double distancey = pt.Y - Y; // y-coor and circle center
            double distance = (distancex * distancex) + (distancey * distancey);
            double radius2 = (Radius * Radius);

            if (distance <= radius2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

