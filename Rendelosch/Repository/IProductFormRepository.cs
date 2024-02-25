using Rendelosch.Models;

namespace Rendelosch.Repository;

public interface IProductFormRepository
{
    public List<ProductForm> GetProductForms();
    
    public string CreateProductForm(string formTitle);

    public bool AddFieldToProductForm(string formId, string fieldName);
}