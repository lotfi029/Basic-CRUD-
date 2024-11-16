using CRUD.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Services;

public class CategoriesService(ApplicationDbContext dbContext) : ICategoriesService
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public IEnumerable<SelectListItem> GetSelectList()
    {
        return _dbContext.Categories
            .Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name })
            .OrderBy(c => c.Text)
            .AsNoTracking()
            .ToList();
    }
}
