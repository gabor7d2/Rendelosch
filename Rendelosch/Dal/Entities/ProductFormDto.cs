using System.Collections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Rendelosch.Dal.Entities;

public class ProductFormDto
{
    public ObjectId Id { get; set; }
    
    public string Title { get; set; }
    
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
    
    public List<FieldDto> Fields { get; set; }
    
    
}