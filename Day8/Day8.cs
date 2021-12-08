public class Day8
{
    public long Part1(Data[] data)
    {
        var count = 0;
        foreach(var item in data)
        {
            var matches = item.Output.Where(y => y.Length == 2 || y.Length == 4 || y.Length == 3 || y.Length == 7);
            count += matches.Count();
        }
        return count;
    }

    public long Part2(Data[] data)
    {
        var numbers = new List<int>();
        foreach (var item in data)
        {
            var decoder = ProcessInput(item.Input);
            numbers.Add(ProcessOutput(decoder, item.Output));
        }

        return numbers.Sum();
    }

    private static Decoder ProcessInput(string[] input)
    {
        var decoder = new Decoder();
        SetKnownMappings(decoder, input);
        SetMatchingMappings(decoder, input);

        foreach (var item in input)
        {
            decoder.CalcualteLength6Mappings(item);
        }

        foreach (var item in input)
        {
            decoder.CalcualteLength5Mappings(item);
        }

        return decoder;
    }

    private static void SetKnownMappings(Decoder decoder, string[] input)
    {
        foreach (var item in input)
        {
            switch (item.Length)
            {
                case 2:
                    decoder.SetMapping(1, item);
                    break;
                case 3:
                    decoder.SetMapping(7, item);
                    break;
                case 4:
                    decoder.SetMapping(4, item);
                    break;
                case 7:
                    decoder.SetMapping(8, item);
                    break;
            }
        }
    }

    private static void SetMatchingMappings(Decoder decoder, string[] input)
    {
        foreach (var item in input)
        {
            if (decoder.DiscoverMatchingMapping(item, 5, 1, 3)) continue;
            if (decoder.DiscoverMatchingMapping(item, 6, 4, 9)) continue;
        }
    }

    private static int ProcessOutput(Decoder decoder, string[] output)
    {
        var decodedValue = string.Empty;
        foreach (var item in output)
        {
            decodedValue += decoder.Decode(item);
        }

        if (int.TryParse(decodedValue, out int result))
        {
            return result;
        }
        return -1;
    }
}