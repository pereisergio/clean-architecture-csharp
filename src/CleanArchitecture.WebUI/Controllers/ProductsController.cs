using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productAppService)
        {
            _productService = productAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsAsync();
            return View(products);
        }
    }
}
