namespace CRUD.Controllers;
public class GamesController (
    ApplicationDbContext dbContext,
    ICategoriesService categoriesService,
    IDeviceService devicesService,
    IGameService gameService
    ): Controller
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ICategoriesService _categoriesService = categoriesService;
    private readonly IDeviceService _devicesService = devicesService;
    private readonly IGameService _gameService = gameService;

    public async Task<IActionResult> Index()
    {
        var games = await _gameService.GetAll();
        return View(games);
    }

    [HttpGet]
    public IActionResult Create()
    {
        CreateGameViewModel viewModel = new() 
        {
            Categories = _categoriesService.GetSelectList(),
            Devices = _devicesService.GetSelectList()
        };
        return View(viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateGameViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Categories = _categoriesService.GetSelectList();
            model.Devices = _devicesService.GetSelectList();

            return View(model);
        }
        await _gameService.Create(model);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult Details(int id)
    {
        var game = _gameService.GetById(id);
        
        if (game == null)
            return NotFound();

        return View(game);
    }
    [HttpGet]
    public IActionResult Edit(int id) 
    {
        //var game = _gameService.GetById(id);
        var game = _dbContext.Games
            .Include(e => e.Category)
            .Include(e => e.Devices)
            .SingleOrDefault(x => x.Id == id);

        if (game == null)
            return NotFound();

        EditGameFormViewModel viewModel = new()
        {
            Id = id,
            Description = game.Description,
            Name = game.Name,
            CategoryId = game.CategoryId,
            SelectedDevices = game.Devices.Select(e => e.DeviceId).ToList(),
            Categories = _categoriesService.GetSelectList(),
            Devices = _devicesService.GetSelectList(),
            CoverUrl = game.Cover
        };


        return View(viewModel);
    }
    [HttpPost]
    public IActionResult Edit(EditGameFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Categories = _categoriesService.GetSelectList();
            model.Devices = _devicesService.GetSelectList();

            return View(model);
        }
        var result = _gameService.Update(model);
        if (result is null)
        {
            return View(model);
        }

        return RedirectToAction(nameof(Index));
    }
    [HttpDelete] 
    public IActionResult Delete(int id)
    {
        var isDelete = _gameService.Delete(id);

        return isDelete ? Ok() : BadRequest();
    }

}
