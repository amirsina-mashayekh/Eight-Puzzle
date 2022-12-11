using Eight_Puzzle;

var pb = new PuzzleBoard(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 5);

pb = pb.MoveEmptyDown();

Console.WriteLine(pb.ToTableString());

Console.WriteLine(pb.GetHashCode());