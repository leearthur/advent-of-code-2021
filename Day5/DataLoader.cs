public static class DataLoader
{
    public static Line[] GetLines(string[] input)
    {
        var lines = new List<Line>();
        foreach(var lineData in input)
        {
            var data = lineData.Split(" -> ");
            lines.Add(new Line(data[0], data[1]));
        }

        return lines.ToArray();
    }
}