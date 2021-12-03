public class Day3
{
    public long Part1(string[] input)
    {
        var gamma = "";
        for (var pos = 0; pos < input[0].Length; pos++)
        {
            gamma += GetMostCommonValue(input, pos).ToString();
        }
        var epsilon = Invert(gamma);
        
        var gammaValue = Convert.ToInt32(gamma, 2);
        var epsilonValue = Convert.ToInt32(epsilon, 2);

        return gammaValue * epsilonValue;
    }

    public long Part2(string[] input)
    {
        var o2Ratings = input;
        var co2Ratings = input;

        for (var pos = 0; pos < input[0].Length; pos++)
        {
            if (o2Ratings.Length > 1)
            {
                var mostCommon = GetMostCommonValue(o2Ratings, pos);
                o2Ratings = ExtractValues(o2Ratings, pos, mostCommon);
            }
            if (co2Ratings.Length > 1)
            {
                var leastCommon = GetLeastCommonValue(co2Ratings, pos);
                co2Ratings = ExtractValues(co2Ratings, pos, leastCommon);
            }
        }

        var o2RatingsValue = Convert.ToInt32(o2Ratings[0], 2);
        var co2RatingsValue = Convert.ToInt32(co2Ratings[0], 2);

        return o2RatingsValue * co2RatingsValue;
    }

    private int GetMostCommonValue(string[] input, int position)
    {
        var values = input.Select(x => x[position]);
        var orderedValues = values.GroupBy(x => x).OrderByDescending(y => y.Count());

        if (orderedValues.Count() > 1)
        {
            if (orderedValues.All(x => x.Count() == orderedValues.First().Count()))
            {
                return 1;
            }
        }

        return int.Parse(orderedValues.First().Key.ToString());
    }

    private int GetLeastCommonValue(string[] input, int position)
    {
        var values = input.Select(x => x[position]);
        var orderedValues = values.GroupBy(x => x).OrderBy(y => y.Count());

        if (orderedValues.Count() > 1)
        {
            if (orderedValues.All(x => x.Count() == orderedValues.First().Count()))
            {
                return 0;
            }
        }

        return int.Parse(orderedValues.First().Key.ToString());
    }

    private string[] ExtractValues(string[] input, int position, int value)
    {
        return input.Where(x => x[position].ToString() == value.ToString())
            .ToArray();
    }

    private string Invert(string input)
    {
        var result = "";
        foreach(var chr in input)
        {
            result += Math.Abs(byte.Parse(chr.ToString()) - 1).ToString();
        }

        return result;
    }
}