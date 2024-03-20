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
        Request.Form.TryGetValue("formName", out var _formName);
        Request.Form.TryGetValue("fields", out var _fields);
        
        string formName = _formName.ToString();
        string fields = _fields.ToString();
        
        List<Field> fieldsList = [];
        foreach (string fieldData in fields.Split(','))
        {
            string[] fieldDataArray = fieldData.Split(';');
            fieldsList.Add(new Field(fieldDataArray[0], fieldDataArray[1]));
        }

        Repository.CreateProductForm(formName.ToString(), fieldsList);
    }
}