public class Day2
{
    public long Part1(string[] input)
    {        
        var guidance = new GuidanceSystem(false);
        return ExecuteMovement(input, guidance);
    }

    public long Part2(string[] input)
    {
        var guidance = new GuidanceSystem(true);
        return ExecuteMovement(input, guidance);
    }

    private long ExecuteMovement(string[] input, GuidanceSystem guidance)
    {
        foreach(var position in input)
        {
            var splitValue = position.Split(' ');
            guidance.Adjust(splitValue[0], int.Parse(splitValue[1]));
        }

        return guidance.HorizontalPosition * guidance.Depth;
    }
}
