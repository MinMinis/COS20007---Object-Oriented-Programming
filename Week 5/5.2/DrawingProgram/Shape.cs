using SplashKitSDK;

namespace MyGame
{
    public abstract class Shape
    {
        private bool _selected;
        private float _x, _y;
        private Color _color;
        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        public Shape()
        {
            _color = SplashKit.ColorYellow();
        }
        public Shape(Color color)
        {
            _color = color;
        }
        public abstract bool IsAt(Point2D pt);

        public abstract void DrawOutline();
        public abstract void Draw();

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteColor(Color);
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }
        public virtual void LoadFrom(StreamReader reader)
        {
            Color = reader.ReadColor();
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }
    }
}
