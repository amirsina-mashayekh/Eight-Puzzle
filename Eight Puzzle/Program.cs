using Eight_Puzzle;

var pb = new PuzzleBoard(new int[]
    {
        1, 2, 3,
        4, 0, 6,
        5, 7, 8
    });

pb = pb.MoveEmptyUp();

Console.WriteLine(pb.ToTableString());

Console.WriteLine(pb.GetHashCode());