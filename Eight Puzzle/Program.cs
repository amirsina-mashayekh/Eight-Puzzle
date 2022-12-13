using Eight_Puzzle;
using System.Diagnostics;

PuzzleBoard goal = new(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 0, });

Console.WriteLine("8 Puzzle");
Console.WriteLine();

Console.WriteLine("Enter the initial state of puzzle,");
Console.WriteLine("from top-left to right-bottom, 0 for empty tile.");
Console.WriteLine("e.g. \"1 2 3 4 0 6 7 5\" (without quotes) for:");
Console.WriteLine("1 2 3");
Console.WriteLine("4 █ 6");
Console.WriteLine("7 5 8");

PuzzleBoard? initial = null;

do
{
    Console.WriteLine();
    Console.Write(">> ");
    string[]? line = Console.ReadLine()?.Split();

    try
    {
        if (line is not null)
        {
            int[] tiles = line.Select((tile) => int.Parse(tile)).ToArray();
            initial = new PuzzleBoard(tiles);
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
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

    string? algo = Console.ReadLine()?.Trim();
    switch (algo)
    {
        case "1":
            problem = new AStarManhattan(initial, goal);
            break;

        case "2":
            problem = new AStarMisplacedTiles(initial, goal);
            break;

        case "3":
            problem = new BidirectionalBFS(initial, goal);
            break;

        default:
            Console.WriteLine("Enter a valid option.");
            break;
    }

    Console.WriteLine();
} while (problem is null);

Stopwatch stopwatch = Stopwatch.StartNew();
var solution = problem.Solve();
stopwatch.Stop();
float time_ms = stopwatch.ElapsedTicks / (float)(Stopwatch.Frequency / 1000);

if (solution.solution.Count == 0)
{
    Console.WriteLine("Couldn't solve the puzzle.");
    return;
}

Console.WriteLine("Steps: " + solution.solution.Count.ToString());
Console.WriteLine("Total generated nodes: " + solution.totalGeneratedNodes.ToString());
Console.WriteLine("Algorithm running time: " + time_ms.ToString(".000") + "ms");
Console.WriteLine();

bool stepByStep = true;
int step = 0;

while (true)
{
    Console.WriteLine();
    Console.WriteLine(solution.solution[step].ToTableString());
    Console.WriteLine();

    if (stepByStep)
    {
        if (step > 0)
        {
            Console.WriteLine("P: Previous step");
            Console.WriteLine("S: Start over");
        }

        if (step < solution.solution.Count - 1)
        {
            Console.WriteLine("N: Next step");
            Console.WriteLine("A: Print all remaining steps");
        }

        Console.WriteLine("E: End");

        Console.Write(">> ");
        var ans = Console.ReadLine()?.ToUpper();

        if (ans == "P" && step > 0)
            step -= 2;
        else if (ans == "S" && step > 0)
            step = -1;
        else if (ans == "A" && step < solution.solution.Count - 1)
            stepByStep = false;
        else if (ans == "E")
            break;
        else if (!(ans == "N" && step < solution.solution.Count - 1))
        {
            Console.WriteLine("Invalid input.");
            step--;
        }
    }
    else if (step == solution.solution.Count - 2)
        stepByStep = true;

    step++;
}