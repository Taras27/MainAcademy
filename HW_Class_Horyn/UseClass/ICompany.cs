using System;
using System.Collections.Generic;
using System.Text;

namespace UseClass
{
    interface ICompany
    {
        public enum ComputerType
        {
            Desktop = 1,
            Laptop,
            Server
        };
        public void ComputerAdd(int Depatment, int QuantityComputer, ComputerType Computer);
    }
}
