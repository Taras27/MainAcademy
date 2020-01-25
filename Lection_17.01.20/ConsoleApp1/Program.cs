using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.ASCII;
            //string str = "";
            //while(true)
            //{
            //    int code = Console.Read();
            //    char symb = (char)code;
            //    if(symb == 'q')
            //    {
            //        break;
            //    }
            //    str += symb;
            //}
            //Console.WriteLine("You entetrd: ");
            //Console.WriteLine(str);

            //Console.Write("Dowmloading...");
            //char[] loadersSymbols = { '-', '|' };
            //Console.CursorVisible = false;
            //while (true)
            //{
            //    foreach(var c in loadersSymbols)
            //    {
            //        Console.Write(c);                   
            //        Console.CursorLeft = Console.CursorLeft - 1;
            //        Thread.Sleep(1000/4);
            //    }
            //}

            // stopwatch
            //var timer = Stopwatch.StartNew();
            //var elapsed = timer.ElapsedMilliseconds;
            //benchmarkDotNet measure speed

            //String builder
            //var builder = new StringBuilder();

            //builder.Append("Some str");
            //builder.AppendFormat("User name is {0}", "SomeUserName");
            //var users = new string[]
            //{
            //    "User1", "User2"
            //};
            //builder.AppendJoin(',',users);
            //builder.EnsureCapacity(40);
            //var result = builder.ToString();
            //Console.WriteLine(result);

            //const int charsCount = 1000000;
            //string stringResult = "";
            //var builder = new StringBuilder();
            //var timer = new Stopwatch();
            //var rnd = new Random();
            //var from = 'a';
            //var to = 'z';
            //timer.Start();
            //for (var i = 0; i < charsCount; i++)
            //{
            //    var symb = (char)rnd.Next(from,to);
            //    stringResult += symb;
            //}
            //var elapsedConcat = timer.ElapsedMilliseconds;
            //timer.Restart();
            //for(var i =0; i< charsCount; i++)
            //{
            //    var symb = (char) rnd.Next(from,to);
            //    builder.Append(symb);
            //}
            //string str = builder.ToString();
            //var elapsedBuilder = timer.ElapsedMilliseconds;
            //timer.Stop();
            //Console.WriteLine("Using concat {0} \t Using builder {1} ", 
            //    elapsedConcat, elapsedBuilder);

            //DateTime now = DateTime.Now;
            //var specific = new DateTime(2030, 01, 01);

            //var parsed = DateTime.ParseExact("2020/01/17", "yyyy/mm/dd",
            //    CultureInfo.InvariantCulture);
            //var r = DateTime.Now.ToLongDateString();
            //var t = DateTime.Now.ToLongTimeString();
            //var e= DateTime.Now.ToShortDateString();
            //var w = DateTime.Now.ToShortTimeString();

            //Console.WriteLine(Convert.ToString(r));
            //Console.WriteLine(Convert.ToString(t));
            //Console.WriteLine(Convert.ToString(e));
            //Console.WriteLine(Convert.ToString(w));


        }
    }
}
