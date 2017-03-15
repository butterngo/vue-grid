namespace Web.MVC6.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Web.MVC6.Services;
    using Web.MVC6.ViewModels;

    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _productsService.GetAllAsync();

            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _productsService.GetByIdAsync(id);

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _productsService.CreateAsync(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var productToEdit = await _productsService.GetByIdAsync(id);

            if (productToEdit == null)
            {
                return NotFound();
            }

            return View(productToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _productsService.UpdateAsync(model);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var productToDelete = await _productsService.GetByIdAsync(id);

            if (productToDelete == null)
            {
                return NotFound();
            }

            return View(productToDelete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productsService.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
