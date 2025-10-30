using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TPToDo.Controllers;

public class accountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    
}