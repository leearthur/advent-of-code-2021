var executor = new Day4();
var input = File.ReadAllLines("input/input.txt");

var numbers = DataLoader.LoadNumbers(input[0]);
var boards = DataLoader.LoadBoards(input.Skip(2).ToArray());

// 
// Part One
// 
Console.WriteLine("Part 1 Result: " + executor.Part1(numbers, boards));

// 
// Part Two
// 
Console.WriteLine("Part 2 Result: " + executor.Part2(numbers, boards));
