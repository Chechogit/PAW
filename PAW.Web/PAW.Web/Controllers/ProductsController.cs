using Microsoft.AspNetCore.Mvc;
using PAW.Web.Models;
using PAW.Web.Services;

namespace PAW.Web.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: /Products
    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllAsync();
        return View(products);
    }

    // GET: /Products/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null) return NotFound();
        return View(product);
    }

    // GET: /Products/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Products/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        if (!ModelState.IsValid) return View(product);

        var created = await _productService.CreateAsync(product);
        if (created == null)
        {
            ModelState.AddModelError("", "No se pudo crear el producto.");
            return View(product);
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: /Products/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null) return NotFound();
        return View(product);
    }

    // POST: /Products/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Product product)
    {
        if (id != product.ProductId) return BadRequest();
        if (!ModelState.IsValid) return View(product);

        var success = await _productService.UpdateAsync(id, product);
        if (!success)
        {
            ModelState.AddModelError("", "No se pudo actualizar el producto.");
            return View(product);
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: /Products/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null) return NotFound();
        return View(product);
    }

    // POST: /Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _productService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
