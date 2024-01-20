using Labolatorium_3_8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YourNamespace.Controllers
{
    public class ProductController : Controller
    {
        private static Dictionary<int, Product> _products = new Dictionary<int, Product>();

        public IActionResult Index()
        {
            return View(_products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                int id = _products.Count + 1;
                product.Id = id;
                _products.Add(id, product);

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
            if (_products.ContainsKey(id))
            {
                return View(_products[id]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                _products[id] = product;
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
            if (_products.ContainsKey(id))
            {
                return View(_products[id]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _products.Remove(id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            if (_products.ContainsKey(id))
            {
                return View(_products[id]);
            }
            else
            {
                return NotFound();
            }
        }


    }
}
