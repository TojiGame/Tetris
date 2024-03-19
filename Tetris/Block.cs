using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; }//Where the block spawns
        public abstract int Id { get; }//Id to indentify the blocks

        private int rotationState;
        private Position offset;

        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        public IEnumerable<Position> TilePositions()//Returns the grid posiotions occupied by block, factoring in the grand rotation and offset
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }//Loops over the tiles position in rotation state and add a row offset and columns offset

        public void RotateCW()//Rotates by 90 ClockWise
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        public void RotateCCW()//Rotates by 90 CounterClockWise
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        public void Move(int rows, int columns)//Moves a block by a given number of Rows and Columns
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset()//Resets the rotation and position
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
