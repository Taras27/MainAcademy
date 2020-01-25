using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("How many question: ");
            int arrSize = int.Parse(Console.ReadLine());
            Console.Clear();

            string[] userQuestion = new string[arrSize];
            string[] userAnswers = new string[arrSize];

            for (int i = 0;i<arrSize; i++)
            {                
                Console.WriteLine("Question № {0}",i+1);
                userQuestion[i] = Console.ReadLine();
                Console.Clear();
            }

            for(int i=0;i<arrSize;i++)
            {                
                Console.WriteLine("Answer № {0}", i + 1);
                Console.WriteLine(userQuestion[i]);
                userAnswers[i] = Console.ReadLine();
                Console.Clear();
            }
            for(int i=0;i<arrSize;i++)
            {
                Console.WriteLine("Question № {0}:\t{1}", i + 1, userQuestion[i]);               
                Console.WriteLine("Answer № {0}:\t{1}", i + 1, userAnswers[i]);                
            }
        }
    }
}
