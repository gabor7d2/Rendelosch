namespace Rendelosch.Repository;

public interface IProductFormRepository
{
    
    public string CreateProductForm(string formTitle);

    public bool AddFieldToProductForm(string formId, string fieldName);
}