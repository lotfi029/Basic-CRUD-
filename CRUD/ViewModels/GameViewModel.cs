namespace CRUD.ViewModels;

public class GameViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CoverUrl { get; set; } = string.Empty;
    public string CategoryName { get; set; }  = string.Empty;
    public ICollection<string> DevicesICons { get; set; } = new List<string>();
}
