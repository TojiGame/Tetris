using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameGrid
    {
        private readonly int[,] grid;//array
        public int Rows { get; }
        public int Columns { get; }

        public int this[int r, int c]//Easy access to array
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        public GameGrid(int rows, int columns)//Constructor, can be used in many ways in irregular tetris
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];//Array initialization
        }

        public bool IsInside(int r, int c)//Checks if a given row and column is inside a grid or not
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;//Aby była w gridzie rows muszą być większe lub równe 0 i mniejsze niż ilość column
        }

        public bool IsEmpty(int r, int c)//Checks if a given cell is empty or not
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }

        public bool IsRowFull(int r)//CHecks if entire row are full 
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsRowEmpty(int r)//Checks if enitre row are empty
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private void ClearRow(int r)//If the row is Full, clear it
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }

        private void MoveRowDown(int r, int numRows)//If the row was cleared, the rows will move down
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        public int ClearFullRows()//Removes form bottom to top, it checks if row full, than clear it, and than wil be moved row down
        {
            int cleared = 0;

            for (int r = Rows - 1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }

            return cleared;
        }
    }
}

