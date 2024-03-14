namespace Rendelosch.Dal.Extensions;

public static class Casts
{
    public static Models.Field ToFieldModels(this Entities.Field field)
    {
        return new Models.Field
        {
            Key = field.Key,
            Name = field.Name
        };
    }
    
    public static List<Models.Field> ToFieldModelsList(this List<Entities.Field> fields)
    {
        List<Models.Field> list = new();
        foreach (var field in fields)
        {
            list.Add(ToFieldModels(field));
        }
        return list;
    }
    
    public static Entities.Field ToFieldEntities(this Models.Field field)
    {
        return new Entities.Field
        {
            Key = field.Key,
            Name = field.Name
        };
    }
    
    public static List<Entities.Field> ToFieldEntitiesList(this List<Models.Field> fields)
    {
        List<Entities.Field> list = new();
        foreach (var field in fields)
        {
            list.Add(ToFieldEntities(field));
        }
        return list;
    }
}

