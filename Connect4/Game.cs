using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    class Game
    {
        private static Player playerRed, playerYellow, currentPlayer;
        private static Grid grid = new Grid();
        private static Printer printer = new Printer();

        static void Main(string[] args)
        {
            grid.showMessage(Grid.States.AwaitingYellow);
            playerYellow = new Player(printer.ReadScreen(), Grid.Colors.Yellow);
            currentPlayer = playerYellow;

            grid.showMessage(Grid.States.AwaitingRed);
            playerRed = new Player(printer.ReadScreen(), Grid.Colors.Red);

            printer.ClearScreen();
            startGame();
        }

        private static void startGame()
        {
            grid.drawGrid();
            while (grid.finish == false)
            {
                grid.showMessage(currentPlayer.Name, Grid.States.SelectAColumn);
                string column = printer.ReadScreen();

                printer.ClearScreen();
                tryInsertToken(column);
            }

            finishGame();
        }

        private static void finishGame()
        {
            printer.PrintLine("****************");
            grid.showMessage(currentPlayer.Name, Grid.States.Win);
            printer.PrintLine("****************");
            printer.ReadScreen();
        }

        private static void tryInsertToken(string column)
        {
            if (grid.checkInt(column))
            {
                grid.insertToken(Int32.Parse(column) - 1, currentPlayer.colour);
                if (grid.finish == false && grid.checkColumn(Int32.Parse(column)-1)) TooglePlayer();
            }
            else
            {
                printer.ClearScreen();
                grid.showMessage(Grid.States.InvalidCharacter);
                grid.drawGrid();
            }
        }

        private static void TooglePlayer()
        {
            if (currentPlayer.colour == Grid.Colors.Red)
               currentPlayer = playerYellow;
            else
               currentPlayer = playerRed;
        }

    }
}
