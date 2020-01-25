using System;

namespace Lesson
{
    class Program
    {
        struct Value
        {
            public string Name;
        }
        static void Main(string[] args)
        {
            /*  Console.WriteLine("Enter some text: ");
                string result = Console.ReadLine();
                Console.WriteLine("You entered: {0}", result);
                sistem.single -> float  */

            /*    Console.WriteLine("Enter you age!!!");
                string ageStr = Console.ReadLine();
                int age = Convert.ToInt32(ageStr);
                Console.WriteLine("You age is: {0}", age);  */

            /*   int r = Convert.ToInt32("3");
                 Console.WriteLine(r); */

            /* literal int i = ->2<- literal; */

            /*  Program p1 = new Program();
                p1.Name = "Taras";
                Program p2 = p1;
                p2.Name = "someOne";

                p1 = new Program();
                p1.Name = "New Value";
                Console.WriteLine(p2.Name); */

            /*
             * byte, sbyte, short, ushort, int, uint, long(int64), ulong(uint64)
             * 
             * int a = 200;
             * byte b = (byte) a;  приведення типів явне
             */
            int b;
            float f = 10f;
            double d = 10d;
            float f2 = 5e-5f; //0.00005
            System.Decimal dm = 10m; // 128 bit точність 28 символів

            char symb = 'a';
            char code = symb;
            Console.WriteLine(code);  //utf16

            bool? maybe = null;
            Nullable<bool> maybe2 = null;

            int myNumber = default(int);

        }
    }
}
