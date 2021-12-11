public class Day4
{
    public long Part1(int[] numbers, List<Board> boards)
    {
        foreach(var number in numbers)
        {
            boards.ForEach(b => b.MarkNumber(number));
            var bingo = boards.FirstOrDefault(b => b.Bingo());
            if (bingo != null)
            {
                var unmarked = bingo.GetUnmarkedSum();
                return unmarked * number;
            }
        }

        return 0;
    }

    public long Part2(int[] numbers, List<Board> boards)
    {
        foreach(var number in numbers)
        {
            boards.ForEach(b => b.MarkNumber(number));
            var bingos = boards.Where(b => b.Bingo()).ToArray();

            if (boards.Count == 1 && bingos.Any())
            {
                var unmarked = bingos.First().GetUnmarkedSum();
                return unmarked * number;
            }

            RemoveBoards(boards, bingos);
        }

        return 0;
    }

    private void RemoveBoards(List<Board> boards, Board[] bingos)
    {
        if (boards.Count() <= 1)
        {
            return;
        }

        foreach(var bingoBoard in bingos)
        {
            boards.Remove(bingoBoard);
        }
    }
}