using System.Text;

namespace Eight_Puzzle
{
    internal class PuzzleBoard : IEquatable<PuzzleBoard>
    {
        private readonly int[] _board;

        private readonly int hash;

        private readonly int _emptyTile;

        private bool CanMoveUp => _emptyTile >= 3;

        private bool CanMoveRight => _emptyTile % 3 != 2;

        private bool CanMoveDown => _emptyTile <= 5;

        private bool CanMoveLeft => _emptyTile % 3 != 0;

        public int[] BoardArray => (int[])_board.Clone();

        public int[,] Board2d
        {
            get
            {
                var brd = new int[3, 3];

                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        brd[i, j] = _board[i * 3 + j];

                return brd;
            }
        }

        public int EmptyTile => _emptyTile;

        public PuzzleBoard(int[] board)
        {
            if (board.Length != 9)
                throw new ArgumentException("Board must have exactly 9 members.", nameof(board));

            for (int i = 0; i <= 8; i++)
            {
                if (!board.Contains(i))
                    throw new ArgumentException($"Board must have all numbers from 0 to 8. (missing: {i})", nameof(board));
            }

            _board = board;
            hash = 0;

            for (int i = 0; i < 9; i++)
            {
                hash += _board[i] * (int)Math.Pow(10, 8 - i);
                if (_board[i] == 0)
                    _emptyTile = i;
            }
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as PuzzleBoard);
        }

        public bool Equals(PuzzleBoard? other)
        {
            return other is not null && other.hash == hash;
        }

        public override int GetHashCode() => hash;

        public override string ToString() => hash.ToString();

        public string ToTableString()
        {
            var str = new StringBuilder();
            var table = Board2d;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int tile = table[i, j];
                    str.Append(tile == 0 ? " " : tile.ToString());
                    if (j < 2)
                        str.Append(' ');
                }
                if (i < 2)
                    str.Append(Environment.NewLine);
            }

            return str.ToString();
        }

        public PuzzleBoard MoveEmptyUp()
        {
            if (!CanMoveUp)
                throw new InvalidOperationException("Empty space is in topmost row.");

            var brd = BoardArray;
            brd[_emptyTile] = _board[_emptyTile - 3];
            brd[_emptyTile - 3] = 0;

            return new PuzzleBoard(brd);
        }

        public PuzzleBoard MoveEmptyRight()
        {
            if (!CanMoveRight)
                throw new InvalidOperationException("Empty space is in rightmost row.");

            var brd = BoardArray;
            brd[_emptyTile] = _board[_emptyTile + 1];
            brd[_emptyTile + 1] = 0;

            return new PuzzleBoard(brd);
        }

        public PuzzleBoard MoveEmptyDown()
        {
            if (!CanMoveDown)
                throw new InvalidOperationException("Empty space is in downmost row.");

            var brd = BoardArray;
            brd[_emptyTile] = _board[_emptyTile + 3];
            brd[_emptyTile + 3] = 0;

            return new PuzzleBoard(brd);
        }

        public PuzzleBoard MoveEmptyLeft()
        {
            if (!CanMoveLeft)
                throw new InvalidOperationException("Empty space is in leftmost row.");

            var brd = BoardArray;
            brd[_emptyTile] = _board[_emptyTile - 1];
            brd[_emptyTile - 1] = 0;

            return new PuzzleBoard(brd);
        }

        public List<PuzzleBoard> PossibleNextStates()
        {
            List<PuzzleBoard> boards = new();

            if (CanMoveUp)
                boards.Add(MoveEmptyUp());
            if (CanMoveRight)
                boards.Add(MoveEmptyRight());
            if (CanMoveDown)
                boards.Add(MoveEmptyDown());
            if (CanMoveLeft)
                boards.Add(MoveEmptyLeft());

            return boards;
        }
    }
}
