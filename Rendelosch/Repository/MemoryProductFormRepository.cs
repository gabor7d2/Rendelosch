using Rendelosch.Models;

namespace Rendelosch.Repository;

public class MemoryProductFormRepository : IProductFormRepository
{
    private List<ProductForm> _productForms = new();

    public MemoryProductFormRepository()
    {
        var form1Fields = new List<Field>
        {
            new Field("name", "Név"),
            new Field("email", "Email"),
            new Field("size", "Méret (XS/S/M/L/XL/XXL)")
        };
        var sampleForm1 = new ProductForm("551d6601-7f08-4bd5-ab3a-a391c171e188", "DevTeam pulcsi", form1Fields);
        _productForms.Add(sampleForm1);
        
        var form2Fields = new List<Field>
        {
            new Field("name", "Név"),
            new Field("email", "Email"),
            new Field("phone_number", "Telefonszám"),
            new Field("colour", "Szín (sárga/zöld/kék)"),
            new Field("note", "Megjegyzés")
        };
        var sampleForm2 = new ProductForm("64996c3e-51ca-444a-90ec-b387f73a84ed", "DevTeam kiskacsa", form2Fields);
        _productForms.Add(sampleForm2);

        var sampleSubmission1FieldData = new Dictionary<Field, string>
        {
            { sampleForm1.Fields[0], "Kovács Béla" },
            { sampleForm1.Fields[1], "asd@gmail.com" },
            { sampleForm1.Fields[2], "M" }
        };
        var sampleSubmission1 = new Submission("ce9a1a9e-1123-464d-a3ec-740058502f6d", sampleSubmission1FieldData);
        sampleForm1.Submissions.Add(sampleSubmission1);
        
        var sampleSubmission2FieldData = new Dictionary<Field, string>
        {
            { sampleForm2.Fields[0], "Teszt Elek" },
            { sampleForm2.Fields[1], "erogr@sd.hu" },
            { sampleForm2.Fields[2], "06301234567" },
            { sampleForm2.Fields[3], "zöld" },
            { sampleForm2.Fields[4], "Rántotta" }
        };
        var sampleSubmission2 = new Submission("d84cf551-96cc-4620-962f-023fefa94b2f", sampleSubmission2FieldData);
        sampleForm2.Submissions.Add(sampleSubmission2);
        
        var sampleSubmission3FieldData = new Dictionary<Field, string>
        {
            { sampleForm1.Fields[0], "kisegér" },
            { sampleForm1.Fields[1], "123123" },
            { sampleForm1.Fields[2], "óriási, hatalmas, leviatán" }
        };
        var sampleSubmission3 = new Submission("106a67ca-acc0-42b5-9a40-18f12a6c7aa1", sampleSubmission3FieldData);
        sampleForm1.Submissions.Add(sampleSubmission3);
    }

    public List<ProductForm> GetProductForms()
    {
        return _productForms;
    }

    public ProductForm? GetProductForm(string formId)
    {
        return _productForms.Find(f => f.Id == formId);
    }

    public ProductForm CreateProductForm(string formTitle, List<Field> formFields)
    {
        var newForm = new ProductForm(Guid.NewGuid().ToString(), formTitle, formFields);
        _productForms.Add(newForm);
        return newForm;
    }

    public List<Submission>? GetSubmissionsForProductForm(string formId)
    {
        var form = _productForms.Find(f => f.Id == formId);
        if (form == null) return null;
        
        return form.Submissions;
    }

    public Submission? AddSubmissionToProductForm(string formId, Dictionary<string, string> fieldData)
    {
        // find form
        var form = _productForms.Find(f => f.Id == formId);
        if (form == null) return null;
        
        // construct submission field data
        var submissionFieldData = new Dictionary<Field, string>();
        foreach (var (key, value) in fieldData)
        {
            // find field in form
            var field = form.Fields.Find(f => f.Key == key);
            if (field == null) return null;
            submissionFieldData.Add(field, value);
        }
        
        var submission = new Submission(Guid.NewGuid().ToString(), submissionFieldData);
        form.Submissions.Add(submission);
        return submission;
    }
}