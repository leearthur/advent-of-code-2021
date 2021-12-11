var executor = new Day5();
var input = File.ReadAllLines("input/input.txt");
var lines = DataLoader.GetLines(input);
var sw = System.Diagnostics.Stopwatch.StartNew();

// 
// Part One
// 
Console.WriteLine("------------------------------");
Console.WriteLine("Part 1 Result: " + executor.Part1(lines));
Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds}");

sw.Restart();

// 
// Part Two
// 
Console.WriteLine("------------------------------");
Console.WriteLine("Part 2 Result: " + executor.Part2(lines));
Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds}");
