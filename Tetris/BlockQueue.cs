using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class BlockQueue
    {
        private readonly Block[] blocks = new Block[]//Block array
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        };

        private readonly Random random = new Random();//Random object

        public Block NextBlock { get; private set; }//Property for a next block i queue

        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }

        private Block RandomBlock()//Returns a next block
        {
            return blocks[random.Next(blocks.Length)];
        }

        public Block GetAndUpdate()//Returns next block and updates the property. It will keep picking not to return the same as before block
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            }
            while (block.Id == NextBlock.Id);

            return block;
        }
    }
}
