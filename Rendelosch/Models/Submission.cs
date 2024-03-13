using MongoDB.Bson.Serialization.Attributes;

namespace Rendelosch.Models;

public class Submission
{
    [BsonId]
    public readonly string Id;

    public readonly string ProductFormId;
    
    public readonly Dictionary<string, string> FieldData;

    public Submission(string id, Dictionary<string, string> fieldData)
    {
        Id = id;
        FieldData = fieldData;
    }
}