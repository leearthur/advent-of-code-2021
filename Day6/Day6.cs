using System.Diagnostics;

public class Day6
{
    public long Execute(int[] input, int totalDays, bool writeLog = false)
    {
        var data = CreateInitialDictionary(input);

        for(var day = 1; day <= totalDays; day++)
        {
            data = ProcessDay(data);
        }

        return data.Sum(x => x.Value);
    }

    private Dictionary<int, long> CreateInitialDictionary(int[] input)
    {
        var result = new Dictionary<int, long>();
        for (var i = 0; i <= 8; i++)
        {
            result.Add(i, input.Count(x => x == i));
        }
        return result;
    }

    private Dictionary<int, long> ProcessDay(Dictionary<int, long> input)
    {
        var newDictionary = new Dictionary<int, long>();
        foreach (var set in input)
        {
            if (set.Key == 0)
            {
                AddToDictionary(newDictionary, 6, set.Value);
                AddToDictionary(newDictionary, 8, set.Value);
            }
            else
            {
                AddToDictionary(newDictionary, set.Key - 1, set.Value);
            }
        }
        return newDictionary;
    }

    private static void AddToDictionary(Dictionary<int, long> data, int key, long value)
    {
        if (data.ContainsKey(key))
        {
            data[key] += value;
        }
        else
        {
            data.Add(key, value);
        }
    }
}