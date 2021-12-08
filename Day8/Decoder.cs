public class Decoder
{
    private readonly Dictionary<int, char[]> _digits = new()
    {
        { 0, new[] { 'a', 'b', 'c', 'e', 'f', 'g' } },          // 6
        { 1, new[] { 'c', 'f' } },                              // 2 *
        { 2, new[] { 'a', 'c', 'd', 'e', 'g' } },               // 5
        { 3, new[] { 'a', 'c', 'd', 'f', 'g' } },               // 5
        { 4, new[] { 'b', 'c', 'd', 'f' } },                    // 4 *
        { 5, new[] { 'a', 'b', 'd', 'f', 'g' } },               // 5
        { 6, new[] { 'a', 'b', 'd', 'e', 'f', 'g' } },          // 6
        { 7, new[] { 'a', 'c', 'f' } },                         // 3 *
        { 8, new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' } },     // 7 *
        { 9, new[] { 'a', 'b', 'c', 'd', 'f', 'g' } }           // 6
    };

    private readonly Dictionary<int, Mapping> _mappingValues = new();

    public void SetMapping(int key, string value)
    {
        if (!_mappingValues.ContainsKey(key))
        {
            _mappingValues.Add(key, new Mapping(key, _digits[key], value.ToCharArray()));
        }
    }

    public void CalcualteLength6Mappings(string value)
    {
        if (value.Length != 6 || MappingExists(value))
        {
            return;
        }

        var potentialDigits = GetPotentialDigits(value);
        if (_mappingValues[1].Encoded.All(x => value.Contains(x)))
        {
            SetMapping(0, value);
        }
        else
        {
            SetMapping(6, value);
        }
    }

    public void CalcualteLength5Mappings(string value)
    {
        if (value.Length != 5 || MappingExists(value))
        {
            return;
        }

        var potentialDigits = GetPotentialDigits(value);
        var missing = _mappingValues[9].Encoded.Count(x => value.Contains(x));
        if (missing == 4)
        {
            SetMapping(2, value);
        }
        else if (missing == 5)
        {
            SetMapping(5, value);
        }
    }

    private bool MappingExists(string value)
    {
        return _mappingValues.Any(a => a.Value.Encoded.All(v => value.Contains(v)) && a.Value.Encoded.Length == value.Length);
    }

    private Dictionary<int, char[]> GetPotentialDigits(string value)
    {
        var sameLengthDigits = _digits.Where(x => x.Value.Length == value.Length);
        return sameLengthDigits.Where(x => !_mappingValues.ContainsKey(x.Key)).ToDictionary(k => k.Key, v => v.Value);
    }

    public bool DiscoverMatchingMapping(string value, int length, int match, int mapping)
    {
        if (value.Length == length)
        {
            if (_mappingValues[match].Encoded.All(e => value.Contains(e)))
            {
                SetMapping(mapping, value);
                return true;
            }
        }
        return false;
    }

    public string Decode(string value)
    {
        var validDigits = _digits.Where(x => x.Value.Length == value.Length);
        if (validDigits.Count() == 1)
        {
            return validDigits.First().Key.ToString();
        }

        var matchingDigit = _mappingValues.Where(x => x.Value.Encoded.All(v => value.Contains(v) && x.Value.Encoded.Length == value.Length));
        if (matchingDigit.Any())
        {
            return matchingDigit.First().Key.ToString();
        }

        return "?";
    }
}

public class Mapping
{
    public int Key { get; }
    public char[] Decoded { get; }
    public char[]  Encoded { get; }

    public Mapping(int key, char[] decoded, char[] encoded)
    {
        Key = key;
        Decoded = decoded.OrderBy(x => x).ToArray();
        Encoded = encoded.OrderBy(x => x).ToArray();
    }
}
