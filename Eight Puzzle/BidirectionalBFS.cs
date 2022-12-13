namespace Eight_Puzzle
{
    internal class BidirectionalBFS : Problem
    {
        public BidirectionalBFS(PuzzleBoard initialState, PuzzleBoard goalState) : base(initialState, goalState) { }

        public override (List<PuzzleBoard> solution, int totalGeneratedNodes) Solve()
        {
            SolutionNode? currentNode = new(initialState, null, 0);
            Queue<SolutionNode> queue = new();
            Dictionary<int, SolutionNode> visited = new();

            SolutionNode? revCurrentNode = new(goalState, null, 0);
            Queue<SolutionNode> revQueue = new();
            Dictionary<int, SolutionNode> revVisited = new();

            int totalNodes = 0;

            PuzzleBoard commonState;

            while (true)
            {
                if (visited.ContainsKey(revCurrentNode.State.GetHashCode()))
                {
                    commonState = revCurrentNode.State;
                    break;
                }
                if (revVisited.ContainsKey(currentNode.State.GetHashCode()))
                {
                    commonState = currentNode.State;
                    break;
                }
                var nextStates = currentNode.State.PossibleNextStates();
                var revNextStates = revCurrentNode.State.PossibleNextStates();

                foreach (var state in nextStates)
                {
                    SolutionNode nextNode = new(state, currentNode, currentNode.PathCost + 1);
                    if (visited.TryAdd(nextNode.State.GetHashCode(), nextNode))
                    {
                        queue.Enqueue(nextNode);
                        totalNodes++;
                    }
                }
                foreach (var state in revNextStates)
                {
                    SolutionNode nextNode = new(state, revCurrentNode, revCurrentNode.PathCost + 1);
                    if (revVisited.TryAdd(nextNode.State.GetHashCode(), nextNode))
                    {
                        revQueue.Enqueue(nextNode);
                        totalNodes++;
                    }
                }

                if (!queue.TryDequeue(out currentNode) || !revQueue.TryDequeue(out revCurrentNode))
                    return (new List<PuzzleBoard>(), 0);
            }

            List<PuzzleBoard> solution = new();

            currentNode = visited[commonState.GetHashCode()];
            revCurrentNode = revVisited[commonState.GetHashCode()].Parent;

            while (currentNode is not null)
            {
                solution.Add(currentNode.State);
                currentNode = currentNode.Parent;
            }
            solution.Reverse();

            while (revCurrentNode is not null)
            {
                solution.Add(revCurrentNode.State);
                revCurrentNode = revCurrentNode.Parent;
            }

            return (solution, totalNodes);
        }
    }
}
