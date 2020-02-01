using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Cons_Dr_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Box box = new Box(10, 10, 8, 50, '+', "This is a project!!!");
            box.ShowBox();
            Console.ReadKey();
        }
    }
}
