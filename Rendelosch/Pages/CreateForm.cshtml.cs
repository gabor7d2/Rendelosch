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
        Request.Form.TryGetValue("form_title", out var title);
        Request.Form.TryGetValue("form_from_date", out var fromDate);
        Request.Form.TryGetValue("form_from_time", out var fromTime);
        Request.Form.TryGetValue("form_to_date", out var toDate);
        Request.Form.TryGetValue("form_to_time", out var toTime);
        Request.Form.TryGetValue("form_fields", out var fields);
        
        Console.WriteLine($"The form's title is: {title}");
        Console.WriteLine($"The form's from date is: {fromDate}");
        Console.WriteLine($"The form's from time is: {fromTime}");
        Console.WriteLine($"The form's to date is: {toDate}");
        Console.WriteLine($"The form's to time is: {toTime}");
        Console.WriteLine($"The form's fields are: {fields}");
    }
}