namespace Rendelosch.Dal.Extensions;

public static class Casts
{
    public static Models.FieldModel ToFieldModels(this Entities.FieldDto fieldDto)
    {
        return new Models.FieldModel
        {
            Key = fieldDto.Key,
            Name = fieldDto.Name
        };
    }
    
    public static List<Models.FieldModel> ToFieldModelsList(this List<Entities.FieldDto> fields)
    {
        List<Models.FieldModel> list = new();
        foreach (var field in fields)
        {
            list.Add(ToFieldModels(field));
        }
        return list;
    }
    
    public static Entities.FieldDto ToFieldEntities(this Models.FieldModel fieldModel)
    {
        return new Entities.FieldDto
        {
            Key = fieldModel.Key,
            Name = fieldModel.Name
        };
    }
    
    public static List<Entities.FieldDto> ToFieldEntitiesList(this List<Models.FieldModel> fields)
    {
        List<Entities.FieldDto> list = new();
        foreach (var field in fields)
        {
            list.Add(ToFieldEntities(field));
        }
        return list;
    }
}

