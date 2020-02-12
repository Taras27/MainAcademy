using System;
using System.Collections.Generic;
using static UseClass.ClassEnum;
using static UseClass.Computer;
using static UseClass.Company;

namespace UseClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            Tuple <object, object, object> a  = AddComputerCompany(2,2,1);
            
            Console.WriteLine((a.Item1.ToString()), a.Item2.ToString(), a.Item3.ToString());

            //Computer computer = (Computer)AddComputer(ComputerType.Desktop);
            //ShowInfo(computer);            
            //Computer computer1 = (Computer)AddComputer(ComputerType.Laptop);
            //Computer computer2 = (Computer)AddComputer(ComputerType.Server);
            //Console.WriteLine($"Computer type: {ComputerType.Desktop} \t Core: {computer.Core} , Frequency: {computer.Frequency} " +
            //                  $"Hdd: {computer.Hdd}, Ram: {computer.Ram}");
            //Console.WriteLine($"Computer type: {ComputerType.Laptop} \tCore: {computer1.Core} , Frequency: {computer1.Frequency} " +
            //                  $"Hdd: {computer1.Hdd}, Ram: {computer1.Ram}");
            //Console.WriteLine($"Computer type: {ComputerType.Server} \t Core: {computer2.Core} , Frequency: {computer2.Frequency} " +
            //                  $"Hdd: {computer2.Hdd}, Ram: {computer2.Ram}");
            Console.ReadKey();
        }
    }
}
