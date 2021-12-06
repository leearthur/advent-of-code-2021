public class Line
{
    public Coordinate StartCoordinate { get; set; }
    public Coordinate EndCoordinate { get; set; }

    public Line(string startCords, string endCords)
    {
        StartCoordinate = new Coordinate(startCords);
        EndCoordinate = new Coordinate(endCords);
    }

    public Coordinate[] LocationHits(bool simple)
    {
        var coordinates = new List<Coordinate>();
        if (simple && (StartCoordinate.PosX != EndCoordinate.PosX && StartCoordinate.PosY != EndCoordinate.PosY))
        {
            return coordinates.ToArray();
        }

        var x = StartCoordinate.PosX;
        var y = StartCoordinate.PosY;
        while (true)
        {
            coordinates.Add(new Coordinate($"{x},{y}"));
            if (x == EndCoordinate.PosX && y == EndCoordinate.PosY)
            {
                break;
            }

            x = NextValue(x, EndCoordinate.PosX);
            y = NextValue(y, EndCoordinate.PosY);
        }

        return coordinates.ToArray();
    }

    private int NextValue(int start, int end)
    {
        if (start > end)
        {
            return start - 1;
        }
        if (start < end)
        {
            return start + 1;
        }
        return start;
    }
}

public class Coordinate
{
    public int PosX { get; set; }
    public int PosY { get; set; }    
    
    public Coordinate(string coordinates)
    {
        var data = coordinates.Split(',');
        PosX = int.Parse(data[0]);
        PosY = int.Parse(data[1]);
    }

    public string Id()
    {
        return $"{PosX},{PosY}";
    }
}