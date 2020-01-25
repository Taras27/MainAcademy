using System;
using System.Threading.Tasks;

namespace Hello_Operators_advstud
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MyMax = 200;

            Random random = new Random();
            
            // random.Next(MaxValue) returns a 32-bit signed integer that is greater than or equal to 0 and less than MaxValue
            int Guess_number = random.Next(MyMax) + 1;           
            // implement input of number and comparison result message in the while circle with  comparison condition
            int userIput=0;
            while (Guess_number != userIput)
            {
                Console.WriteLine("Random value: {0}", Convert.ToString(Guess_number));
                Console.WriteLine("Enter digit: \t");
                userIput = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("User input is: {0}", userIput);

                if (userIput < Guess_number)
                {
                    Console.WriteLine("User input is less than RandValue!!!");
                }
                else if (userIput > Guess_number)
                {
                    Console.WriteLine("User input is greater than RandValue!!!");
                }                
            }
            Console.WriteLine("My congatilation!!! {0}", userIput);
            Console.ReadKey();
        }
    }
}
