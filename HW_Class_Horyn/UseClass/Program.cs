using System;
using System.Collections.Generic;
using static UseClass.ClassEnum;

namespace UseClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer ();
            computer.AddComputer(ComputerType.Desktop);
            Console.WriteLine($"Core: {computer.Core} , Frequency: {computer.Frequency} " +
                              $"Hdd: {computer.Hdd}, Ram: {computer.Ram}");
            Console.ReadKey();
        }
    }
}
