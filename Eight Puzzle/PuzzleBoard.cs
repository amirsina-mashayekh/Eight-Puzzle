using System.Collections;

namespace Eight_Puzzle
{
    internal struct PuzzleBoard : IEquatable<PuzzleBoard>
    {
        private int[] _board;

        private int hash;

        public int[] BoardArray
        {
            get => _board;
            private set
            {
                _board = value;

                int power = 8;
                hash = 0;

                for (int i = 0; i < 8; i++)
                {
                    if (i == emptyTile - 1)
                        power--;

                    hash += _board[i] * (int)Math.Pow(10, power);
                    power--;
                }
            }
        }

        private readonly int emptyTile;

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

                        brd[i, j] = _board[counter];

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

            _board = board;
            hash = 0;
            this.emptyTile = emptyTile;
            BoardArray = board;
        }

        public override bool Equals(object? obj)
        {
            return obj is PuzzleBoard board && Equals(board);
        }

        public bool Equals(PuzzleBoard other)
        {
            return hash == other.hash;
        }

        public override int GetHashCode() => hash;
    }
}
