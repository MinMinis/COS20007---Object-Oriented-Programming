using SplashKitSDK;

namespace Circle
{
    public class Player : Circle
    {
        private double _size;

        public Player(double x, double y, double size) : base(x, y, size / 2)
        {
            _size = size;
        }

        public double Size
        {
            get { return _size; }
            set
            {
                _size = value;
                Radius = _size / 2;
            }
        }

        public void Move(double dx, double dy)
        {
            X += dx;
            Y += dy;
        }

        public void Draw()
        {
            SplashKit.FillCircle(Color.Blue, X, Y, Radius);
            SplashKit.DrawCircle(Color.Black, X, Y, Radius);
            SplashKit.DrawText(Size.ToString(), Color.White, X - 10, Y - 10);
        }
    }
}
