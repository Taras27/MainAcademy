using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_3_1_lab
{
    class CatchExceptionClass
    {
        public void CatchExceptionMethod()
        {
            try
            {
                MyArray ma = new MyArray();

                // 3) replace second elevent of array by 0

                int[] arr = new int[4] { 1, 4, 8, 5 };
                arr[1] = 0;
                ma.Assign(arr, 4);

            }
           
                // 8) catch all other exceptions here
            catch (Exception exc)
            {
                // 9) print System.Exception properties:
                // HelpLink, Message, Source, StackTrace, TargetSite
                Console.WriteLine(exc.HelpLink);
                Console.WriteLine(exc.Message);
                Console.WriteLine(exc.Source);
                Console.WriteLine(exc.StackTrace);
                Console.WriteLine(exc.TargetSite);

            }

            // 10) add finally block, print some message
            // explain features of block finally
            finally
            {
                Console.WriteLine("Print some message");
                Console.ReadKey();
            }
        }
    }
}
