namespace Eight_Puzzle
{
    abstract internal class AStar : Problem
    {
        protected AStar(PuzzleBoard initialState, PuzzleBoard goalState) : base(initialState, goalState) { }

        protected abstract int Heuristic(PuzzleBoard board);

        public override (List<SolutionNode> solution, int totalGeneratedNodes) Solve()
        {
            SolutionNode? currentNode = new(initialState, null, 0);
            PriorityQueue<SolutionNode, int> queue = new();
            HashSet<PuzzleBoard> visited = new();
            int totalNodes = 0;

            while (!currentNode.State.Equals(goalState))
            {
                var nextStates = currentNode.State.PossibleNextStates();

                foreach (var state in nextStates)
                {
                    SolutionNode nextNode = new(state, currentNode, currentNode.PathCost + 1);
                    if (visited.Add(state))
                    {
                        int f = currentNode.PathCost + Heuristic(state);
                        queue.Enqueue(nextNode, f);
                        totalNodes++;
                    }
                }

                if (!queue.TryDequeue(out currentNode, out _))
                    return (new List<SolutionNode>(), 0);
            }

            List<SolutionNode> solution = new();

            while (currentNode is not null)
            {
                solution.Add(currentNode);
                currentNode = currentNode.Parent;
            }
            solution.Reverse();

            return (solution, totalNodes);
        }
    }
}
