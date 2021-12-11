public static class DataLoader
{
    public static Line[] GetLines(string[] input)
    {
        return input.Select(i => i.Split(" -> "))
            .Select(data => new Line(data[0], data[1]))
            .ToArray();
    }
}