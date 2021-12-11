public class Day1
{
    public int Part1(int[] measurements)
    {
        var result = 0;
        for (int i = 1; i < measurements.Length; i++)
        {
            if (measurements[i] > measurements[i - 1]) 
            {
                result++;
            }
        }
        return result;
    }

    public int Part2(int[] measurements)
    {
        var result = 0;
        for (int i = 1; i < measurements.Length; i++)
        {
            if (GroupSum(measurements, i) > GroupSum(measurements, i - 1)) 
            {
                result++;
            }
        }
        return result;
    }

    public static int GroupSum(int[] measurements, int start) => measurements.Skip(start).Take(3).Sum();
}