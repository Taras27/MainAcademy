using System;
using System.Collections.Generic;
using System.Text;
using static UseClass.ClassEnum;
using static UseClass.Company;

namespace UseClass
{
    public class Computer
    {
        private int core;
        private int ram;
        private int hdd;
        private int frequency;
        private ComputerType type;
        public int Core
        {
            get => core;
            set => core = value;
        }
        public int Ram
        {
            get => ram;
            set => ram = value;
        }
        public int Hdd
        {
            get => hdd;
            set => hdd = value;
        }
        public int Frequency
        {
            get => frequency;
            set => frequency = value;
        }
        public ComputerType Type
        {
            get => type;
            set => type = value;
        }    
        public Computer ()
        {
            core = 0;
            ram = 0;
            hdd = 0;
            frequency = 0;            
        }
        public Computer(int Core, int Ram, int Hdd, int Frequency, ComputerType Type)
        {
            type = Type;
            core = Core;
            ram = Ram;
            hdd = Hdd;
            frequency = Frequency;
        }
        public static void ShowInfo(Computer computer)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Computer type: {computer.type.ToString()}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\tQuantity cores: {computer.core}");
            Console.WriteLine($"\tFrequency: {computer.frequency}");
            Console.WriteLine($"\tHDD capacity: {computer.hdd}");
            Console.WriteLine($"\tRAM quantity: {computer.ram}");
            Console.ResetColor();
        }
        public static object AddComputer (ComputerType Type)
        {
            switch(Type)
            {
                case ComputerType.Desktop:  return new Computer(4, 6, 500, 2500, ComputerType.Desktop); 
                case ComputerType.Laptop:   return new Computer(2, 4, 250, 1700, ComputerType.Laptop);
                case ComputerType.Server:   return new Computer(8, 16, 2000, 3000, ComputerType.Server);
                default: return new Computer();                         
            }
        }                 
    }    
}
