using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    class Game
    {
        private static Grid.Colors Player = Grid.Colors.Red;
        static void Main(string[] args)
        {
            var grid = new Grid();
            grid.drawGrid();

            while (grid.finish==false)
            {
                grid.showMessage(Player, Grid.States.SelectAColumn);
                string column = Console.ReadLine();

                Console.Clear();
                tryInsertToken(grid, column);
                grid.drawGrid();
            }
        }

        private static void tryInsertToken(Grid grid, string column)
        {
            if (grid.checkInt(column))
            {
                grid.insertToken(Int32.Parse(column) - 1, Player);
                TooglePlayer();
            }
            else
            {
                grid.showMessage(Grid.States.InvalidCharacter);
            }
        }

        private static void TooglePlayer()
        {
            if (Player == Grid.Colors.Red)
                Player = Grid.Colors.Yellow;
            else
                Player = Grid.Colors.Red;
        }

    }
}
