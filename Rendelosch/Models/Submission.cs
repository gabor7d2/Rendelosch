using MongoDB.Bson.Serialization.Attributes;

namespace Rendelosch.Models;

public class Submission
{
    public string Id { get; set; }
    
    public string FormId { get; set; }
    
    public Dictionary<string, string> FieldData { get; set; }
    
}