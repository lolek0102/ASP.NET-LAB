using Labolatorium_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_2.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Result(Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            var result = model.Calculate();
            ViewBag.Result = result;
            return View(model);
        }
        public IActionResult Form()
        {
            return View();
        }
    }
}
