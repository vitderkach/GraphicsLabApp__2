using System.Collections.Generic;
using System.Linq;

namespace GraphicsLabApp__2
{
    internal class ComplexFigure
    {

        private Figure[] _figures;
        private List<(string, bool)> _activeFigures;

        private string Name { get; }
        public ComplexFigure(string name, Figure figure, params Figure[] figures)
        {
            _activeFigures = new List<(string, bool)>();
            Name = name;
            _figures = new Figure[figures.Length + 1];
            _figures[0] = figure;
            _activeFigures.Add((figure.Name, true));
            for (int i = 1; i < _figures.Length; i++)
            {
                _figures[i] = figures[i - 1];
                _activeFigures.Add((_figures[i].Name, true));
            }
        }

        public void RotateComlexFigure(int angleDegree, float i, float j)
        {
            foreach (var figure in _activeFigures)
            {
                if (figure.Item2 == true)
                {
                    _figures.First(f => f.Name == figure.Item1).Rotate(angleDegree, i, j);
                }
            }
        }

        public void TranslateComplexFigure(float dx, float dy)
        {
            foreach (var figure in _activeFigures)
            {
                if (figure.Item2 == true)
                {
                    _figures.First(f => f.Name == figure.Item1).Translate(dx, dy);
                }
            }
        }

        public void ScaleComplexFigure(float coeffX, float coeffY, float i, float j)
        {
            foreach (var figure in _activeFigures)
            {
                if (figure.Item2 == true)
                {
                    _figures.First(f => f.Name == figure.Item1).Scale(coeffX, coeffY, i, j);
                }
            }
        }

        public bool SetFigureState(string name, bool isActive)
        {
            var result = _activeFigures.FirstOrDefault(af => af.Item1 == name);
            if (!result.Equals(default))
            {
                _activeFigures.Remove(result);
                _activeFigures.Add((name, isActive));
                return true;
            }
            return false;
        }

        public Figure[] Figures => (Figure[])_figures.Clone();
    }
}