using Labolatorium_3_8.Data;
using Microsoft.AspNetCore.Mvc;

[Route("api/products")]
[ApiController]
public class ProductApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductApiController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetFiltered(string filter)
    {
        return Ok(_context.Products
            .Where(p => p.Name.StartsWith(filter))
            .Select(p => new { p.Name, p.Id })
            .ToList());
    }
}
