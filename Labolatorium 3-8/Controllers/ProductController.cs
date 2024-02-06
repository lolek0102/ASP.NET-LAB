using Labolatorium_3_8.Models;
using Labolatorium_3_8.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace YourNamespace.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            ViewData["Visit"] = Response.HttpContext.Items[LastVisitCookie.CookieName];
            var productsList = _productService.GetAll();
            var productsDictionary = productsList.ToDictionary(p => p.Id, p => p);
            return View(productsDictionary);
        }
        public IActionResult FilteredIndex()
        {
            ViewData["Visit"] = Response.HttpContext.Items[LastVisitCookie.CookieName];
            var productsList = _productService.GetAll();
            var productsDictionary = productsList.ToDictionary(p => p.Id, p => p);
            return View(productsDictionary);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Suppliers = new SelectList(_productService.GetSuppliers(), "Id", "Name");
            ViewBag.ShippingCarriers = new SelectList(_productService.GetShippingCarriers(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productService.AssignSupplierAndCarrierToProduct(product);

            if (!ModelState.IsValid)
            {
                _productService.Add(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Suppliers = new SelectList(_productService.GetSuppliers(), "Id", "Name");
            ViewBag.ShippingCarriers = new SelectList(_productService.GetShippingCarriers(), "Id", "Name");

            var product = _productService.GetById(id);
            if (product != null)
            {
                return View(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            _productService.AssignSupplierAndCarrierToProduct(product);

            if (!ModelState.IsValid)
            {
                _productService.Update(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);
            if (product != null)
            {
                return View(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var product = _productService.GetById(id);
            if (product != null)
            {
                return View(product);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        public IActionResult GetFiltered(string filter)
        {
            var filteredProducts = _productService.GetAll()
                .Where(p => p.Name.StartsWith(filter))
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    p.Manufacturer,
                    ProductionDate = p.ProductionDate.ToShortDateString()
                })
                .ToList();

            return Ok(filteredProducts);
        }

        [HttpGet]
        public IActionResult AddSupplier()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSupplier(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _productService.AddSupplier(supplier);
                return RedirectToAction("Index"); // Możesz przekierować do innego widoku
            }
            return View(supplier);
        }

        [HttpGet]
        public IActionResult AddShippingCarrier()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddShippingCarrier(ShippingCarrier shippingCarrier)
        {
            if (ModelState.IsValid)
            {
                _productService.AddShippingCarrier(shippingCarrier);
                return RedirectToAction("Index"); // Możesz przekierować do innego widoku
            }
            return View(shippingCarrier);
        }
        [AllowAnonymous]
        public IActionResult PagedIndex(int page = 1, int size = 5)
        {
            var pagedResult = _productService.FindPage(page, size);
            return View(pagedResult);
        }
        private void PrepareSuppliersAndCarriers()
        {
            ViewBag.Suppliers = new SelectList(_productService.GetSuppliers(), "Id", "Name");
            ViewBag.ShippingCarriers = new SelectList(_productService.GetShippingCarriers(), "Id", "Name");
        }
    }
}
