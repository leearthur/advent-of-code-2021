public class ValidationException : Exception
{
    public char IllegalCharacter { get; }

    public ValidationException(char illegalCharacter)
    {
        IllegalCharacter = illegalCharacter;
    }
}