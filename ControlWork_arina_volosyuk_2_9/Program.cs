using System;

namespace ControlWork_arina_volosyuk_2_9
{
    public interface IGraph
    {
        int First();
    }
    public class Point : IComparable, IGraph
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int First()
        {
            return (X > 0 && Y > 0 && Z > 0) ? 1 : 0;
        }
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        }
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }
        public int CompareTo(object obj)
        {
            if (obj is Point other)
            {
                int thisDistance = X * X + Y * Y + Z * Z;
                int OtherDistance = other.X * other.Y + other.Y * other.Z;
                return thisDistance.CompareTo(OtherDistance);
            }
            throw new ArgumentException("объект не найден");
        }
        public override string ToString()
        {
            return $"Point {X},{Y},{Z}";
        }
    }
    public class Line
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }

        public Line(Point p1, Point p2)
        {
            Point1 = p1;
            Point2 = p2;
        }
        public override string ToString()
        {
            return $"линия из Point1 ({Point1}) в Point2 ({Point2})";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //1a
            Console.WriteLine("Введите 1 число:");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите 2 число:");
            int num2 = int.Parse(Console.ReadLine());

            int sum = num1 + num2;

            string result = $"Сумма числел {num1} и {num2} равна {sum}";
            Console.WriteLine(result);
            //1б
            string[,] massiv = { { "конфеты, бананы" }, { "заяц" } };
            int TotalCountLetters = 0;
            foreach (var word in massiv)
            {
                TotalCountLetters += word.Length;
            }
            Console.WriteLine(TotalCountLetters);

            //2
            Point p1 = new Point(4, 4, 6);
            Point p2 = new Point(1, 2, 3);

            Point summa = p1 + p2;
            Point difference = p1 - p2;


            Console.WriteLine(difference);
            Console.WriteLine(summa.ToString());

            int compation = p1.CompareTo(p2);
            if (compation > 0)
            {
                Console.WriteLine("1 больше");
            }
            else if (compation < 0)
            {
                Console.WriteLine("2 больше");
            }
            else
            {
                Console.WriteLine("1 и 2 равны");
            }
            //3
            Console.WriteLine($"p1 находится в четверти {p1.First()}");
            Console.WriteLine($"p2 находится в четверти {p2.First()}");
            Line Line = new Line(p1, p2);
            Console.WriteLine(Line);

        }
    }
}
