using CRUD.Attributes;

namespace CRUD.ViewModels;

public class EditGameFormViewModel : GameFormViewModel
{
    public int Id { get; set; }
    public string? CoverUrl { get; set; }
    [AllowedExtentions(FileSettings.AllowedExtensions), 
        MaxFileSize(FileSettings.MaxFileSizeInBytes)]
    public IFormFile? Cover { get; set; } = default!;
}