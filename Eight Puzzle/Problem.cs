namespace Eight_Puzzle
{
    abstract internal class Problem
    {
        protected PuzzleBoard initialState;

        protected PuzzleBoard goalState;

        protected Problem(PuzzleBoard initialState, PuzzleBoard goalState)
        {
            this.initialState = initialState;
            this.goalState = goalState;
        }

        public abstract (List<PuzzleBoard> solution, int totalGeneratedNodes) Solve();
    }
}
