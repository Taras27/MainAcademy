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

        public Computer(int Core, int Ram, int Hdd, int Frequency)
        {
            core = Core;
            ram = Ram;
            hdd = Hdd;
            frequency = Frequency;
        }

        public object AddComputer (ComputerType Type)
        {
            switch(Type)
            {
                case ComputerType.Desktop: return new Computer(4, 4, 4, 4); 
                case ComputerType.Laptop: return new Computer(6, 6, 6, 6);
                case ComputerType.Server: return new Computer(8, 8, 8, 8);
                default: return new Computer();                         
            }
        }                 
    }    
}
