using System;
using System.Collections.Generic;
using System.Text;
using static UseClass.Company;

namespace UseClass
{
    abstract class Computer
    {
        private int quantityCores { get; set; } //
        private int coreFrequency { get; set; }
        private int ramMemory { get; set; }
        private int capacityHdd { get; set; }
        // створити фабричний метод createServer
        
        public static int[] CreateLaptop()
        {
            int[] Arr = { 4, 1700, 4, 250 };
            return Arr;
        }
        public static int[] CreateDesktop()
        {
            int[] Arr = { 4, 2500, 6, 500 };
            return Arr;
        }
        public static int[] CreateServer()
        {
            int[] Arr = { 8, 3200, 8, 2000 };
            return Arr;
        }

    }

    
}
