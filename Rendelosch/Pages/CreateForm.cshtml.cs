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
        Request.Form.TryGetValue("title", out var title);
        Console.WriteLine($"The form's title is: {title})");
    }
}