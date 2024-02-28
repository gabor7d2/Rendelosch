using Microsoft.AspNetCore.Mvc.RazorPages;
using Rendelosch.Repository;

namespace Rendelosch.Pages;

public class SubmitForm : PageModel
{
    public IProductFormRepository Repository { get; }
    
    public SubmitForm(IProductFormRepository repository)
    {
        Repository = repository;
    }
    
    public void OnPost()
    {
        
    }
}