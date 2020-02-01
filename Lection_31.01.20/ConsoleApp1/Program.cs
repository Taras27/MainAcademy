using System;
using System.Linq;
using ConsoleApp1.Operators;

namespace ConsoleApp1
{

    public static class PointExtension
    {
        public static void Print(this Point point)
        {
            PointPrinter.Instance.PrintToConsole(point);
        }
    }
    public class Point
    {
        static Point() { }
        private Point() { }
        public static Point CreateEmpty() => new Point();
        public static Point CreateNew(int x, int y)
        {
            var point = new Point { X = x, Y = y };
            return point;
        }
        public static Point Shared { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class PointPrinter
    {
        private static PointPrinter _instance;
        private PointPrinter() { }
        public static PointPrinter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PointPrinter();
                }
                return _instance;
            }
        }
        public void PrintToConsole(Point point) => Console.WriteLine($"X={point.X}, Y={point.Y}");
    }
    public class Static
    {
        public static void Main()
        {
            var p = Point.CreateEmpty();
            Point.Shared = Point.CreateNew(10, 20);
            p.Print();
            var newPoint = Point.CreateEmpty();
            PointExtension.Print(newPoint);

            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7 };
            var maxNum = numbers.Max();
            var minNum = numbers.Min();
            var evenNums = numbers.Where(n => n % 2 == 0).ToArray();
            var strings = numbers.Select(n => n.ToString()).ToArray();

            OperatorOverLoading.ShowDemo();
        }
    }
}