using SplashKitSDK;
using System.IO; 

namespace MyGame
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

        public void Save (string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            writer.WriteColor(Background);
            writer.WriteLine(ShapeCount);
            foreach (Shape s in _shapes)
            {
                s.SaveTo(writer);
            }
            writer.Close();
        }
        public void Load (string filename)
        {
            StreamReader reader = new StreamReader(filename);
            try
            {
                Background = reader.ReadColor();
                int count = reader.ReadInteger();
                Shape s;
                string kind;
                _shapes.Clear();
                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();
                    switch (kind)
                    {
                        case "Rectangle":
                            s = new MyRectangle();
                            break;
                        case "Circle":
                            s = new MyCircle();
                            break;
                        case "Line":
                            s = new MyLine();
                            break;
                        default:
                            throw new InvalidDataException("Uknown shape kind: " + kind);
                    }
                    s.LoadFrom(reader);
                    AddShape(s);
                }
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
