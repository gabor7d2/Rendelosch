using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rendelosch.Repository;

namespace Rendelosch.Pages;

public class Index : PageModel
{
    private readonly IProductFormRepository _repository;

    public Index(IProductFormRepository repository)
    {
        _repository = repository;
    }
    
    public void OnGet()
    {
        
    }

    public void OnPost()
    {
        
    }
}