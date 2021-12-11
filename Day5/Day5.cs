public class Day5
{
    public long Part1(Line[] lines) => GetHighHitCount(true, lines);

    public long Part2(Line[] lines) => GetHighHitCount(false, lines);

    private long GetHighHitCount(bool letOpponentWin, Line[] lines)
    {
        var confirmedHits = new Dictionary<string, int>();
        foreach(var line in lines)
        {
            foreach (var hit in line.LocationHits(letOpponentWin).Select(x => x.Id()))
            {
                AddHit(confirmedHits, hit);
            }
        }
        return confirmedHits.Where(h => h.Value > 1).Count();
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