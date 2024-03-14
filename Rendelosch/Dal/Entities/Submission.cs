using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Rendelosch.Dal.Entities;

public class Submission
{
    public ObjectId Id { get; set; }
    
    public ObjectId FormId { get; set; }

    public Dictionary<string, string> FieldData { get; set; } = new();
    
}