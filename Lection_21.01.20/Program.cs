using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class demoClass
    {
        public string s;
        public void sayHello()
        {
            Console.WriteLine("Hello!");
        }

        //public (int Num, string Str) getNumber()
        //{
        //    var rnd = new Random();
        //    var result = rnd.Next();
        //    return (result, "Text");
        //}

        public (int Num, string Str) getNumber (int ? from = null,
            int ? to = null)
        {
            from = from ?? int.Parse(Console.ReadLine());
            from = from ?? int.Parse(Console.ReadLine());
            var rnd = new Random();
            var result = generateNumber();
            return (result, "Text");
            int generateNumber() => rnd.Next(from.Value, to.Value);
        }
        public void Print(string delim = "", params string[] tokens)
        {
            var line = string.Join(delim, tokens);
            Console.WriteLine(line);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var instance = new demoClass();
            //instance.sayHello();
            //(int number, string text) value = instance.getNumber();
            //Console.WriteLine("Number is {0} and text is {1}",value.number, value.text);
            //Console.ReadKey();
            //ctrl+R+R заміна всі значень на нові

            //оператор поглинання null
            //якщо from !null => a = from
            //інакше а = int.Parse(Console.ReadLine());
            //int a =  from ?? int.Parse(Console.ReadLine());
            instance.Print( "=","one", "two", "three");
            Console.ReadKey();
        }

    }
}
