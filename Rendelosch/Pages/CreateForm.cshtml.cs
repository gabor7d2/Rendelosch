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

        
        if (fromTime == "") fromTime = "23:59";
        if (toTime == "") toTime = "23:59";

        var startDate = fromDate != "" ? ToDate(fromDate!, fromTime!) : DateTime.Now;
        var endDate = toDate != "" ? ToDate(toDate!, toTime!) : DateTime.MaxValue;
        
        Repository.CreateProductForm(title.ToString(), fieldsList, startDate, endDate);
        
        Response.Redirect("/");
    }

    private static DateTime ToDate(string date, string time)
    {
        var formattedDate = date.Split("-");
        var formattedTime = time.Split(":");
        return new DateTime(
            int.Parse(formattedDate[0]),
            int.Parse(formattedDate[1]),
            int.Parse(formattedDate[2]),
            int.Parse(formattedTime[0]),
            int.Parse(formattedTime[1]),
            0
        );
    }
}

