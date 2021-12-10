using System.ComponentModel;
using Htmx;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static CronExpressionDescriptor.ExpressionDescriptor;

namespace CronDescriber.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> logger;

    [DisplayName("Cron Expression")]
    [BindProperty(Name = "cron", SupportsGet = true)]
    public string Cron { get; set; } = "";

    public string? Description { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        this.logger = logger;
    }

    public IActionResult OnGet()
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(Cron))
            {
                Description = GetDescription(Cron);
            }
        }
        catch (Exception e)
        {
            Description = null;
        }
        
        Response.Htmx(h => {
            // we want to push the current url 
            // into the history
            h.Push(Request.GetEncodedUrl());
        });

        return Request.IsHtmx()
            ? Partial("_Result", this)
            : Page();
    }
}