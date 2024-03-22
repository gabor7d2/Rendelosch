using Microsoft.AspNetCore.Mvc.RazorPages;
using Rendelosch.Dal.Repository;
using Rendelosch.Models;

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
        Request.Form.TryGetValue("form_title", out var title);
        Request.Form.TryGetValue("form_from_date", out var fromDate);
        Request.Form.TryGetValue("form_from_time", out var fromTime);
        Request.Form.TryGetValue("form_to_date", out var toDate);
        Request.Form.TryGetValue("form_to_time", out var toTime);
        Request.Form.TryGetValue("form_fields", out var fields);
        
        List<FieldModel> fieldsList = [];
        foreach (var fieldString in fields.ToString().Split(';'))
        {
            var field = fieldString.Split(':');
            fieldsList.Add(new FieldModel
            {
                Key = field[0],
                Name = field[1],
                FieldType = FieldType.TEXT
            });
        }

        Repository.CreateProductForm(title.ToString(), fieldsList);
        
        Response.Redirect("/");
    }
}