using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPToDo.Models;

namespace TPToDo.Controllers;

public class accountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    
}