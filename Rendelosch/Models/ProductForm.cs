namespace Rendelosch.Models;

public class ProductForm
{
    public readonly string Id;
    public readonly string Title;
    
    public readonly List<Field> Fields = new();

    public ProductForm(string id, string title)
    {
        Id = id;
        Title = title;
    }
}