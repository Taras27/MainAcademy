using System;
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
            string firstName, name, year;
            firstName = string.Empty;
            name = string.Empty;
            year = string.Empty;

            Console.WriteLine("Enter you firstname: ");
                firstName = Console.ReadLine();
                Console.WriteLine("Accepted!!!");
                Task.Delay(3000);
                Console.Clear();

            Console.WriteLine("Enter you name: ");
                name = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Accepted!!!");
                Task.Delay(3000);
                Console.Clear();
            
            Console.WriteLine("How old are you?");           
                year = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Accepted!!!");
                Task.Delay(3000);
                Console.Clear();
           

            Console.WriteLine( "Firstname: " + firstName);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Old: " + year);
        }
    }
}
