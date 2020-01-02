using System;
using System.Drawing;

namespace GraphicsLabApp__2
{

    public abstract class Shape
    {
        protected PointF[] _points;
        public Shape(PointF[] points)
        {
            _points = (PointF[])points.Clone();
        }
        public void Rotate(int angleDegree, float i, float j)
        {
            for (int k = 0; k < _points.Length; k++)
            {
                float oldX = _points[k].X;
                float oldY = _points[k].Y;
                double angleRadian = angleDegree * Math.PI / 180;
                _points[k].X = (float)(Math.Cos(angleRadian) * (oldX - i) - Math.Sin(angleRadian) * (oldY - j) + i);
                _points[k].Y = (float)(Math.Sin(angleRadian) * (oldX - i) + Math.Cos(angleRadian) * (oldY - j) + j);

            }
        }

        public void Scale(float coeffX, float coeffY, float i, float j)
        {
            for (int k = 0; k < _points.Length; k++)
            {
                float oldX = _points[k].X;
                float oldY = _points[k].Y;
                _points[k].X = coeffX * (oldX - i) - coeffY * (oldY - j) * 0 + i;
                _points[k].Y = coeffX * (oldX - i) * 0 + coeffY * (oldY - j) + j;

            }
        }

        public void Translate(float dx, float dy)
        {
            for (int k = 0; k < _points.Length; k++)
            {
                float oldX = _points[k].X;
                float oldY = _points[k].Y;
                _points[k].X = oldX + dx;
                _points[k].Y = oldY + dy;

            }
        }
        public void FullTransform(float dx = 0, float dy = 0, float coeffX = 1, float coeffY = 1, int angleDegree = 0, float i = 0, float j = 0)
        {
            for (int k = 0; k < _points.Length; k++)
            {
                float oldX = _points[k].X;
                float oldY = _points[k].Y;
                double angleRadian = angleDegree * Math.PI / 180;
                _points[k].X = (float)((Math.Cos(angleRadian) * (oldX - i) * coeffX) - (Math.Sin(angleRadian) * (oldY - j) * coeffY) + i + dx);
                _points[k].Y = (float)((Math.Sin(angleRadian) * (oldX - i) * coeffX) + (Math.Cos(angleRadian) * (oldY - j) * coeffY) + j + dy);

            }
        }

        public PointF[] Points => (PointF[])_points.Clone();

    }

    public class Rectangle : Shape
    {
        public Rectangle(PointF startPoint, float height, float width)
            : base(new PointF[] { new PointF(startPoint.X, startPoint.Y), new PointF(startPoint.X + width, startPoint.Y), new PointF(startPoint.X + width, startPoint.Y + height), new PointF(startPoint.X, startPoint.Y + height) })
        {
        }
    }

    public class Square : Shape
    {
        public Square(PointF startPoint, float size)
            : base(new PointF[] { startPoint, new PointF(startPoint.X + size, startPoint.Y), new PointF(startPoint.X + size, startPoint.Y + size), new PointF(startPoint.X, startPoint.Y + size) })
        {
        }
    }

    public class Line : Shape
    {
        public Line(PointF startPoint, float endX, float endY)
            : base(new PointF[] { startPoint, new PointF(endX, endY) })
        {
        }
    }

    public class Polygon : Shape
    {
        public Polygon(params PointF[] points)
            : base((PointF[])points.Clone())
        {
        }
    }

    public class Circle : Shape
    {
        public Circle(PointF pointCenter, float radius)
            : base(new PointF[360])
        {
            for (int i = 0; i < 360; i++)
            {
                double angleRadian = i * Math.PI / 180;
                _points[i].X = (float)(pointCenter.X + radius * Math.Cos(angleRadian));
                _points[i].Y = (float)(pointCenter.Y + radius * Math.Sin(angleRadian));
            }
        }
    }

}
