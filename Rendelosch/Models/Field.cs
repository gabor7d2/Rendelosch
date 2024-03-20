using MongoDB.Bson.Serialization.Attributes;

namespace Rendelosch.Models;

public class Field
{
    public string Key { get; set; }
    
    public string Name { get; set; }
    
    public FieldType FieldType { get; set; }
}