using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloOperators_stud
{
    class Program
    {       
        static void Main(string[] args)
        {
            long a;
            Console.WriteLine(@"Please,  type the number:
            1. Farmer, wolf, goat and cabbage puzzle
            2. Console calculator
            3. Factirial calculation
            ");
            
            a = long.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Farmer_puzzle();
                    Console.WriteLine("");
                    break;
                case 2:
                    Calculator();
                    Console.WriteLine("");
                    break;
                case 3:
                    Factorial_calculation();
                    Console.WriteLine("");
                    break;
                default:
                    Console.WriteLine("Exit");
                    break;
            }
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
        #region farmer
        static void Farmer_puzzle()
        {
            //Key sequence: 3817283 or 3827183
            // Declare 7 int variables for the input numbers and other variables
            int[] arrOne = { 3, 8, 1, 7, 2, 8, 3 };
            int[] arrTwo = { 3, 8, 2, 7, 1, 8, 3 };
            int tmp=0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"From one bank to another should carry a wolf, goat and cabbage. 
            At the same time can neither carry nor leave together on the banks of a wolf and a goat, 
            a goat and cabbage. You can only carry a wolf with cabbage or as each passenger separately. 
            You can do whatever how many flights. How to transport the wolf, goat and cabbage that all went well?");
            Console.WriteLine("There: farmer and wolf - 1");
            Console.WriteLine("There: farmer and cabbage - 2");
            Console.WriteLine("There: farmer and goat - 3");
            Console.WriteLine("There: farmer  - 4");
            Console.WriteLine("Back: farmer and wolf - 5");
            Console.WriteLine("Back: farmer and cabbage - 6");
            Console.WriteLine("Back: farmer and goat - 7");
            Console.WriteLine("Back: farmer  - 8");
            Console.ForegroundColor = ConsoleColor.Blue;
            // Implement input and checking of the 7 numbers in the nested if-else blocks with the  Console.ForegroundColor changing
            bool winner = false;
            for(int i =0; i<7; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Please,  type numbers by step ");
                tmp = int.Parse(Console.ReadLine());
                if (arrOne[i] == tmp || arrTwo[i] == tmp)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" {0} -> Right answer!", i+1);                    
                    if (i == 6)
                        winner = true;
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" {0} -> Bad answer!", i+1);                    
                    winner = false;
                    break;
                }
            }
            if(winner == true)
            {
                Console.WriteLine("YOU WIN!!!");
            }
            else
            {
                Console.WriteLine("YOU LOST!!!");
            }
           
        }
        #endregion

        #region calculator
        static void Calculator()
        {
            // Set Console.ForegroundColor  value
            Console.WriteLine(@"Select the arithmetic operation:
            1. Multiplication 
            2. Divide 
            3. Addition 
            4. Subtraction
            5. Exponentiation ");

            Console.WriteLine("Enter arithmetic operation: ");
            int arithmeticOp = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter operand: ");
            double tmpA = double.Parse(Console.ReadLine());
                           
            Console.WriteLine("Enter operand: ");
            double tmpB = double.Parse(Console.ReadLine());                     

            switch (arithmeticOp)
            {
                case 1: 
                    Console.WriteLine(tmpA * tmpB);
                    break;
                case 2:
                    Console.WriteLine(tmpA / tmpB);
                    break;
                case 3:
                    Console.WriteLine(tmpA + tmpB);
                    break;
                case 4:
                    Console.WriteLine(tmpA - tmpB);
                    break;
                case 5:
                    Console.WriteLine(Math.Exp(tmpA));
                    Console.WriteLine(Math.Exp(tmpB));
                    break;
            }
            // Implement option input (1,2,3,4,5)
            //     and input of  two or one numbers
            //  Perform calculations and output the result 
        }
        #endregion

        #region Factorial
        
        static void Factorial_calculation()
        {
            // Implement input of the number
            // Implement input the for circle to calculate factorial of the number
            // Output the result
            int tmp;
            Console.Clear();
            Console.WriteLine("You choise Factorial calculation!!!");
            Console.WriteLine("Enter digit: ");
            tmp = int.Parse(Console.ReadLine());
            Console.WriteLine("Result: {0}",Program.faktDigit(tmp));
        }
        #endregion
        private static int faktDigit(int digit)
        {
            if (digit == 0)
                return 0;
            else if (digit == 1)
                return 1;
            return digit * faktDigit(digit -1);
        }
    }
}
