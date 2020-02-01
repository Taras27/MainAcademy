using System;
using System.Collections.Generic;
using System.Text;
using static UseClass.Company;

namespace UseClass
{
    public class Computer
    {
        private int QuantityCores { get; set; }
        private int CoreFrequency { get; set; }
        private int RamMemory { get; set; }
        private int CapacityHdd { get; set; }
        public enum ComputerType
        {
            Desktop = 1,
            Laptop,
            Server
        }

        public  int SetComputerQC(ComputerType ComputerSet)
        {
            if (ComputerSet == ComputerType.Desktop)
                return QuantityCores=4;
            else if (ComputerSet == ComputerType.Laptop)
                return QuantityCores = 2;
            else return QuantityCores = 8;
        }
        public int SetComputerCF(ComputerType ComputerSet)
        {
            if (ComputerSet == ComputerType.Desktop)
                return CoreFrequency = 2500;
            else if (ComputerSet == ComputerType.Laptop)
                return CoreFrequency = 1700;
            else return CoreFrequency = 3000;
        }
        public int SetComputerRM(ComputerType ComputerSet)
        {
            if (ComputerSet == ComputerType.Desktop)
                return RamMemory = 6;
            else if (ComputerSet == ComputerType.Laptop)
                return RamMemory = 4;
            else return RamMemory = 16;
        }
        public int SetComputerCH(ComputerType ComputerSet)
        {
            if (ComputerSet == ComputerType.Desktop)
                return CapacityHdd = 500;
            else if (ComputerSet == ComputerType.Laptop)
                return CapacityHdd = 250;
            else return CapacityHdd = 2000;
        }

        public int[] CompAdd (ComputerType ComputerSet)
        {
            int[] tmp = new int[4];
            switch(ComputerSet)
            {
                case ComputerType.Desktop:
                    tmp[0] = SetComputerQC(ComputerType.Desktop);
                    tmp[1] = SetComputerCF(ComputerType.Desktop);
                    tmp[2] = SetComputerRM(ComputerType.Desktop);
                    tmp[3] = SetComputerCH(ComputerType.Desktop);
                    return tmp;
                    break;
                case ComputerType.Laptop:
                    tmp[0] = SetComputerQC(ComputerType.Laptop);
                    tmp[1] = SetComputerCF(ComputerType.Laptop);
                    tmp[2] = SetComputerRM(ComputerType.Laptop);
                    tmp[3] = SetComputerCH(ComputerType.Laptop);
                    return tmp;
                    break;
                case ComputerType.Server:
                    tmp[0] = SetComputerQC(ComputerType.Server);
                    tmp[1] = SetComputerCF(ComputerType.Server);
                    tmp[2] = SetComputerRM(ComputerType.Server);
                    tmp[3] = SetComputerCH(ComputerType.Server);
                    return tmp;
                    break;
                default: return null; 
                    break;

            }
        }
    }
}
