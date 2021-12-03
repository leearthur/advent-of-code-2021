public class Day2
{
    public int Part1(string[] input)
    {
        var calcualtor = new PositionCalculator();
        foreach(var positionChange in input)
        {
            var splitValue = positionChange.Split(' ');
            calcualtor.AdjustWithoutAim(splitValue[0], int.Parse(splitValue[1]));
        }

        return calcualtor.HorizontalPosition * calcualtor.Depth;
    }

    public int Part2(string[] input)
    {
        var calcualtor = new PositionCalculator();
        foreach(var positionChange in input)
        {
            var splitValue = positionChange.Split(' ');
            calcualtor.AdjustWithAim(splitValue[0], int.Parse(splitValue[1]));
        }

        return calcualtor.HorizontalPosition * calcualtor.Depth;
    }
}

public class PositionCalculator
{
    public int HorizontalPosition { get; private set; } 
    public int Depth { get; private set; }
    public int Aim { get; private set; } 

    public void AdjustWithoutAim(string direction, int distance)
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

    public void AdjustWithAim(string direction, int distance)
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
