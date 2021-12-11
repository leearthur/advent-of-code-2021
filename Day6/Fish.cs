public class Fish
{
    public int Value { get; private set; }

    public Fish(int initialValue = 8)
    {
        Value = initialValue;
    }

    public bool Update()
    {       
        Value = Value == 0 ? 6 : Value - 1;
        return Value == 6;
    }
}
