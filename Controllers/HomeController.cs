using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sanni.Models;

namespace Sanni.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("Index", "Home");
    }

    public IActionResult verRestricciones()
    {
        List<Categorias> LCategorias = BD.GetCategorias();
        ViewBag.Restricciones=LCategorias;

        return View("restricciones", "Home");
    }

     public IActionResult verRestaurantes()
     {
        List<Restaurantes> LRestaurantes = BD.GetRestaurantes();
        ViewBag.catalogoRestaurantes=BD.GetRestaurantes();
        
        return View("restaurantes", "Home");
     }
    
    public IActionResult verRestaurante(int idRestaurante)
     {
        Restaurantes restaurante = BD.GetRestauranteBusqueda(idRestaurante);
        ViewBag.Restaurante=restaurante;
        
        return View("restaurantes", "Home");
     }

     public IActionResult verPlato(int idPlato)
     {
        Platos plato = BD.GetPlatoeBusqueda(idPlato);
        ViewBag.Plato=plato;
        
        return View("plato", "Home");
     }

      public IActionResult verPlato(int idPlato)
     {
        Platos plato = BD.GetPlatoeBusqueda(idPlato);
        ViewBag.Plato=plato;
        
        return View("plato", "Home");
     }
}