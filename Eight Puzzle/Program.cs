using Eight_Puzzle;

var pb = new PuzzleBoard(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 2);

for (int i = 0; i < pb.Board2d.GetLength(0); i++)
{
	for (int j = 0; j < pb.Board2d.GetLength(1); j++)
	{
		Console.Write("{0}\t", pb.Board2d[i, j]);
	}
	Console.WriteLine();
}

Console.WriteLine(pb.GetHashCode());