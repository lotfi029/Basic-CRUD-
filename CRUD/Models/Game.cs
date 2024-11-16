namespace CRUD.Models;
public class Game : BaseModel
{
    public string Description { get; set; } = string.Empty;
    public string Cover { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = default!;
    public virtual ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();
}