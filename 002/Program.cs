using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002
{
    interface IRadius
    {
        double GetRadius();
    }
    interface IDadius
    {
        int GetDadius();
    }

    abstract class Figure
    {
        public double X { get; protected set; }
        public double Y { get; protected set; }

        public Figure(double x, double y)
        {
            X = x;
            Y = y;
        }
        abstract public double Area();
    }
    abstract class FigureWithoutCorners : Figure
    {
        public double Height { get; protected set; }
        public double Width { get; protected set; }

        public FigureWithoutCorners(double x, double y, double height, double width) : base(x, y)
        {
            Height = height;
            Width = width;
        }
    }
    class Circle : FigureWithoutCorners, IRadius, IDadius
    {
        public Circle(double x, double y, double height) : base(x, y, height, height)
        {
        }
        double IRadius.GetRadius()
        {
            return 20;
        }
        int IDadius.GetDadius()
        {
            return 777;
        }
        public override double Area()
        {
            return 3.14 / 4 * Height;
        }

    }
    class Ellipse : FigureWithoutCorners, IRadius
    {
        public Ellipse(double x, double y, double height, double width) : base(x, y, height, width)
        {
        }
        double IRadius.GetRadius()
        {
            return 15;
        }
        public override double Area()
        {
            return 3.14 * (Height / 2) * (Width / 2);
        }
    }
    abstract class FigureWithMultiCorners : Figure
    {
        public double Height { get; protected set; }
        public double Width { get; protected set; }

        public FigureWithMultiCorners (double x, double y, double height, double width) : base(x, y)
        {
            Height = height;
            Width = width;
        }
        public FigureWithMultiCorners(double x, double y, double width): base(x, y)
        {
            Width = width;
        }
    }
    // Треугольник
    class Triangle : FigureWithMultiCorners
    {
        public Triangle (double x, double y, double height, double width) : base(x, y, height, width)
        {
        }
        public override double Area()
        {
            return Height * Width / 2;
        }
    }
    // Квадрат
    class Quadrilateral : FigureWithMultiCorners
    {
        public Quadrilateral (double x, double y, double height, double width): base(x,y, height, width)
        {
        }
        public override double Area()
        {
            return Height * Width;
        }
    }
    // Правильный пятиуголник
    class Pentagon : FigureWithMultiCorners
    {
        public Pentagon (double x, double y, double width): base(x, y, width)
        {
        }
        public override double Area()
        {
            return (5 * Width * Width) / (4 * Math.Tan(180 / 5));
        }
    }
    class Program
    {
        static void FigureArea(Figure figure)
        {
            Console.WriteLine(figure.Area());
        }
        static void ShowRadius(Figure radius)
        {
            if (radius is IRadius)
            {
                Console.WriteLine(((IRadius)radius).GetRadius());
            }
            else
                Console.WriteLine("Не является кругом!");
        }
        static IRadius GetFigureRadius(Figure f)
        {
            if (f is IRadius)
                return ((IRadius)f);
            else
                return null;
        }

        static void Main(string[] args)
        {
            Figure[] figure = new Figure[3];
            figure[0] = new Circle(4, 5, 6);
            figure[1] = new Pentagon(1, 1, 13);
            figure[2] = new Triangle(1, 1, 8, 6);
            Circle c = new Circle(1, 1, 5);
            c.
            for (int i = 0; i < figure.Length; i++)
            {
                IRadius f = GetFigureRadius(figure[i]);
                if (f != null)
                    Console.WriteLine(((Circle)f).Area());
            }

            
            Console.ReadLine();
        }
    }
}
