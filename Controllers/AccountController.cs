using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SANNI-INFO360.Models;

namespace TPToDo.Controllers;

public class accountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    
}