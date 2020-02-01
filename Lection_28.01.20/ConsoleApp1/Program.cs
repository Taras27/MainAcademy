using System;

namespace ConsoleApp1
{
    public class Printer
    {
        public virtual void WriteLine(string content)
        {
            Console.WriteLine(content);
        }
    }

    public class ColoredPrinter : Printer
    {
        public  ColoredPrinter(ConsoleColor foregroundColor, ConsoleColor backforegroundColor)
        {
            ForegroundColor = foregroundColor;
            BackforegroundColor = backforegroundColor;
        }
        public ConsoleColor ForegroundColor { get; }
        public ConsoleColor BackforegroundColor { get; }

        public sealed override void WriteLine(string content)
        {
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackforegroundColor;
            base.WriteLine(content);
            Console.ResetColor();
        }
        public override string ToString()
        {
            return nameof(ColoredPrinter);
        }        
    }

    public sealed class DecoratedPrinter : ColoredPrinter
    {
        public DecoratedPrinter (char decorator, ConsoleColor foregroundColor, 
            ConsoleColor backroundColor) : base(foregroundColor,backroundColor)
            {
                Decorator = decorator;
            }

        public char Decorator { get;  }
        public new void WriteLine(string content)
        {
            Console.WriteLine(new string (Decorator, content.Length));
            base.WriteLine(content);
            Console.WriteLine(new string(Decorator, content.Length));
        }
        public override string ToString()
        {
            return nameof(DecoratedPrinter);
        }
    }
    class User
    {
        public string name { get; set; }
        public int age { get; set; }

        public User()
        {
                
        }
    }

    class Tmp 
    {
        public void PrintData ()
        {
            Printer colored = new ColoredPrinter(ConsoleColor.Black, ConsoleColor.Red);
            colored.WriteLine("Colored output");

            Printer decoratedPrinter = new DecoratedPrinter('*', ConsoleColor.Yellow, ConsoleColor.Green);
            decoratedPrinter.WriteLine("Decorated5");

            Console.WriteLine("Printer type is:" + colored);
            Console.WriteLine("Printer type is:" + decoratedPrinter);
        }        
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Tmp TmpData = new Tmp();
            //TmpData.PrintData();
            //AbstractClass.ShowDemo();

        }
    }
}
