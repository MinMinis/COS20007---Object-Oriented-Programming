using SplashKitSDK;
using Color = SplashKitSDK.Color;

namespace MyGame
{
    public class MyRectangle : Shape
    {
        private int _width, _height;
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }
        public MyRectangle()
        {
            X = 0;
            Y = 0;
            Width = 100;
            Height = 100;
            Color = SplashKit.ColorGreen();
        }
        public MyRectangle(Color clr, float x, float y, int width, int height) : base(clr)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public override void Draw()
        {
            if (Selected) { DrawOutline(); }
            SplashKit.FillRectangle(Color, X, Y, Width, Height); //draw shape
        }
        public override void DrawOutline()
        {
            SplashKit.FillRectangle(SplashKit.ColorBlack(), X - 2, Y - 2, Width + 4, Height + 4); //draw shape
        }
        public override bool IsAt(Point2D pt) //the result return bool so need to set bool here, pt is param
        {
            if (pt.X >= X && pt.X <= X + Width && pt.Y >= Y && pt.Y <= Y + Height)
            // mouse x-coor >= shape x-coor && mouse x-coor <= shape x-coor + shape width 
            // mouse y-coor >= shape y-coor && mouse y-coor <= shape y-coor + height
            {
                return true; // before was true
            }
            else
            {
                return false;
            }
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(Width);
            writer.WriteLine(Height);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
        }
    }
}
