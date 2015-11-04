using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public interface IPrinter
    {
        void PrintLine(string message);
        void PrintString(string message);
        void PrintString(string message, ConsoleColor ForegroundColor);
        string ReadScreen();
        void ClearScreen();
    }

    public class Printer : IPrinter
    {
        public void ClearScreen()
        {
            Console.Clear();
        }

        public string ReadScreen()
        {
            return Console.ReadLine();
        }
        public void PrintLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
        }
        public void PrintString(string message, ConsoleColor ForegroundColor)
        {
            Console.ForegroundColor = ForegroundColor;
            Console.Write(message);
        }

        public void PrintString(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
        }
    }
}
