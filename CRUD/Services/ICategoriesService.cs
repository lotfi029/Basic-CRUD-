using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUD.Services;

public interface ICategoriesService 
{
    IEnumerable<SelectListItem> GetSelectList();
}
