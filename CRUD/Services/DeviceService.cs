using CRUD.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Services;

public class DeviceService(ApplicationDbContext context) : IDeviceService
{
    private readonly ApplicationDbContext _context = context;

    public IEnumerable<SelectListItem> GetSelectList()
    {
        return _context.Devices
                .Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name })
                .OrderBy(e => e.Text)
                .AsNoTracking()
                .ToList();
    }
}
