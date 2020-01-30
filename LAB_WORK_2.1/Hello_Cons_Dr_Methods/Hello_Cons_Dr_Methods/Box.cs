using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Cons_Dr_Methods
{
    class Box
    {

        private int XPosition { get; set; }
        private int YPosition { get; set; }
        private int Height { get; set; }
        private int Width { get; set; }
        private char Symb { get; set; }
        private string Message { get; set; }

        public Box(int xPosition, int yPosition, int height, int width, char symb, string message)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Height = height;
            Width = width;
            Symb = symb;
            Message = message;
        }        
        private void DrawBox ()
        {            
            int tableCenter = Height / 2;           
            Console.ForegroundColor = ConsoleColor.Green;
            string line = new string(Symb, Width);            
            int cursorPosition = (Width - Message.Length)/2;           
            string mainString = line.Insert(cursorPosition, Message).Remove(Width);            
            
            for (int i=1;i <= Height; i++)
            {
                Console.SetCursorPosition(XPosition, YPosition + i);
                if (i == tableCenter)
                {
                    Console.WriteLine(mainString);
                    continue;
                }                
                Console.WriteLine(line);
            }
            
        }

        public void ShowBox()
        {
            DrawBox();
        }
    }
}
