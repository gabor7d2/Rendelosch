using Rendelosch.Models;

namespace Rendelosch.Repository;

public class MemoryProductFormRepository : IProductFormRepository
{
    private List<ProductForm> _productForms = new();

    public MemoryProductFormRepository()
    {
        var sampleForm1 = new ProductForm(Guid.NewGuid().ToString(), "DevTeam pulcsi");
        sampleForm1.Fields.Add(new Field("Név"));
        sampleForm1.Fields.Add(new Field("Email"));
        sampleForm1.Fields.Add(new Field("Méret (XS/S/M/L/XL/XXL)"));
        
        var sampleForm2 = new ProductForm(Guid.NewGuid().ToString(), "DevTeam kiskacsa");
        sampleForm2.Fields.Add(new Field("Név"));
        sampleForm2.Fields.Add(new Field("Email"));
        sampleForm2.Fields.Add(new Field("Telefonszám"));
        sampleForm2.Fields.Add(new Field("Szín (sárga/zöld/kék)"));
        sampleForm2.Fields.Add(new Field("Megjegyzés"));
        
        _productForms.Add(sampleForm1);
        _productForms.Add(sampleForm2);
    }
    
    public string CreateProductForm(string formTitle)
    {
        var guid = Guid.NewGuid().ToString();
        _productForms.Add(new ProductForm(guid, formTitle));
        return guid;
    }

    public bool AddFieldToProductForm(string formId, string fieldName)
    {
        var form = _productForms.Find(f => f.Id == formId);
        if (form == null) return false;
        form.Fields.Add(new Field(fieldName));
        
        return true;
    }
}