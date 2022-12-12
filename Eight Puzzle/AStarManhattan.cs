using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eight_Puzzle
{
    internal class AStarManhattan : AStar
    {
        public AStarManhattan(PuzzleBoard initialState, PuzzleBoard goalState) : base(initialState, goalState) { }

        protected override int Heuristic(PuzzleBoard board)
        {
            var brd = board.BoardArray;
            int totalDistance = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int index = i * 3 + j;
                    if (brd[index] != 0)
                    {
                        int dstRow = (brd[index] - 1) / 3;
                        int dstCol = (brd[index] - 1) % 3;

                        totalDistance +=
                            Math.Abs(dstRow - i) +
                            Math.Abs(dstCol - j);
                    }
                }
            }

            return totalDistance;
        }
    }
}
