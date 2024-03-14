using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rendelosch.Dal.Repository;
using Rendelosch.Repository;

namespace Rendelosch.Pages;

public class Index : PageModel
{
    public IProductFormRepository Repository { get; }
    
    public Index(IProductFormRepository repository)
    {
        Repository = repository;
    }
}