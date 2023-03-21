using System;
using SplashKitSDK;

namespace Circle
{
    public class Game
    {
        private readonly Window _gameWindow;
        private readonly Bitmap _background;
        private Circle _playerCircle;
        private Circle[] _enemyCircles;
        private const int EnemyCircleCount = 10;

        public Game()
        {
            _gameWindow = new Window("Circle Game", 800, 600);
            _background = new Bitmap("background", "background.png");
            _playerCircle = new Circle(400, 300, 20, Color.Green);
            _enemyCircles = new Circle[EnemyCircleCount];
            for (int i = 0; i < EnemyCircleCount; i++)
            {
                _enemyCircles[i] = Circle.RandomCircle(800, 600);
            }
        }

        public void Run()
        {
            while (!_gameWindow.CloseRequested)
            {
                SplashKit.ProcessEvents();
                HandleInput();
                Update();
                Draw();
            }

            _gameWindow.Close();
        }

        private void HandleInput()
        {
            if (SplashKit.KeyDown(KeyCode.UpKey))
            {
                _playerCircle.Move(0, -5);
            }

            if (SplashKit.KeyDown(KeyCode.DownKey))
            {
                _playerCircle.Move(0, 5);
            }

            if (SplashKit.KeyDown(KeyCode.LeftKey))
            {
                _playerCircle.Move(-5, 0);
            }

            if (SplashKit.KeyDown(KeyCode.RightKey))
            {
                _playerCircle.Move(5, 0);
            }
        }

        private void Update()
        {
            foreach (Circle enemyCircle in _enemyCircles)
            {
                enemyCircle.MoveRandomly();
            }

            foreach (Circle enemyCircle in _enemyCircles)
            {
                if (_playerCircle.IsCollidingWith(enemyCircle))
                {
                    _playerCircle.Grow(5);
                    enemyCircle.Reset();
                }
            }
        }

        private void Draw()
        {
            _gameWindow.DrawBitmap(_background, 0, 0);
            _playerCircle.Draw();
            foreach (Circle enemyCircle in _enemyCircles)
            {
                enemyCircle.Draw();
            }

            _gameWindow.Refresh();
        }
    }

    public class Circle
    {
        private double _x;
        private double _y;
        private double _radius;
        private Color _color;

        public Circle(double x, double y, double radius, Color color)
        {
            _x = x;
            _y = y;
            _radius = radius;
            _color = color;
        }

        public double X => _x;
        public double Y => _y;
        public double Radius => _radius;

        public void Draw()
        {
            SplashKit.FillCircle(_color, _x, _y, _radius);
        }

        public bool IsCollidingWith(Circle otherCircle)
        {
            double distanceBetweenCenters = SplashKit.DistanceBetween(_x, _y, otherCircle.X, otherCircle.Y);
            double sumOfRadii = _radius + otherCircle.Radius;
            return distanceBetweenCenters <= sumOfRadii;
        }

        public void Move(double dx, double dy)
        {
            _x += dx;
            _y += dy;
        }

        public static Circle RandomCircle(int maxWidth, int maxHeight)
        {
            Random rand = new Random();
            double x = rand.Next(0, maxWidth);
            double y = rand.Next(0, maxHeight);
            double radius = rand.Next(10, 50);
            Color color = Color.RandomRGB(rand.Next(0, 256), rand.Next(
