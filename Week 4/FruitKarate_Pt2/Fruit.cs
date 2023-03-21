using System;
using SplashKitSDK;

namespace MyGame
{
	public class Fruit
	{
        private FruitKind _kind;

        protected Point2D _position;
        private Vector2D _velocity;

        public Fruit()
        {
            _position.X = 0;
            _position.Y = SplashKit.ScreenHeight();

            _velocity.X = 3.0;
            _velocity.Y = -7.0 + SplashKit.Rnd(2) - 1;

            _kind = (FruitKind)SplashKit.Rnd(9);
        }

        public void Update()
        {
            // update the fruit's position
            _position.X += _velocity.X;
            _position.Y += _velocity.Y;
            // decay the velocity
            _velocity = SplashKit.VectorAdd(_velocity, SplashKit.VectorTo(0, 0.05));
        }

        public bool IsAt(Point2D pt)
        {
            return SplashKit.BitmapPointCollision(MyBitmap(), _position, pt);
        }

        public virtual void Draw()
        {
            SplashKit.DrawBitmap(MyBitmap(), _position.X, _position.Y);
        }

        public virtual bool Splat()
        {
            // play the appropriate sound effect, and return true if the fruit should be removed from the game
            SplashKit.PlaySoundEffect("Splat");
            return true;
        }

        protected Bitmap MyBitmap()
        {
            switch (_kind)
            {
                case FruitKind.Cherry:
                    return SplashKit.BitmapNamed("Cherry");
                case FruitKind.Gooseberry:
                    return SplashKit.BitmapNamed("Gooseberry");
                case FruitKind.Blueberry:
                    return SplashKit.BitmapNamed("Blueberry");
                case FruitKind.Pomegranate:
                    return SplashKit.BitmapNamed("Pomegranate");
                case FruitKind.Apricot:
                    return SplashKit.BitmapNamed("Apricot");
                case FruitKind.Raspberry:
                    return SplashKit.BitmapNamed("Raspberry");
                case FruitKind.Blackberry:
                    return SplashKit.BitmapNamed("Blackberry");
                case FruitKind.Strawberry:
                    return SplashKit.BitmapNamed("Strawberry");
                case FruitKind.Currant:
                    return SplashKit.BitmapNamed("Currant");
                default:
                    return SplashKit.BitmapNamed("Currant");
            }
        }
    }
}
