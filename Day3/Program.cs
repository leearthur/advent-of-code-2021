var executor = new Day3();
var measurements = File.ReadAllLines("input/input.txt");
var sw = System.Diagnostics.Stopwatch.StartNew();

// 
// Part One
// 
Console.WriteLine("------------------------------");
Console.WriteLine("Part 1 Result: " + executor.Part1(measurements.ToArray()));
Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds}");

sw.Restart();

// 
// Part Two
// 
Console.WriteLine("------------------------------");
Console.WriteLine("Part 2 Result: " + executor.Part2(measurements.ToArray()));
Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds}");
