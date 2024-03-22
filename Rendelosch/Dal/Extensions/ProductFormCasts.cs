using Rendelosch.Dal.Entities;

namespace Rendelosch.Dal.Extensions;

public static partial class Casts
{
    public static Models.ProductFormModel ToProductFormModel(this Entities.ProductFormEntity productFormEntity)
    {
        return new Models.ProductFormModel
        {
            Id = productFormEntity.Id.ToString(),
            Title = productFormEntity.Title,
            StartDate = productFormEntity.StartDate,
            EndDate = productFormEntity.EndDate,
            Fields = productFormEntity.Fields.ToFieldModelList()
        };
    }
    
    public static List<Models.ProductFormModel> ToProductFormModelList(this IEnumerable<ProductFormEntity> productForms)
        => productForms.Select(ToProductFormModel).ToList();
    
    public static Entities.ProductFormEntity ToProductFormEntity(this Models.ProductFormModel productFormModel)
    {
        return new Entities.ProductFormEntity
        {
            Title = productFormModel.Title,
            StartDate = productFormModel.StartDate,
            EndDate = productFormModel.EndDate,
            Fields = productFormModel.Fields.ToFieldEntityList()
        };
    }
    
    public static List<Entities.ProductFormEntity> ToProductFormEntityList(this IEnumerable<Models.ProductFormModel> productForms)
        => productForms.Select(ToProductFormEntity).ToList();
}