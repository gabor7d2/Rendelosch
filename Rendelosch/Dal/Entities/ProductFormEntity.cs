using MongoDB.Bson;

namespace Rendelosch.Dal.Entities;

public class ProductFormEntity
{
    public ObjectId Id { get; set; }
    
    public string Title { get; set; }
    
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
    
    public List<FieldEntity> Fields { get; set; }
    
    
}