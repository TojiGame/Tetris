using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class IBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]//Stores the posisions for 4 rotation states
        {
            new Position[] { new(1,0), new(1,1), new(1,2), new(1,3) },
            new Position[] { new(0,2), new(1,2), new(2,2), new(3,2) },
            new Position[] { new(2,0), new(2,1), new(2,2), new(2,3) },
            new Position[] { new(0,1), new(1,1), new(2,1), new(3,1) }
        };

        public override int Id => 1;//Id will be one
        protected override Position StartOffset => new Position(-1, 3);//Starting in the middle of the top row
        protected override Position[][] Tiles => tiles;//Returns tile
    }
}


