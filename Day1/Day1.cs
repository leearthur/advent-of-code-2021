public class Day1
{
    public int Part1(int[] measurements)
    {
        Console.WriteLine($"----------------------------------");
        var sw = System.Diagnostics.Stopwatch.StartNew();

        var result = 0;
        for (int i = 1; i < measurements.Length; i++)
        {
            if (measurements[i] > measurements[i - 1]) 
            {
                result++;
            }
        }

        Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds}");
        return result;
    }

    public int Part2(int[] measurements)
    {
        Console.WriteLine($"----------------------------------");
        var sw = System.Diagnostics.Stopwatch.StartNew();

        var result = 0;
        for (int i = 1; i < measurements.Length; i++)
        {
            if (GroupSum(measurements, i) > GroupSum(measurements, i - 1)) 
            {
                result++;
            }
        }

        Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds}");
        return result;
    }

    public static int GroupSum(int[] measurements, int start) => measurements.Skip(start).Take(3).Sum();
}