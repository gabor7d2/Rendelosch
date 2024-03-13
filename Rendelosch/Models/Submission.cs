using MongoDB.Bson.Serialization.Attributes;

namespace Rendelosch.Models;

public class Submission
{
    [BsonId]
    public readonly string Id;
    
    [BsonElement("formId")]
    public readonly string FormId;
    
    [BsonElement("fieldData")]
    public readonly Dictionary<string, string> FieldData;

    public Submission(string id, Dictionary<string, string> fieldData)
    {
        Id = id;
        FieldData = fieldData;
    }
}