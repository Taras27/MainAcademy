using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Operators
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get;  }
        public int Y { get;  }

        public bool Equals(Point point) => X == point.X && Y == point.Y;
        public override bool Equals(object o) => o is Point p && Equals(p);
        public static bool operator ==(Point left, Point right) => left.Equals(right);
        public static bool operator !=(Point left, Point right) => !(left==right);

        public static Point operator +(Point left, Point right) =>
            new Point(left.X + right.X, left.Y+right.Y);
        public static Point operator -(Point left, Point right) =>
            new Point(left.X - right.X, left.Y - right.Y);

        public static implicit operator Point (int i)
        {
            int value = (int)Math.Sqrt(i);
            return new Point(value, value);
        }

        public static explicit operator int (Point p) => p.X * p.Y;
    }

    public class ValidatedPoint  //соло на клавіатурі
    {
        private readonly Point _point;
        public ValidatedPoint(Point point) => _point = point;
        public static bool operator true(ValidatedPoint p) =>
            p._point.X > 0 || p._point.Y > 0;

        public static bool operator false(ValidatedPoint p) =>
            p._point.X <= 0 || p._point.Y <= 0;
    }

    public class OperatorOverLoading
    {
        public static void ShowDemo()
        {
            Point fromInt32 = 4;
            int value = (int)fromInt32;
            var p1 = new Point(0, 5);
            var p2 = new Point(10, 20);
            var areEquals = p1 == p2;
            var p3 = p1+p2;

            var valid = new ValidatedPoint(p3);

        }
    }
}
