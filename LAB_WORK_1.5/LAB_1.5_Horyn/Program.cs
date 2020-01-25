using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //--------------------------First----------------------------------//
            Console.WriteLine("Enter first digit:");
            int userInputOne = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second digit:");
            int userInputTwo = int.Parse(Console.ReadLine());

            char searchSymb = '#';

            string delimOne = new string('1', userInputOne);
            string delimTwo = new string('1', userInputTwo);
            string sumString = (delimOne + searchSymb + delimTwo);
            Console.WriteLine(sumString);

            if (userInputOne > userInputTwo)
            {
                sumString = sumString.Remove(0, userInputTwo);
                int position = sumString.IndexOf("#");
                sumString = sumString.Remove(position);
                Console.WriteLine(sumString);
            }
            else if (userInputOne < userInputTwo)
            {
                sumString = sumString.Remove(0, userInputOne);
                int position = sumString.IndexOf("#");
                sumString = sumString.Remove(0, userInputOne + 1);
                Console.WriteLine(sumString);
            }
            else
            {
                sumString = null;
                Console.WriteLine("Empty string!!!");
            }
            Console.WriteLine("Press any ket to continue!!!");
            Console.ReadKey();  
            //-----------------------------------------------------------------//

            //--------------------------Second--------------------------------//

            Console.WriteLine("Enter digit to binary convert:");
            int userInputBinary = int.Parse(Console.ReadLine());
            int tmp = userInputBinary;
            string arrStr = "";
            int tmpValue = 0;

            while (userInputBinary > 0)
            {
                tmpValue = userInputBinary % 2;
                arrStr += tmpValue;
                userInputBinary = userInputBinary / 2;
            }
            
            char[] arrChars = arrStr.ToCharArray();
            Array.Reverse(arrChars);
            string str = new string(arrChars);
            Console.WriteLine("Digit: {0}\t->\tBinary view: {1}", tmp, str);
            Console.WriteLine("Press any ket to continue!!!");
            Console.ReadKey();

            //-----------------------------------------------------------------//

            //--------------------------Third---------------------------------//

            //--------SOS--------//
            Console.Beep(1000, 100);            
            Console.Beep(1000, 100);           
            Console.Beep(1000, 100);            
            Console.Beep(1000, 1000);            
            Console.Beep(1000, 1000);            
            Console.Beep(1000, 1000);            
            Console.Beep(1000, 100);         
            Console.Beep(1000, 100);          
            Console.Beep(1000, 100);
            Console.WriteLine("Press any ket to continue!!!");
            Console.ReadKey();

            //-----------------------------------------------------------------//
        }
    }
}
