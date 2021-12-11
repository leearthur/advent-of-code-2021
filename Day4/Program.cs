var executor = new Day4();
var input = File.ReadAllLines("input/input.txt");

var numbers = DataLoader.LoadNumbers(input[0]);
var boards = DataLoader.LoadBoards(input.Skip(2).ToArray());

var sw = System.Diagnostics.Stopwatch.StartNew();

// 
// Part One
// 
Console.WriteLine("------------------------------");
Console.WriteLine("Part 1 Result: " + executor.Part1(numbers, boards));
Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds}");

sw.Restart();

// 
// Part Two
// 
Console.WriteLine("------------------------------");
Console.WriteLine("Part 2 Result: " + executor.Part2(numbers, boards));
Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds}");
