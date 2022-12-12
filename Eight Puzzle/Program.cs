using Eight_Puzzle;

var goal = new PuzzleBoard(new int[]
    {
        1,2,3,
        4,5,6,
        7,8,0,
    });

var pb = new PuzzleBoard(new int[]
    {
        4,1,6,
        8,0,7,
        2,5,3,
    });

AStarMisplacedTiles problem = new(pb, goal);

var a = problem.Solve();

Console.WriteLine(pb.ToTableString());

Console.WriteLine(pb.GetHashCode());