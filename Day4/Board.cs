public class Board
{
    private Number[,] _data = new Number[5,5];
    private bool _bingo;

    public Board(List<int[]> lines)
    {
        for (var x = 0; x < lines.Count(); x++)
        {
            for (var y = 0; y < 5; y++)
            {
                _data[x, y] = new Number(lines[x][y], x, y);
            }
        }
    }

    public void MarkNumber(int number)
    {
        var match = _data.Cast<Number>().FirstOrDefault(d => d.Value == number);
        if (match != null)
        {
            match.Drawn = true;
            SetBingo(GetRow(match.Row));
            SetBingo(GetColumn(match.Column));
        }
    }

    public bool Bingo()
    {
        return _bingo;
    }

    private IEnumerable<Number> GetRow(int index)
    {
        return Enumerable.Range(0, 5).Select(x => _data[index, x]);
    }

    private IEnumerable<Number> GetColumn(int index)
    {
        return Enumerable.Range(0, 5).Select(x => _data[x, index]);
    }

    private void SetBingo(IEnumerable<Number> values)
    {
        if (!_bingo)
        {
            _bingo = values.All(x => x.Drawn);
        }
    }

    public int GetUnmarkedSum()
    {
        return _data.Cast<Number>()
            .Where(d => d.Drawn == false)
            .Sum(x => x.Value);
    }
}
public class Number
{
    public int Value { get; }
    public bool Drawn { get; set ; }
    public int Row { get; }
    public int Column { get; }

    public Number(int number, int row, int column)
    {
        Value = number;
        Row = row;
        Column = column;
    }
}