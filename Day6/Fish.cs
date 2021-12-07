public class Fish
{
    public int Value { get; set; }

    public Fish(int initialValue = 8)
    {
        Value = initialValue;
    }

    public bool Update()
    {
        if (Value == 0)
        {
            Value = 6;
            return true;
        }
        Value -= 1;
        return false;
    }
}
