using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUD.Services;

public interface IDeviceService
{
    IEnumerable<SelectListItem> GetSelectList();
}
