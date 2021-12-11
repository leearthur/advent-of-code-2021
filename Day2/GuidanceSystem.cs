public class GuidanceSystem
{
    public int HorizontalPosition { get; private set; } 
    public int Depth { get; private set; }
    public int Aim { get; private set; } 

    private bool _adjustWithAim;

    public GuidanceSystem(bool adjustWithAim)
    {
        _adjustWithAim = adjustWithAim;
    }

    public void Adjust(string direction, int distance)
    {
        if (_adjustWithAim)
        {
            AdjustWithAim(direction, distance);
        }
        else
        {
            AdjustWithoutAim(direction, distance);
        }
    }

    private void AdjustWithoutAim(string direction, int distance)
    {
        switch (direction.ToLower())
        {
            case "up": 
                Depth -= distance;
                break;
            case "down":
                Depth += distance;
                break;
            case "forward":
                HorizontalPosition += distance;
                break;
            default: throw new InvalidOperationException("Unknown direction: " + direction);
        }
    }

    private void AdjustWithAim(string direction, int distance)
    {
        switch (direction.ToLower())
        {
            case "up": 
                Aim -= distance;
                break;
            case "down":
                Aim += distance;
                break;
            case "forward":
                HorizontalPosition += distance;
                Depth += (distance * Aim);
                break;
            default: throw new InvalidOperationException("Unknown direction: " + direction);
        }
    }
}