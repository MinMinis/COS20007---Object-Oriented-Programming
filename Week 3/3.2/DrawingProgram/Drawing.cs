using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram
{
    public class Drawing
    {
        public readonly List<Shape> _shapes;
        private Color _background;
        public Color Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
            }
        }
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        public Drawing() : this(Color.White) { }
        public List<Shape> SelectedShapes 
        { 
            get 
            {
                List<Shape> result = new();
                foreach (Shape s in _shapes)
                {
                    if (s.Selected == true)
                     {
                        result.Add(s);
                    }
                }
                return result;
            } 
        }
        public int ShapeCount
        {
            get
            {
                return _shapes.Count; 
            }
        }
        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
        }
        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt))
                {
                    s.Selected = true;
                }
                else
                {
                    s.Selected = false;
                }
            }
        }

        public void RemoveShape(Shape shape)
        {
            _shapes.Remove(shape);
        }

    }
}
