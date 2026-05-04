namespace project.ViewComponent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Data;

public class AdopterSummaryViewComponent : ViewComponent
{
    public readonly ApplicationDbContext _context;
    public AdopterSummaryViewComponent (ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var count = await _context.Adopters.CountAsync();
        return View(count);
    }
}