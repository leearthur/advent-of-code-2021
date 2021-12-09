public class Day9
{
    private List<int> _lowPoints = new();

    public long Part1(string[] input)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        _lowPoints.Clear();
        Console.WriteLine($"----------------------------------");

        var height = input.Length;
        var width = input[0].Length;

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                FindLowPoint(input, x, y, width, height);
            }
        }

        Console.WriteLine($"Count: {_lowPoints.Count}");
        Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds}");
        return _lowPoints.Sum();
    }

    private void FindLowPoint(string[] input, int x, int y, int width, int height)
    {
        var value = int.Parse(input[y][x].ToString());

        if (x > 0 && NotLower(value, input[y][x - 1])) return;
        if (x < width - 1 && NotLower(value, input[y][x + 1])) return;

        if (y > 0 && NotLower(value, input[y - 1][x])) return;
        if (y < height - 1 && NotLower(value, input[y + 1][x])) return;

        _lowPoints.Add(value + 1);
    }

    private static bool NotLower(int value, char neighbour)
    {
        return value >= int.Parse(neighbour.ToString());
    }

    public long Part2(string[] input)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        _lowPoints.Clear();
        Console.WriteLine($"----------------------------------");

        var height = input.Length;
        var width = input[0].Length;

        var basins = new List<Basin>();
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                if (input[y][x] == '9')
                {
                    continue;
                }

                if (!basins.Any(b => b.Contains(x, y)))
                {
                    var basin = new Basin();
                    AnalyisCell(input, x, y, height, width, basin);
        
                    basins.Add(basin);
                }
            }
        }

        Console.WriteLine($"Count: {basins.Count}");
        Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds}");

        var ordered = basins.OrderByDescending(b => b.Size);
        
        var result = 1L;
        foreach (var value in ordered.Take(3))
        {
            result = result * value.Size;
        }

        return result;
    }

    private void AnalyisCell(string[] input, int x, int y, int height, int width, Basin basin)
    {
        if (input[y][x] == '9' || basin.Contains(x, y))
        {
            return;
        }

        basin.Cells.Add(new Coordinate(x, y));

        if (x > 0) AnalyisCell(input, x - 1, y, height, width, basin);
        if (x < width - 1) AnalyisCell(input, x + 1, y, height, width, basin);
        if (y > 0) AnalyisCell(input, x, y - 1, height, width, basin);
        if (y < height - 1) AnalyisCell(input, x, y + 1, height, width, basin);
    }
}

public class Basin
{
    public List<Coordinate> Cells { get; set; } = new();

    public int Size => Cells.Count();

    public bool Contains(int x, int y)
    {
        return Cells.Any(c => c.PosX == x && c.PosY == y);
    }
}

public class Coordinate
{
    public int PosX { get; }
    public int PosY { get; }

    public Coordinate(int x, int y)
    {
        PosX = x;
        PosY = y;
    }
}