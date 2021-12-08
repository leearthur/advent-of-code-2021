public class Data
{
    public string[] Input { get; }
    public string[] Output {get;set;}

    public Data(string data)
    {
        var splitData = data.Split('|');
        Input = ExtractData(splitData[0]);
        Output = ExtractData(splitData[1]);        
    }

    private string[] ExtractData(string data)
    {
        return data.Split(' ')
            .Select(x => x.Trim())
            .Where(y => !string.IsNullOrEmpty(y))
            .ToArray();
    }
}