using Microsoft.AspNetCore.Mvc.RazorPages;
using Rendelosch.Models;
using Rendelosch.Repository;

namespace Rendelosch.Pages;

public class CreateForm : PageModel
{
    public IProductFormRepository Repository { get; }
    
    public CreateForm(IProductFormRepository repository)
    {
        Repository = repository;
    }
    
    public void OnPost()
    {
        Request.Form.TryGetValue("formName", out var formName);
        Request.Form.TryGetValue("fields", out var formFields);
        
        string name = formName.ToString();
        string fields = formFields.ToString();
        
        List<Field> fieldsList = [];
        foreach (string fieldData in fields.Split(','))
        {
            string[] fieldDataArray = fieldData.Split(';');
            fieldsList.Add(new Field(fieldDataArray[0], fieldDataArray[1]));
        }

        Repository.CreateProductForm(name, fieldsList);
    }
}