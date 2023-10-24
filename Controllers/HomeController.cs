using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using form_submission.Models;

namespace form_submission.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        return View("Index");
    }
    [HttpPost]
    [Route("register")]
    public IActionResult Submission(User survey)
    {
        if (ModelState.IsValid)
        {
            return View("Success", survey);
        }
        else
        {
            return View("Index", survey);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
