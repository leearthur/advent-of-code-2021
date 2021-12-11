public class Grid
{
    public int[,] Values { get; }
    public int TotalFlashes { get; private set; }
    public int StepFlashes { get; private set; }

    public Grid(string[] input)
    {
        Values = new int[input.Length, input[0].Length];
        for (var y = 0; y < input.Length; y++)
        {
            for (var x = 0; x < input[0].Length; x++)
            {
                Values[y, x] = int.Parse(input[y][x].ToString());
            }
        }
    }

    public void Step()
    {
        for (var y = 0; y < Values.GetLength(0); y++)
        {
            for (var x = 0; x < Values.GetLength(1); x++)
            {
                ProcessValue(x, y);
            }
        }

        StepFlashes = 0;
        for (var y = 0; y < Values.GetLength(0); y++)
        {
            for (var x = 0; x < Values.GetLength(1); x++)
            {
                if(Values[y, x] > 9)
                {
                    StepFlashes++;
                    Values[y, x] = 0;
                };
            }
        }
    }

    public void ProcessValue(int x, int y)
    {
        if (Values[y, x] > 9)
        {
            return;
        }

        Values[y, x] += 1;
        if (Values[y, x] > 9)
        {
            TotalFlashes++;

            if (x > 0) ProcessValue(x - 1, y);
            if (x < Values.GetLength(1) - 1) ProcessValue(x + 1, y);

            if (y > 0) ProcessValue(x, y - 1);
            if (y < Values.GetLength(0) - 1) ProcessValue(x, y + 1);

            if (x > 0 && y > 0) ProcessValue(x - 1, y - 1);
            if (x < Values.GetLength(1) - 1 && y > 0) ProcessValue(x + 1, y - 1);

            if (x > 0 && y < Values.GetLength(0) - 1) ProcessValue(x - 1, y + 1);
            if (x < Values.GetLength(1) - 1 && y < Values.GetLength(0) - 1) ProcessValue(x + 1, y + 1);
        }
    }

    public void Print(int id)
    {
        Console.WriteLine("--------------------------");
        Console.WriteLine($"[After Step: {id}]");
        for (var y = 0; y < Values.GetLength(0); y++)
        {
            Console.Write("");
            for (var x = 0; x < Values.GetLength(1); x++)
            {
                Console.Write($"{Values[y, x]}");
            }
            Console.Write(Environment.NewLine);
        }
    }
}