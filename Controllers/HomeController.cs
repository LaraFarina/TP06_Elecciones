using Microsoft.AspNetCore.Mvc;

namespace TP_06_RuizBarrea_Farina.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
