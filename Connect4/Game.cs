using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    class Game
    {
        static void Main(string[] args)
        {
            var grid = new Grid();
            grid.InsertToken(0, Grid.Colors.Yellow);
            Grid.States state = grid.getCellStates(0, 0);
            Console.WriteLine("Hello World");
            Console.ReadLine();
        }
    }
}
