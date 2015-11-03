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
            FullColumn
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
            if (!CheckColumn(column))
                    return States.OutOfRange;
            else if (!CheckRow(row))
                return States.FullColumn;
            return Cells[column,row];
        }

        public bool CheckColumn(int column)
        {
            if (column >= 0 && column < this.Columns)
                return true;
            else
                return false;
        }

        public bool CheckRow(int row)
        {
            if (row >= this.Rows)
                return false;
            else
                return true;
        }

        public void InsertToken(int column, Colors colour)
        {
            if (CheckColumn(column))
            {
                bool placeToken = false;
                int RowCount = 0;
                while (!placeToken && RowCount < this.Rows)
                {
                    if (this.Cells[column, RowCount] == States.Empty)
                    {
                        this.Cells[column, RowCount] = ColorToState(colour);
                        //analyzer(column, RowCount, colour);
                        placeToken = true;
                    }
                    else
                    {
                        RowCount++;
                    }
                }
            }
        }

        private static States ColorToState(Colors colour)
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
                if (getCurrentColor(columnOrRow, direction, currentPosition) == ColorToState(colour))
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
                        if ((col + plusCol) < this.Columns && this.Cells[col + plusCol, ro] == ColorToState(colour))
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
                        if ((ro + plusRow) < this.Rows && this.Cells[col, ro + plusRow] == ColorToState(colour))
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

        public void InsertPosition(int column, int row, Colors colour)
        {
            this.Cells[column, row] = ColorToState(colour);
        }

        public void DrawGrid()
        {
            for (int row = this.Rows-1; row >= 0; row--)
            {
                for (int col = 0; col < this.Columns; col++)
                {
                    Console.Write(" " + PrintCharacter(this.Cells[col, row]) + " ");
                }
                Console.Write("\n\n");
            }
        }

        private string PrintCharacter(States color)
        {
            switch (color)
            {
                case States.Red: return "o";
                case States.Yellow: return "*";
                default: return "·";
            }
        }
    }

}
