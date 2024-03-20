using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rendelosch.Dal.Repository;
using Rendelosch.Repository;

namespace Rendelosch.Pages;

public class SubmitForm : PageModel
{
    public IProductFormRepository Repository { get; }
    
    public SubmitForm(IProductFormRepository repository)
    {
        Repository = repository;
    }
    
    public IActionResult OnPost()
    {
        var formId = Request.RouteValues["Id"]?.ToString();
        if (formId is null) return BadRequest();
        var form = Repository.GetProductForm(formId);
        if (form == null) return BadRequest();
        if (form.StartDate > DateTime.Now || form.EndDate < DateTime.Now) return BadRequest();
        var dictionary = new Dictionary<string, string>();

        foreach (var field in form.Fields)
        {
            if (Request.Form[field.Key] == "") return BadRequest();
            dictionary.Add(field.Key, Request.Form[field.Key]);
        }

        Repository.AddSubmissionToProductForm(formId, dictionary);
        return Redirect("/");
    }
}