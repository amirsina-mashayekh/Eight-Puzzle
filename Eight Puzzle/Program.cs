using Eight_Puzzle;

PuzzleBoard goal = new(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 0, });

Console.WriteLine("8 Puzzle");
Console.WriteLine();

Console.WriteLine("Enter the initial state of puzzle,");
Console.WriteLine("from top-left to right-bottom, 0 for empty tile.");
Console.WriteLine("e.g. \"1 2 3 4 0 6 7 5\" (without quotes) for:");
Console.WriteLine("1 2 3");
Console.WriteLine("4   6");
Console.WriteLine("7 5 8");

PuzzleBoard? initial = null;

do
{
    Console.WriteLine();
    Console.Write(">> ");
    string[] line = Console.ReadLine().Split();

    try
    {
        int[] tiles = line.Select((tile) => int.Parse(tile)).ToArray();
        initial = new PuzzleBoard(tiles);
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. All tiles should be numbers.");
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
    }
} while (initial is null);

Console.WriteLine();
Console.WriteLine("Select the algoritm. Enter the corresponding number.");

Problem? problem = null;
do
{
    Console.WriteLine("1: A* (Manhattan heuristic)");
    Console.WriteLine("2: A* (Misplaced Tiles heuristic)");
    Console.WriteLine("3: Bidirectional BFS");
    Console.Write(">> ");

    try
    {
        int algo = int.Parse(Console.ReadLine());
        switch (algo)
        {
            case 1:
                problem = new AStarManhattan(initial, goal);
                break;

            case 2:
                problem = new AStarMisplacedTiles(initial, goal);
                break;

            case 3:
                problem = new BidirectionalBFS(initial, goal);
                break;

            default:
                Console.WriteLine("Enter a valid option.");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Enter a number.");
    }

    Console.WriteLine();
} while (problem is null);

var solution = problem.Solve();

if (solution.solution.Count == 0)
{
    Console.WriteLine("Couldn't solve the puzzle.");
    return;
}

foreach (var item in solution.solution)
{
    Console.WriteLine(item.ToTableString());
    Console.WriteLine();
}