using MongoDB.Bson;

namespace Rendelosch.Dal.Entities;

public class SubmissionEntity
{
    public ObjectId Id { get; set; }
    
    public ObjectId ProductFormId { get; set; }

    public Dictionary<string, string> FieldData { get; set; } = new();
    
}