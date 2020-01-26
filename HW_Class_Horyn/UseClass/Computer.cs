using System;
using System.Collections.Generic;
using System.Text;

namespace UseClass
{
    public class Computer
    {
        public int QuantityCores { get; set; }
        public int CoreFrequency { get; set; }
        public int RamMemory { get; set; }
        public int CapacityHdd { get; set; }

        public Computer(int quantityCores, int coreFrequency, int ramMemory, int capacityHdd)
        {
            QuantityCores = quantityCores;
            CoreFrequency = coreFrequency;
            RamMemory = ramMemory;
            CapacityHdd = capacityHdd;
        }
    }
}
