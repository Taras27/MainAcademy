using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList myArrayList = new ArrayList();
            myArrayList.Add(1);
            myArrayList.Add("Two");
            myArrayList.Add(3);
            myArrayList.Add(4.5f);
            myArrayList.Add(10f);

            int firstElement = (int)myArrayList[0];
            string secondElement = (string)myArrayList[1];
            int thirdElement = (int)myArrayList[2];
            float fourthElement = (float)myArrayList[3];            
        }
    }    
}
