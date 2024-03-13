using System.Collections;
using MongoDB.Bson.Serialization.Attributes;

namespace Rendelosch.Models;

public class ProductForm
{
    [BsonId]
    public readonly string Id;
    public readonly string Title;
    
    public readonly List<Field> Fields;

    public ProductForm(string id, string title, List<Field> fields)
    {
        Id = id;
        Title = title;
        Fields = fields;
    }
}