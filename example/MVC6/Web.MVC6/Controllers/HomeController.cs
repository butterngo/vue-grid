namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Web.MVC6.Services;
    using Web.MVC6.ViewModels;

    public class HomeController : Controller
    {
        private ICategoryService _categoryService;

        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();

            return View(new CategoriesViewModel { Categories = categories });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Action = "Edit";

            var model = await _categoryService.GetByIdAsync(id);

            return View("EditAndCreate", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel model)
        {
            await _categoryService.UpdateAsync(model);

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Action = "Create";

            return View("EditAndCreate", new CategoryViewModel ());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            await _categoryService.CreateAsync(model);

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);

            return RedirectToAction("index");
        }
    }
}
