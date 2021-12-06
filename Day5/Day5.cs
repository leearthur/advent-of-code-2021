public class Day5
{
    public long Part1(Line[] lines)
    {
        return GetHighHitCount(true, lines);
    }

    public long Part2(Line[] lines)
    {
        return GetHighHitCount(false, lines);
    }

    private long GetHighHitCount(bool simple, Line[] lines)
    {
        var confirmedHits = new Dictionary<string, int>();

        foreach(var line in lines)
        {
            foreach (var hit in line.LocationHits(simple).Select(x => x.Id()))
            {
                AddHit(confirmedHits, hit);
            }
        }
        var highHits = confirmedHits.Where(h => h.Value > 1);
        return highHits.Count();
    }

    private void AddHit(Dictionary<string, int> hits, string coordinate)
    {
        if (!hits.ContainsKey(coordinate))
        {
            hits.Add(coordinate, 0);
        }
        hits[coordinate]++;
    }
}