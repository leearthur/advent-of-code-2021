var executor = new Day6();
var input = File.ReadAllLines("input/input.txt")
    .First()
    .Split(',')
    .Select(x => int.Parse(x))
    .ToArray();

var sw = System.Diagnostics.Stopwatch.StartNew();

// 
// Part One
// 
Console.WriteLine("------------------------------");
Console.WriteLine("Part 1 Result: " + executor.Execute(input, 80));
Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds}");

sw.Restart();

// 
// Part Two
// 
Console.WriteLine("------------------------------");
Console.WriteLine("Part 2 Result: " + executor.Execute(input, 256));
Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds}");
