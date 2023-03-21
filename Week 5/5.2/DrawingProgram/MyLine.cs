using SplashKitSDK;

namespace MyGame
{
    public class MyLine : Shape
    {
        private float _endX, _endY;
        public float EndX
        {
            get
            {
                return _endX;
            }
            set
            {
                _endX = value;
            }
        }
        public float EndY
        {
            get
            {
                return _endY;
            }
            set
            {
                _endY = value;
            }
        }
        public MyLine()
        {
            _endX = SplashKit.MouseX() + 50;
            _endY = SplashKit.MouseY() + 50;
            Color = SplashKit.ColorRed();
            X = SplashKit.MouseX();
            Y = SplashKit.MouseY();
        }
        public MyLine(Color color, float startX, float startY, float endX, float endY)
        {
            Color = color;
            X = startX;
            Y = startY;
            _endX = endX;
            _endY = endY;
        }
        public override void Draw()
        {
            if (Selected) DrawOutline();
            SplashKit.DrawLine(Color, X, Y, _endX, _endY);
            SplashKit.DrawLine(Color, X + 10, Y + 10, _endX, _endY);
        }
        public override void DrawOutline()
        {
            SplashKit.FillCircle(SplashKit.ColorBlack(), X, Y, 2); //draw circle at the start point
            SplashKit.FillCircle(SplashKit.ColorBlack(), EndX, EndY, 2); //draw circle at the end point
        }
        public override bool IsAt(Point2D pt)
        {
            // Use SplashKit.PointOnLine to check if the point is on the line
            Point2D startPoint = new() { X = X, Y = Y }; //define start point of line
            Point2D endPoint = new() { X = EndX, Y = EndY }; //define end point of line
            Line line = SplashKit.LineFrom(startPoint, endPoint); // define line

            if (SplashKit.PointOnLine(pt, line))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(EndX);
            writer.WriteLine(EndY);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            EndX = reader.ReadInteger();
            EndY = reader.ReadInteger();
        }
    }
}







