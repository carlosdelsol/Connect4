using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class Grid
    {
        public States[,] Cells { get; set;}
        private int Rows { get;}
        private int Columns { get;}
        public bool finish = false;
        public Grid() {
            Rows = 6;
            Columns = 7;
            Cells = new States[Columns,Rows];
        }
        public enum States {
            Empty,
            Red,
            Yellow,
            OutOfRange,
            FullColumn,
            InvalidCharacter,
            FullGrid,
            SelectAColumn,
            Win
        }
        public enum Colors {
            Red,
            Yellow
        }

        public enum Direction {
            Horizontal,
            Vertical
        }

        public States getCellStates(int column, int row)
        {
            if (!checkColumn(column))
                return States.OutOfRange;
            else if (!checkRow(row))
                return States.FullColumn;
            return Cells[column,row];
        }

        public bool checkColumn(int column)
        {
            if (column >= 0 && column < this.Columns)
                return true;
            else
                return false;
        }

        public bool checkInt(string column)
        {
            bool isInt = false;
            try
            {
                int icolumn;
                isInt = Int32.TryParse(column, out icolumn);
                if (Int32.Parse(column) > 0 && Int32.Parse(column) < 8)
                    isInt = true;
                else
                    isInt = false;
            }
            catch
            {
                Console.Clear();
                showMessage(States.InvalidCharacter);
                drawGrid();
            }
            return isInt;
        }

        public bool checkRow(int row)
        {
            if (row >= this.Rows)
                return false;
            else
                return true;
        }

        public void insertToken(int column, Colors colour)
        {
            if (checkColumn(column))
            {
                bool placeToken = false;
                int RowCount = 0;
                while (!placeToken && RowCount < this.Rows)
                {
                    if (this.Cells[column, RowCount] == States.Empty)
                    {
                        this.Cells[column, RowCount] = colorToState(colour);
                        if (analyzer(column, RowCount, colour))
                        {
                            drawGrid();
                            Console.WriteLine("***************");
                            this.showMessage(colour, States.Win);
                            Console.WriteLine("***************");
                            Console.ReadLine();
                            finish = true;
                        }
                        placeToken = true;
                    }
                    else
                    {
                        RowCount++;
                    }
                }
            }
            else {
                Console.Clear();
                showMessage(States.OutOfRange);
                drawGrid();
            }
        }

        private static States colorToState(Colors colour)
        {
            return colour == Colors.Red ? States.Red : States.Yellow;
        }

        public bool analyzer(int column, int row, Colors colour)
        {
            return (checkAnalyze(column, Direction.Vertical, colour) ||
                    checkAnalyze(row, Direction.Horizontal, colour)  ||
                    analyzeDiagonal(colour)) ? true : false;
        }

        public bool checkAnalyze(int columnOrRow,  Direction direction, Colors colour)
        {
            int counter = 0, positions = getPositions(direction);

            for (int currentPosition = 0; currentPosition < positions; currentPosition++)
            {
                if (getCurrentColor(columnOrRow, direction, currentPosition) == colorToState(colour))
                {
                    counter++;
                    if (counter == 4)
                        return true;
                }
                else counter = 0;
            }
            return false;
        }

        private States getCurrentColor(int columnOrRow, Direction direction, int currentPosition)
        {
            return (direction == Direction.Horizontal) ? getCellStates(currentPosition, columnOrRow) : getCellStates(columnOrRow, currentPosition);
        }

        private int getPositions(Direction direction)
        {
            return direction == Direction.Horizontal ? this.Columns : this.Rows;
        }

        public bool analyzeDiagonal(Colors colour)
        {
            int counter = 0;
            try
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    int plusCol = 0;
                    counter = 0;
                    for (int ro = 0; ro < this.Rows; ro++)
                    {
                        if ((col + plusCol) < this.Columns && this.Cells[col + plusCol, ro] == colorToState(colour))
                        {
                            counter++;
                            if (counter == 4)
                                return true;
                        }
                        plusCol++;
                    }
                }


                for (int ro = 0; ro <= this.Rows; ro++)
                {
                    int plusRow = 0;
                    counter = 0;
                    for (int col = 0; col <= this.Columns; col++)
                    {
                        if ((ro + plusRow) < this.Rows && this.Cells[col, ro + plusRow] == colorToState(colour))
                        {
                            counter++;
                            if (counter == 4)
                                return true;
                        }
                        plusRow++;
                    }
                }

                for (int col = 0; col < this.Columns; col++)
                {
                    int plusCol = 0;
                    counter = 0;
                    for (int ro = this.Rows - 1; ro >= 0; ro--)
                    {
                        if ((col + plusCol) < 7 && this.Cells[col + plusCol, ro] == colorToState(colour))
                        {
                            counter++;
                            if (counter == 4)
                                return true;
                        }
                        plusCol++;
                    }
                }

                for (int ro = this.Rows - 1; ro > 0; ro--)
                {
                    int plusRow = 0;
                    counter = 0;
                    for (int col = 0; col < this.Columns; col++)
                    {
                        if ((ro - plusRow) >= 0 && this.Cells[col, ro - plusRow] == colorToState(colour))
                        {
                            counter++;
                            if (counter == 4)
                                return true;
                        }
                        plusRow++;
                    }
                }

                return false;
            }
            catch {
                return false;
            }
        }

        public void insertPosition(int column, int row, Colors colour)
        {
            this.Cells[column, row] = colorToState(colour);
        }

        public void drawGrid()
        {
            Console.WriteLine(" = SUPER CONNECT 4 = ");
            for (int row = this.Rows-1; row >= 0; row--)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    Console.Write(" " + printCharacter(this.Cells[col, row]) + " ");
                }
                Console.Write("\n\n");
            }
        }

        private string printCharacter(States color)
        {
            switch (color)
            {
                case States.Red: return "o";
                case States.Yellow: return "*";
                default: return "·";
            }
        }

        public string showMessage(States state)
        {
            string message = string.Empty;
            switch (state)
            {
                case States.OutOfRange:
                    message = "Please, write a number between 1 to 7";
                    break;
                case States.InvalidCharacter:
                    message = "Invalid character. Please, write a number between 1 to 7";
                    break;
                case States.FullColumn:
                    message = "This column is full, try another column";
                    break;
                case States.FullGrid:
                    message = "The grid is full. Nobody wins.";
                    break;
                default:
                    message = string.Empty;
                    break;
            }
            Console.WriteLine(message);
            return message;
        }

        public string showMessage(Colors colour, States selectAColumn)
        {
            string message = string.Empty;
            switch (selectAColumn)
            {
                case States.SelectAColumn:
                    message = "("+ colour.ToString().ToUpper() + ") - Select a column [1-7]:";
                    break;
                case States.Win:
                    message = "(" + colour.ToString().ToUpper() + ") - WINS!";
                    break;
                default:
                    message = string.Empty;
                    break;
            }
            Console.WriteLine(message);
            return message;
        }
    }

}
