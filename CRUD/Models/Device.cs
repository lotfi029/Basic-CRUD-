namespace CRUD.Models;
public class Device : BaseModel
{
    public string ICon { get; set; } = string.Empty;
    public virtual ICollection<GameDevice> Games { get; set; } = new List<GameDevice>();
}
