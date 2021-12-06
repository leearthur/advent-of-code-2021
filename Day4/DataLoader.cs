public static class DataLoader
{
    public static int[] LoadNumbers(string input)
    {
        return input.Split(',')
            .Select(x => int.Parse(x))
            .ToArray();
    }

    public static List<Board> LoadBoards(string[] input)
    {
        var boards = new List<Board>();
        for (var startPos = 0; startPos < input.Length; startPos += 6)
        {            
            var lineData = input.Skip(startPos).Take(5);
            var lines = new List<int[]>();
            foreach (var line in lineData)
            {
                lines.Add(Enumerable.Range(0, 5)
                    .Select(x => line.Substring(x * 3, 2))
                    .Select(i => int.Parse(i.Trim()))
                    .ToArray()
                );
            }

            boards.Add(new Board(lines));
        }

        return boards;
    }
}
