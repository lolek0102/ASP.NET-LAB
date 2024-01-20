using Labolatorium_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
public enum Operator
{
    Unknown, Add, Mul, Sub, Div
}
namespace Labolatorium_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Calculator(Operator op, double? a, double? b)
        {
            ViewBag.Op = op.ToString();
            ViewBag.A = a;
            ViewBag.B = b;
            return View();
        }
    }
}
