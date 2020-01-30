using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_fact_advstud
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define parameters to calculate the factorial of
            int digit = int.Parse(Console.ReadLine());
            //Call fact() method to calculate
            faktDigit(digit);
        }

        private static int faktDigit(int digit)
        {
            if (digit == 0)
                return 0;
            else if (digit == 1)
                return 1;
            return digit * faktDigit(digit - 1);
        }
        //Create fact() method  with parameter to calculate factorial
        //Use ternary operator

    }

    

}
