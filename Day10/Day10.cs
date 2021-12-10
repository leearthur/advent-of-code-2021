public class Day10
{
    public long Part1(string[] input)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine($"----------------------------------");

        var illegalCharacter = new List<char>();
        foreach (var row in input.Where(i => !string.IsNullOrEmpty(i)))
        {
            var currentPos = -1;
            while (true)
            {
                currentPos++;
                var genisisChunk = new Chunk(row[currentPos], currentPos);
                try
                {
                    currentPos = genisisChunk.Validate(row);
                    if (currentPos == row.Length - 1)
                    {
                        break;
                    }
                }
                catch (ValidationException ex)
                {
                    illegalCharacter.Add(ex.IllegalCharacter);
                    break;
                }
            }
        }

        Console.WriteLine($"Illegal Character Count: {illegalCharacter.Count}");
        Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds}");
        return illegalCharacter.Sum(c => Score(c));
    }

    public long Part2(string[] input)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine($"----------------------------------");

        var autoCorrectScore = new List<long>();
        Chunk genisisChunk;
        foreach (var row in input.Where(i => !string.IsNullOrEmpty(i)))
        {
            var currentPos = -1;

            while (true)
            {
                currentPos++;
                genisisChunk = new Chunk(row[currentPos], currentPos);
                try
                {
                    currentPos = genisisChunk.Validate(row);
                    if (currentPos == row.Length - 1)
                    {
                        break;
                    }
                }
                catch (ValidationException)
                {
                    break;
                }
            }
            if (genisisChunk.AutoComplete.Count > 0)
            {
                var score = 0L;
                foreach(var autocomplete in genisisChunk.AutoComplete)
                {
                    score *= 5;
                    score += ScoreAutoCorrect(autocomplete);
                }
                autoCorrectScore.Add(score);
            }
        }

        Console.WriteLine($"Auto Correct Count: {autoCorrectScore.Count}");
        var ordered = autoCorrectScore.OrderBy(x => x).ToArray();
        foreach (var score in ordered)
        {
            Console.WriteLine($"--> {score}");
        }

        Console.WriteLine($"Execution Time: {sw.ElapsedMilliseconds}");
        return ordered[(ordered.Length - 1) / 2];
    }

    private static int Score(char character)
    {
        return character switch
        {
            ')' => 3,
            ']' => 57,
            '}' => 1197,
            '>' => 25137,
            _ => 0,
        };
    }

    private static int ScoreAutoCorrect(char character)
    {
        return character switch
        {
            ')' => 1,
            ']' => 2,
            '}' => 3,
            '>' => 4,
            _ => 0,
        };
    }
}