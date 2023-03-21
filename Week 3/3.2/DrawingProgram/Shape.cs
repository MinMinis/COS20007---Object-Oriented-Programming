using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram
{
    public class Shape
    {
        private bool _selected;
        private float _x, _y;
        private int _width, _height;
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
            _x = 0;
            _y = 0;
            _width = 50;
            _height = 50;
            _color = SplashKit.ColorGreen();
        }
        public Shape(Color color, float x, float y, int width, int height)
        {
            _color = color;
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }
        public void Draw()
        {
            if (_selected == true)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(_color, _x, _y, _width, _height); //draw shape
        }

        public bool IsAt(Point2D pt) //the result return bool so need to set bool here, pt is param
        {
            if ((((pt.X >= _x) && (pt.X <= (_x + _width))) && (pt.Y >= _y) && (pt.Y <= (_y + _height))))
            // mouse x-coor >= shape x-coor && mouse x-coor <= shape x-coor + shape width 
            // mouse y-coor >= shape y-coor && mouse y-coor <= shape y-coor + height
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DrawOutline()
        {
            SplashKit.FillRectangle(SplashKit.ColorBlack(), _x - 2, _y - 2, _width + 4, _height + 4); //draw shape
        }
    }
}
