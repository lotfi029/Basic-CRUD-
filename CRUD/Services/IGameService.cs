namespace CRUD.Services;

public interface IGameService
{
    Task Create(CreateGameViewModel game);
    Task<IEnumerable<GameViewModel>> GetAll();
    Task<Game?> Update(EditGameFormViewModel editModel);
    bool Delete(int id);
    GameViewModel GetById(int id);
}
