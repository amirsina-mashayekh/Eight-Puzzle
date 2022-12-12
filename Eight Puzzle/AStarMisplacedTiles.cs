using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eight_Puzzle
{
    internal class AStarMisplacedTiles : AStar
    {
        public AStarMisplacedTiles(PuzzleBoard initialState, PuzzleBoard goalState) : base(initialState, goalState) { }

        protected override int Heuristic(PuzzleBoard board)
        {
            var brd = board.BoardArray;
            int totalMTs = 0;

            for (int i = 0; i < 9; i++)
            {
                if (brd[i] != i + 1 && brd[i] != 0)
                    totalMTs++;
            }

            return totalMTs;
        }
    }
}
