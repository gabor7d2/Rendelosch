namespace Rendelosch.Models;

public class Submission
{
    public readonly string Id;
    
    public readonly Dictionary<Field, string> FieldData;

    public Submission(string id, Dictionary<Field, string> fieldData)
    {
        Id = id;
        FieldData = fieldData;
    }
}