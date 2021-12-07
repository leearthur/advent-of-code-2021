var executor = new Day7();
var input = File.ReadAllLines("input/input.txt")
    .First()
    .Split(',')
    .Select(x => int.Parse(x))
    .ToArray();

// 
// Part One
// 
Console.WriteLine("Part 1 Result: " + executor.Part1(input));

// 
// Part Two
// 
Console.WriteLine("Part 2 Result: " + executor.Part2(input));
