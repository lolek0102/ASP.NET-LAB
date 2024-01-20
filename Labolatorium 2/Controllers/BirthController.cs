using Labolatorium_2;
using Microsoft.AspNetCore.Mvc;

public class BirthController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Result(BirthModel model)
    {
        if (!model.IsValid())
        {
            return View("Error");
        }
        return View(model);
    }
}
