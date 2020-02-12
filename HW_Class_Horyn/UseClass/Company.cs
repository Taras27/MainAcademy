using System;
using System.Collections.Generic;
using System.Text;
using static UseClass.ClassEnum;
using static UseClass.Computer;

namespace UseClass
{
    class Company
    {
        private int quaquantityComputers;
        private ComputerType type;
        public int QuaquantityComputers
        {
            get => quaquantityComputers;
            set => quaquantityComputers = value;
        }
        public ComputerType Type
        {
            get => type;
            set => type = value;
        }
        public Company()
        {
            quaquantityComputers = 0;
            type = 0;
        }
        public Company(int QuaquantityComputers, ComputerType Type)
        {
            quaquantityComputers = QuaquantityComputers;
            type = Type;
        }

        public static Tuple<object, object, object> 
            AddComputerCompany (int QuaquantityLaptop, int QuaquantityDesktop, int QuaquantityServers)
        {
            Computer[] computer = new Computer[QuaquantityLaptop];
            Computer[] computer1 = new Computer[QuaquantityDesktop];
            Computer[] computer2 = new Computer[QuaquantityServers];
            

            for(int i =0; i<computer.Length; i++)
                computer[i] = (Computer)AddComputer(ComputerType.Laptop);
            for (int i = 0; i < computer1.Length; i++)
                computer1[i] = (Computer)AddComputer(ComputerType.Desktop);
            for (int i = 0; i < computer2.Length; i++)
                computer2[i] = (Computer)AddComputer(ComputerType.Server);
            
            return Tuple.Create((object)computer, (object)computer1, (object)computer2);
        }
    }
}
