using Rendelosch.Models;

namespace Rendelosch.Dal.Extensions;

public static partial class Casts
{
    public static Models.FieldModel ToFieldModel(this Entities.FieldEntity fieldEntity)
    {
        return new Models.FieldModel
        {
            Key = fieldEntity.Key,
            Name = fieldEntity.Name
        };
    }
    
    public static List<Models.FieldModel> ToFieldModelList(this IEnumerable<Entities.FieldEntity> fields)
        => fields.Select(ToFieldModel).ToList();
    
    public static Entities.FieldEntity ToFieldEntity(this Models.FieldModel fieldModel)
    {
        return new Entities.FieldEntity
        {
            Key = fieldModel.Key,
            Name = fieldModel.Name
        };
    }
    
    public static List<Entities.FieldEntity> ToFieldEntityList(this IEnumerable<FieldModel> fields)
        => fields.Select(ToFieldEntity).ToList();
}

