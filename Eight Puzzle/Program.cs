using Eight_Puzzle;

var goal = new PuzzleBoard(new int[]
    {
        1,2,3,
        4,5,6,
        7,8,0,
    });

var pb = new PuzzleBoard(new int[]
    {
        3,1,6,
        2,7,5,
        4,8,0,
    });

AStarMisplacedTiles problem = new(pb, goal);

var a = problem.Solve();

Console.WriteLine(pb.ToTableString());

Console.WriteLine(pb.GetHashCode());