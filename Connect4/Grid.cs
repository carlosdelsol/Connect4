using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class Grid
    {
        public States[,] Cells { get;}
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
            return (analyzeVertical(column, colour) || analyzeHorinzontal(row, colour)) ? true : false;
        }

        public bool analyzeVertical(int column, Colors colour)
        {
            int counter = 0;
            for (int currentRow = 0; currentRow < this.Rows; currentRow++)
            {
                if (Cells[column, currentRow] == ColorToState(colour))
                {
                    counter++;
                    if (counter == 4)
                        return true;
                }
                else counter = 0;
            }
            return false;
        }

        public bool analyzeHorinzontal(int row, Colors colour)
        {
            int counter = 0;
            for (int currentColumn = 0; currentColumn < this.Columns; currentColumn++)
            {
                if (Cells[currentColumn, row] == ColorToState(colour))
                {
                    counter++;
                    if (counter == 4)
                        return true;
                }
                else counter = 0;
            }
            return false;
        }
    }
}
