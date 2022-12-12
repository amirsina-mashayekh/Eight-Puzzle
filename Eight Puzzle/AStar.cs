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
            int totalNodes = 0;

            while (!currentNode.State.Equals(goalState))
            {
                var nextStates = currentNode.State.PossibleNextStates();

                foreach (var state in nextStates)
                {
                    int f = currentNode.PathCost + Heuristic(state);
                    SolutionNode nextNode = new(state, currentNode, currentNode.PathCost + 1);
                    queue.Enqueue(nextNode, f);
                    totalNodes++;
                }

                currentNode = queue.Dequeue();
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
