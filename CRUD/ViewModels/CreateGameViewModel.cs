using CRUD.Attributes;

namespace CRUD.ViewModels;
public class CreateGameViewModel : GameFormViewModel
{
    [AllowedExtentions(FileSettings.AllowedExtensions), MaxFileSize(FileSettings.MaxFileSizeInBytes)]
    public IFormFile Cover { get; set; } = default!;
}
