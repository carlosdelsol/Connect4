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
            grid.InsertPosition(0, 2, Grid.Colors.Red);
            grid.InsertPosition(5, 2, Grid.Colors.Red);
            grid.InsertPosition(2, 4, Grid.Colors.Red);
            grid.InsertPosition(3, 4, Grid.Colors.Red);
            grid.DrawGrid();

            grid.analyzeDiagonal(Grid.Colors.Red);

            while (true)
            {
                Console.WriteLine("("+ Player.ToString() +") - Select a column:");
                string column = Console.ReadLine();
                if (CheckInt(column))
                {
                    Console.Clear();
                    grid.InsertToken(Int32.Parse(column), Player);
                    TooglePlayer();
                    grid.DrawGrid();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please, write a number between 1 to 7");
                    grid.DrawGrid();
                }
            }
        }

        private static void TooglePlayer()
        {
            if (Player == Grid.Colors.Red)
                Player = Grid.Colors.Yellow;
            else
                Player = Grid.Colors.Red;
        }

        private static bool CheckInt(string column)
        {
            bool isInt = false;
            try
            {
                int icolumn;
                isInt = Int32.TryParse(column, out icolumn);

            }
            catch
            {
                Console.WriteLine("Please, write a number between 1 to 7");
            }
            return isInt;
        }
    }
}
