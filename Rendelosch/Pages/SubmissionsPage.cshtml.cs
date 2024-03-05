using Microsoft.AspNetCore.Mvc.RazorPages;
using Rendelosch.Repository;

namespace Rendelosch.Pages.Shared;

public class SubmissionsPage : PageModel
{
    
    public IProductFormRepository Repository { get; }
    
    public SubmissionsPage(IProductFormRepository repository)
    {
        Repository = repository;
    }
    
    public void OnGet()
    {
        
    }
}