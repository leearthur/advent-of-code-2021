public class Chunk
{
    public static char[] StartingCharacters = new[] { '(', '[', '{', '<' }; 
    //public static char[] EndingCharacters = new[] { ')', ']', '}', '>' }; 

    public char Character { get; }
    public int StartPos { get; }
    public List<Chunk> Children { get; } = new();
    public List<char> AutoComplete { get; } = new();

    public char IllegalCharacter { get; private set;  }

    public Chunk(char character, int startPos)
    {
        Character = character;
        StartPos = startPos;
    }

    public int Validate(string input)
    {
        for (var currentPos = StartPos + 1; currentPos < input.Length; currentPos++)
        {
            if (StartingCharacters.Contains(input[currentPos]))
            {
                var child = new Chunk(input[currentPos], currentPos);
                Children.Add(child);
                currentPos = child.Validate(input);
                AutoComplete.AddRange(child.AutoComplete);
                if (currentPos == input.Length - 1)
                {
                    AutoComplete.Add(ClosingCharacter());
                    return input.Length - 1;
                }
                continue;
            }

            if (input[currentPos] == ClosingCharacter())
            {
                return currentPos;
            }

            IllegalCharacter = input[currentPos];
            throw new ValidationException(IllegalCharacter);
        }
        AutoComplete.Add(ClosingCharacter());
        return input.Length - 1;
    }

    private char ClosingCharacter()
    {
        switch (Character)
        {
            case '(': return ')';
            case '[': return ']';
            case '{': return '}';
            case '<': return '>';
            default:
                throw new ArgumentException("Unknown character specified");
        }
    }
}