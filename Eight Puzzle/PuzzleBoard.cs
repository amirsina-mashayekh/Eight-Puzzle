using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eight_Puzzle
{
    internal struct PuzzleBoard
    {
        private readonly int[] board;

        private int emptyTile;

        public int?[,] Board2d
        {
            get
            {
                var brd = new int?[3, 3];
                int counter = 0;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        int pos = i * 3 + j;

                        if (pos == emptyTile - 1)
                            continue;

                        brd[i, j] = board[counter];

                        counter++;
                    }
                }

                return brd;
            }
        }

        public PuzzleBoard(int[] board, int emptyTile)
        {
            if (board.Length != 8)
                throw new ArgumentException("Board must have exactly 8 members.", nameof(board));

            for (int i = 1; i <= 8; i++)
            {
                if (!board.Contains(i))
                    throw new ArgumentException($"Board must have all numbers from 1 to 8. (missing: {i})", nameof(board));
            }

            if (emptyTile < 1 || emptyTile > 9)
                throw new ArgumentException("Empty position must be in board range", nameof(emptyTile));

            this.board = board;
            this.emptyTile = emptyTile;
        }
    }
}
