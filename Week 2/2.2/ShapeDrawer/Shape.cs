using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Shape
    {
        private Color _color;
        private float _x, _y;
        private int _width, _height;
        public Shape()
        {
            _x = 0; //the x-coor position
            _y = 0; // the y--coor position
            _height = 50; // height of object
            _width = 100; // width of object
            _color = SplashKit.ColorGreen(); // the original color when first appear
            // SET UP for creating shape
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
        public void Draw()
        {
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
    }
}
