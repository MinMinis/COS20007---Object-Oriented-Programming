using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram
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

    }
}
