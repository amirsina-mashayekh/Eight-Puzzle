namespace Eight_Puzzle
{
    abstract internal class Problem
    {
        protected PuzzleBoard initialState;

        protected PuzzleBoard goalState;

        public Problem(PuzzleBoard initialState, PuzzleBoard goalState)
        {
            this.initialState = initialState;
            this.goalState = goalState;
        }

        public abstract List<SolutionNode> Solve();
    }
}
