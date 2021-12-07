public class Day7
{
    public long Part1(int[] positions)
    {
        var minPos = positions.Min();
        var maxPos = positions.Max();

        var data = CreateData(positions);

        var results = new Dictionary<int, long>();
        for(var i = minPos; i <= maxPos; i++)
        {
            var fuelUsage = 0L;
            foreach(var position in data)
            {
                fuelUsage += Math.Abs(position.Key - i) * position.Value;
            }

            results.Add(i, fuelUsage);
        }        

        return results.Min(x => x.Value);
    }

    public long Part2(int[] positions)
    {
        var minPos = positions.Min();
        var maxPos = positions.Max();

        var data = CreateData(positions);

        var results = new Dictionary<int, long>();
        for(var i = minPos; i <= maxPos; i++)
        {
            var fuelUsage = 0L;
            foreach(var position in data)
            {
                fuelUsage += CalculateFuelUsage(i, position.Key) * position.Value;
            }

            results.Add(i, fuelUsage);
        }        

        return results.Min(x => x.Value);
    }

    public int CalculateFuelUsage(int desiredDepth, int acutalDepth)
    {
        var diff = Math.Abs(desiredDepth - acutalDepth);
        return Enumerable.Range(1, diff).Sum();
    }

    private Dictionary<int, int> CreateData(int[] positions)
    {
        var data = new Dictionary<int, int>();
        foreach(var position in positions)
        {
            if (!data.ContainsKey(position))
            {
                data.Add(position, 0);
            }
            data[position] += 1;
        }
        return data;
    }
}