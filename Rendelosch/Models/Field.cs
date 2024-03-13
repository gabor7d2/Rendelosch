using MongoDB.Bson.Serialization.Attributes;

namespace Rendelosch.Models;

public class Field
{
    [BsonElement("key")]
    public readonly string Key;
    
    [BsonElement("name")]
    public readonly string Name;

    public Field(string key, string name)
    {
        Key = key;
        Name = name;
    }
}