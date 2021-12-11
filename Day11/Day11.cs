public class Day11
{
    public long Part1(string[] input)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine($"----------------------------------");
        
        var grid = new Grid(input);
        for (var i = 0; i < 100; i++)
        {
            grid.Step();
        }

        Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds}");
        return grid.TotalFlashes;
    }

    public long Part2(string[] input)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine($"----------------------------------");

        var grid = new Grid(input);
        var step = 0;
        while(true)
        {
            step++;
            grid.Step();
            if (grid.StepFlashes == 100)
            {
                break;
            }
        }

        Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds}");
        return step;
    }
}
