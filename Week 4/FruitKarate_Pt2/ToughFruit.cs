using System;
using SplashKitSDK;

namespace MyGame
{
    public class ToughFruit : Fruit
    {
        private int _lives;

        public ToughFruit() : base()
        {
            _lives = 3;
        }

        public override void Draw()
        {
            base.Draw();

            Bitmap myImg = MyBitmap();

            switch (_lives)
            {
                case 3:
                    SplashKit.FillRectangle(Color.RGBAColor(0, 255, 0, 100), _position.X, _position.Y, myImg.Width, myImg.Height);
                    break;
                case 2:
                    SplashKit.FillRectangle(Color.RGBAColor(0, 255, 255, 100), _position.X, _position.Y, myImg.Width, myImg.Height);
                    break;
                case 1:
                    SplashKit.FillRectangle(Color.RGBAColor(255, 0, 0, 100), _position.X, _position.Y, myImg.Width, myImg.Height);
                    break;
            }
        }

        public override bool Splat()
        {
            base.Splat();
            _lives--;

            return _lives == 0;
        }
    }
}
