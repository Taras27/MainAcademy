using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //object o = new Random();
            //if(o is Random rnd)
            //{
            //    Console.WriteLine(rnd.Next(10));
            //}

            //
            //int result = num == "+" ? n1 + n2 : n1 - n2;

            //Random rnd = null;
            //if (rnd==null)
            //{
            //    rnd = new Random();
            //}
            //rnd = rnd ?? new Random();
            //var rndVal = rnd.Next();

            //switch ()
            //{
            //    case:  <=====
            //    case:  <=====
            //        break;

            //    case:
            //        break;
            //    case:
            //        break;
            //    case:
            //        break;
            //}

            //string op = Console.ReadLine();

            //string result = op switch
            //    {
            //    "+" => "Add",   //case
            //    "+" => "Add",   //case
            //    "+" => "Add",   //case
            //    _ => "Unknown"  //default
            //    }

            //object num = int.parse(console.readline());

            //var arresult = num switch
              //  {
              //      int i when i > 10 => i* i,
              //      string s => int.parse(s) * 5,
              //      _ => 0
              //  };

            //int[] arr = new int [] {1,2,3,4,5};
            //foreach (int i in arr)
            //{
             //   Console.Write(arr);
            //}

            //for (int i = 0; i<5; i++)
            //{
            //    int curr = arr[i];
            //    Console.WriteLine(curr);
            //}

            //int [,] multy = new int[2,2] 
             //   {
             //       {1,2},
             //       {4,6}
             //    };

           /// foreach(var item in multy)
            //{
             //   Console.WriteLine(item);
            //}

            //int[][] jugged  = new int [5][];
            //jugged[0] = new int[] {1,2,3,4,5};

            //Console.WriteLine("Enter array lenght!!!");
            //int len = int.Parse(Console.ReadLine());
            //int[] arr = new int[len];
            //var rnd = new Random();

            //for(int i =0; i<arr.Length; i++)
            //{
            //    arr[i] = int.Parse(Console.ReadLine());
            //}

            int lenJugged = int.Parse(Console.ReadLine()); //рваний масив!!!
            int[][] Jugged = new int[lenJugged][];
            for(var i = 0; i<Jugged.Length; i++)
            {
                int innerLenght = int.Parse(Console.ReadLine());
                int[] inner = new int[innerLenght];
                Jugged[i] = inner;
            }
        }
    }
}
