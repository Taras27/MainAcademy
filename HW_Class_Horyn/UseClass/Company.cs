using System;
using System.Collections.Generic;
using System.Text;

namespace UseClass
{
    class Company
    {        
        public enum ComputerType
        {
            Desktop,
            Laptop,
            Server
        }

        private int _quantityComputer { get; set; }
        ComputerType Computer { get; set; }

        
        public void ComputerAdd (int QuantityComputer, ComputerType Computer)
        {
            Computer[,] deps = new Computer[_quantityComputer, (int)Computer];

            switch (Computer)
            {
                case ComputerType.Desktop:
                    break;
                case ComputerType.Laptop:
                    break;
                case ComputerType.Server:
                    break;
            }
        }
    }
}
