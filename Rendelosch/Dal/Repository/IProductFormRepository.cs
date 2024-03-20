using Rendelosch.Models;

namespace Rendelosch.Dal.Repository;

public interface IProductFormRepository
{
    public List<ProductFormModel> GetProductForms();

    public ProductFormModel? GetProductForm(string formId);
    
    public ProductFormModel CreateProductForm(string formTitle, List<FieldModel> formFields);
    
    
    public List<SubmissionModel>? GetSubmissionsForProductForm(string formId);
    
    public void AddSubmissionToProductForm(string formId, Dictionary<string, string> fieldData);
}