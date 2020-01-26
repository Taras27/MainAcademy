using System;

namespace UseClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Company one = new Company();
            one.ComputerAdd(5, Company.ComputerType.Desktop);

            Console.WriteLine(one);
            Console.ReadKey();
        }
    }
}
