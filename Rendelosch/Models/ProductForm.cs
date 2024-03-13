using System.Collections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Rendelosch.Models;

public class ProductForm
{
    [BsonId]
    public readonly string Id;
    
    [BsonElement("title")]
    public readonly string Title;
    
    [BsonElement("fields")]
    public readonly List<Field> Fields;
    [BsonConstructor]
    public ProductForm(string id, string title, List<Field> fields)
    {
        Id = id;
        Title = title;
        Fields = fields;
    }
}