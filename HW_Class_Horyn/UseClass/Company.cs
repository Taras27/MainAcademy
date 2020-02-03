using System;
using System.Collections.Generic;
using System.Text;

namespace UseClass
{
    class Company
    {
        //відділення
        // у відділеннях масиви
        
        public void CreateDepartmentLaptop (int QuantityComputers, ClassEnum.ComputerType computerType)
        {
            int[,] ArrayLaptop = new int [(int)QuantityComputers, (int)computerType];
            for(int i=1; i< ArrayLaptop.Length; i++ )
            {
                ArrayLaptop[i, (int)computerType] = 
            }
            //do some here
        }
        public void CreateDepartmentDesktop(int QuantityComputers, ClassEnum.ComputerType computerType)
        {

            //do some here
        }
        public void CreateDepartmentServer(int QuantityComputers, ClassEnum.ComputerType computerType)
        {

            //do some here
        }
    }

}
