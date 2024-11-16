namespace CRUD.Services;

public class GameService : IGameService
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly string _imagePath;
    public GameService(
        ApplicationDbContext context,
        IWebHostEnvironment webHostEnvironment
        )
    {
        _webHostEnvironment = webHostEnvironment;
        _imagePath = $"{_webHostEnvironment.WebRootPath}/{FileSettings.ImagePath}"; 
        _context = context;
    }
    
    public async Task<IEnumerable<GameViewModel>> GetAll()
    {
        var games = await _context.Games.Include(e => e.Category)
            .Include(e => e.Devices)
            .ThenInclude(e => e.Device)
            .AsNoTracking()
            .Select(g => new GameViewModel
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description,
                CoverUrl = g.Cover,
                CategoryName = g.Category.Name,
                DevicesICons = g.Devices.Select(e => e.Device.ICon).ToList(),
            })
            .ToListAsync();

        return games;
    }
    public GameViewModel GetById(int id)
    {
        var game = _context.Games.Include(e => e.Category)
            .Include(e => e.Devices)
            .ThenInclude(e => e.Device)
            .AsNoTracking()
            .SingleOrDefault(e => e.Id == id);

        if (game == null)
            return null!;

        return new()
        {
            Id = game.Id,
            Name = game.Name,
            Description = game.Description,
            CoverUrl = game.Cover,
            CategoryName = game.Category.Name,
            DevicesICons = game.Devices.Select(e => e.Device.ICon).ToList()
        };
    }
    public async Task<Game?> Update(EditGameFormViewModel editModel)
    {
        if (editModel is null)
        {
            return null;
        }

        var game = _context.Games.Include(e => e.Category).Include(g => g.Devices).SingleOrDefault(e => e.Id == editModel.Id);
        if (game == null)
        {
            return null;
        }
        var hasCover = editModel.Cover is not null;
        var oldCover = game.Cover; 
        game.Name = editModel.Name;
        game.Description = editModel.Description;
        
        game.Devices = editModel.SelectedDevices.Select(e => new GameDevice { DeviceId = e }).ToList()!;
        game.CategoryId = editModel.CategoryId;
        
        if (hasCover)
            game.Cover = await SaveImageInServer(editModel.Cover!);

        _context.Update(game);
        var effectRows = _context.SaveChanges();
        if (effectRows > 0)
        {
            if (hasCover)
            {
                var cover = Path.Combine(_imagePath, oldCover);
                File.Delete(cover);
            }
        }
        else
        {
            if (hasCover)
            {
                var cover = Path.Combine(_imagePath, game.Cover);
                File.Delete(cover);
            }
            return null;
        }

        return game;
        
    }
    private async Task<string> SaveImageInServer(IFormFile cover)
    {
        var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";

        var path = Path.Combine(_imagePath, coverName);

        using var stream = File.Create(path);
        await cover.CopyToAsync(stream);

        return coverName;
    }
    public bool Delete(int id)
    {
        var isDelete = false;

        var game = _context.Games.Find(id);
        if (game == null)
            return isDelete;

        _context.Remove(game);

        var effectedRows = _context.SaveChanges();

        if (effectedRows > 0)
        {
            isDelete = true;
            
            var cover = Path.Combine(_imagePath, game.Cover);
            File.Delete(cover);
            
        }

        return isDelete;
    }
    public async Task Create(CreateGameViewModel model)
    {
        

        Game game = new()
        {
            Name = model.Name,
            CategoryId = model.CategoryId,
            Cover = await SaveImageInServer(model.Cover),
            Description = model.Description,
            Devices = model.SelectedDevices.Select(e => new GameDevice { DeviceId = e}).ToList()
        };
        _context.Add(game);
        _context.SaveChanges();
    }

    
}
