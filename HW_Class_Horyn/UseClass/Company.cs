using System;
using System.Collections.Generic;
using System.Text;

namespace UseClass
{
    class Company : ICompany
    {
        private int QuantityComputer { get; set; }
        private int Depatment { get; set; }
        ComputerType Computer { get; set; }
        public enum ComputerType
        {
            Desktop = 1,
            Laptop,
            Server
        }
        public void ComputerAdd (int Depatment,int QuantityComputer, ICompany.ComputerType Computer)
        {
            Computer[,] deps = new Computer[4,3];

            switch (Computer)
            {
                case ICompany.ComputerType.Desktop:
                    deps[Depatment, (int)ComputerType.Desktop] = ComputerAdd(Computer); 
                    break;
                case ICompany.ComputerType.Laptop:
                    deps[Depatment, (int)ComputerType.Laptop] = new Computer();
                    break;
                case ICompany.ComputerType.Server:
                    deps[Depatment, (int)ComputerType.Server] = new Computer();
                    break;
            }
        }
    }
}
