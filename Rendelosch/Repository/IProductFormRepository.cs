using Rendelosch.Models;

namespace Rendelosch.Repository;

public interface IProductFormRepository
{
    public List<ProductForm> GetProductForms();

    public ProductForm? GetProductForm(string formId);
    
    public ProductForm CreateProductForm(string formTitle, List<Field> formFields);
    
    
    public List<Submission>? GetSubmissionsForProductForm(string formId);
    
    public Submission? AddSubmissionToProductForm(string formId, Dictionary<string, string> fieldData);
}