var executor = new Day6();
var input = File.ReadAllLines("input/input.txt").First().Split(',');

var values = input.Select(x => int.Parse(x)).ToArray();

// 
// Part One
// 
Console.WriteLine("Part 1 Result: " + executor.Execute(values, 80));

// 
// Part Two
// 
Console.WriteLine("Part 2 Result: " + executor.Execute(values, 256));
