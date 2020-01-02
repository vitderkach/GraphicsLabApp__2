namespace GraphicsLabApp__2
{

    public class Figure
    {
        private Shape[] _shapes;
        public string Name { get; }


        public Figure(string name, Shape shape, params Shape[] shapes)
        {
            _shapes = new Shape[shapes.Length + 1];
            _shapes[0] = shape;
            Name = name;
            for (int i = 1; i < _shapes.Length; i++)
            {
                _shapes[i] = shapes[i - 1];
            }
        }

        public void FullTransform(float dx, float dy, float coeffX, float coeffY, int angleDegree, float i, float j)
        {
            foreach (var shape in _shapes)
            {
                shape.FullTransform(dx, dy, coeffX, coeffY, angleDegree, i, j);
            }
        }

        public void Scale(float coeffX, float coeffY, float i, float j)
        {
            foreach (var shape in _shapes)
            {
                shape.Scale(coeffX, coeffY, i, j);
            }
        }

        public void Rotate(int angleDegree, float i, float j)
        {
            foreach (var shape in _shapes)
            {
                shape.Rotate(angleDegree, i, j);
            }
        }

        public void Translate(float dx, float dy)
        {
            foreach (var shape in _shapes)
            {
                shape.Translate(dx, dy);
            }
        }

        public Shape[] Shapes => (Shape[])_shapes.Clone();
    }
}
