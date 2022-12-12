namespace Eight_Puzzle
{
    internal class SolutionNode
    {
        public PuzzleBoard State { get; }

        public SolutionNode? Parent { get; }

        public int PathCost { get; }

        public SolutionNode(PuzzleBoard state, SolutionNode? parent, int pathCost)
        {
            State = state;
            Parent = parent;
            PathCost = pathCost;
        }
    }
}
