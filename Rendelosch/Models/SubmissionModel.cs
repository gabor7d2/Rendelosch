using MongoDB.Bson.Serialization.Attributes;

namespace Rendelosch.Models;

public class SubmissionModel
{
    public string Id { get; set; }
    
    public string ProductFormId { get; set; }
    
    public Dictionary<string, string> FieldData { get; set; }
    
}