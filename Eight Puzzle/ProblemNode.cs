namespace Eight_Puzzle
{
    internal class ProblemNode
    {
        public PuzzleBoard State { get; }

        public ProblemNode? Parent { get; }

        public int PathCost { get; }

        public ProblemNode(PuzzleBoard state, ProblemNode? parent, int pathCost)
        {
            State = state;
            Parent = parent;
            PathCost = pathCost;
        }
    }
}
