using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers;

public class AnalyzeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}