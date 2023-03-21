using SplashKitSDK;

namespace Circle
{
    internal class Food : Circle
    {
        private double _size;

        public Food(double x, double y, double size) : base(x, y, size / 2)
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

        public void Draw()
        {
            SplashKit.FillCircle(Color.Green, X, Y, Radius);
            SplashKit.DrawCircle(Color.Black, X, Y, Radius);
            SplashKit.DrawText(Size.ToString(), Color.White, X - 10, Y - 10);
        }
    }
}
