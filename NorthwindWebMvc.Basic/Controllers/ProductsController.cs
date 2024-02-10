using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindWebMvc.Basic.Models;
using NorthwindWebMvc.Basic.Models.Dto;
using NorthwindWebMvc.Basic.Repository;
using NorthwindWebMvc.Basic.RepositoryContext;
using NorthwindWebMvc.Basic.Service;
using System.Net.Http.Headers;

namespace NorthwindWebMvc.Basic.Controllers
{
    public class ProductsController : Controller
    {
        private readonly RepositoryDbContext _context;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        private readonly IProductService _productService;

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(_productService.FindAll());
        }


        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {


            return View(_productService.FindById(id));
        }

        // GET: Products/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,Price,Stock,Photo,CategoryId")] ProductDto product)
        {
            _productService.Create(product);

            //            if (ModelState.IsValid)
            //            {

            //                try
            //                {
            //                    IFormFile file = product.Photo;
            //                    var folderName = Path.Combine("Resources", "Images");
            //                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            //                    if (file.Length > 0)
            //                    {
            //                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            //                        var fullPath = Path.Combine(pathToSave, fileName);
            //                        var dbPath = Path.Combine(folderName, fileName);
            //                        using (var stream = new FileStream(fullPath, FileMode.Create))
            //                        {
            //                            file.CopyTo(stream);
            //                        }

            //                        //collect data from dto dan filename
            //                        var categoryDto = new ProductDto()
            //                        {
            //                            Id = product.Id,
            //                            ProductName = product.ProductName,
            //                            Price = product.Price,
            //                            Stock = product.Stock,
            //                            Photo = fileName
            //,
            //                            CategoryId = 1,
            //                        };

            //                        _productService.Create(categoryDto);

            //                        return RedirectToAction(nameof(Index));

            //                    }
            //                }
            //                catch (Exception)
            //                {

            //                    throw;
            //                }
            //                return RedirectToAction(nameof(Index));
            //            }

            return RedirectToAction(nameof(Index));

        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(_productService.FindById(id));
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Price,Stock,Photo,CategoryId")] ProductDto product)
        {
            _productService.Update(product);
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {


            return View(_productService.FindById(id));
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _productService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
