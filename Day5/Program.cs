var executor = new Day5();
var input = File.ReadAllLines("input/input.txt");

var lines = DataLoader.GetLines(input);

// 
// Part One
// 
Console.WriteLine("Part 1 Result: " + executor.Part1(lines));

// 
// Part Two
// 
Console.WriteLine("Part 2 Result: " + executor.Part2(lines));
