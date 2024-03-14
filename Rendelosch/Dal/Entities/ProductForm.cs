using System.Collections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Rendelosch.Dal.Entities;

public class ProductForm
{
    public ObjectId Id { get; set; }
    
    public string Title { get; set; }
    
    public List<Field> Fields { get; set; }
    
    
}