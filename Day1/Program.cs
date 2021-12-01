var day1 = new Day1();
var measurements = File.ReadAllLines("input/simple_input.txt").Select(i => int.Parse(i));

// 
// Part One
// 
Console.WriteLine("Part 1 Result: " + day1.Part1(measurements.ToArray()));

// 
// Part Two
// 
Console.WriteLine("Part 1 Result: " + day1.Part2(measurements.ToArray()));
