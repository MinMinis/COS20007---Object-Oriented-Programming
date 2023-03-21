using SplashKitSDK;

namespace Circle
{
    public class Circle
    {
        private double _x;
        private double _y;
        private double _radius;

        public Circle(double x, double y, double radius = 0)
        {
            _x = x;
            _y = y;
            _radius = radius;
        }

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public double Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public void Draw()
        {
            SplashKit.FillCircle(Color.White, X, Y, Radius);
            SplashKit.DrawCircle(Color.Black, X, Y, Radius);
        }

        public bool IsCollidingWith(Circle otherCircle)
        {
            double distance = Math.Sqrt(Math.Pow((X - otherCircle.X), 2) + Math.Pow((Y - otherCircle.Y), 2));
            double sumOfRadii = Radius + otherCircle.Radius;
            return distance <= sumOfRadii;
        }
    }
}
