var executor = new Day2();
var measurements = File.ReadAllLines("input/input.txt");

// 
// Part One
// 
Console.WriteLine("Part 1 Result: " + executor.Part1(measurements.ToArray()));

// 
// Part Two
// 
Console.WriteLine("Part 2 Result: " + executor.Part2(measurements.ToArray()));