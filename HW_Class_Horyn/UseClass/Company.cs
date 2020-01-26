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

        private int QuantityComputer { get; set; }
        ComputerType Computer { get; }
                
        public void ComputerAdd (int QuantityComputer, ComputerType Computer)
        {
            Computer[] deps = new Computer[QuantityComputer];
        }
    }
}
