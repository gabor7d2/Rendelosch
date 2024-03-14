using Rendelosch.Models;

namespace Rendelosch.Dal.Repository;

public interface IProductFormRepository
{
    public List<ProductForm> GetProductForms();

    public ProductForm? GetProductForm(string formId);
    
    public ProductForm CreateProductForm(string formTitle, List<Field> formFields);
    
    
    public List<Submission>? GetSubmissionsForProductForm(string formId);
    
    public void AddSubmissionToProductForm(string formId, Dictionary<string, string> fieldData);
}