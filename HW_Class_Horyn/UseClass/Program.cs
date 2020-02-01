using System;
using System.Collections.Generic;

namespace UseClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Company companyOne = new Company();
            //Company companyTwo = new Company();
            //Company companyThree = new Company();
            companyOne.ComputerAdd(1, 3, ICompany.ComputerType.Desktop);
            //companyTwo.ComputerAdd(1, 3, ICompany.ComputerType.Laptop);
            //companyThree.ComputerAdd(1, 3, ICompany.ComputerType.Server);

            var comp = new List<ICompany>();
            comp.Add(companyOne);
            //comp.Add(companyTwo);
            //comp.Add(companyThree);

            Console.WriteLine("Comp one:" + comp);
            Console.ReadKey();
        }
    }
}
