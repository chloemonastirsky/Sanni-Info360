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
        List<Categoria> LCategorias = BD.GetCategorias();
        ViewBag.Restricciones=LCategorias;

        return View("restricciones", "Home");
    }

     public IActionResult verRestaurantes()
     {
        List<Restaurante> LRestaurantes = BD.GetRestaurantes();
        ViewBag.catalogoRestaurantes=BD.GetRestaurantes();
        
        return View("restaurantes", "Home");
     }
    
    public IActionResult verRestaurante(int idRestaurante)
     {
        Restaurante restaurante = BD.GetRestauranteBusqueda(idRestaurante);
        ViewBag.Restaurante=restaurante;
        List<Plato> LP=BD.GetPlatosRestaurante(idRestaurante);
        ViewBag.PlatosRestaurante=LP;
        List<Bebida> LB=BD.GetBebidasRestaurante(idRestaurante);
        ViewBag.BebidasRestaurante=LB;
        return View("restaurantes", "Home");
     }

     public IActionResult verPlato(int idPlato)
     {
        Plato plato = BD.GetPlatoBusqueda(idPlato);
        ViewBag.Plato=plato;
        
        return View("plato", "Home");
     }

     public IActionResult verFavoritos(int idUsuario)
     {
        List<FavAgregados> LFavs = BD.GetFavoritos(idUsuario);
        ViewBag.Favoritos=LFavs ;
        
        return View("favoritos", "Home");
     }

   //    public IActionResult verPromociones()
   //   {
        
   //      List<Promocion> LPromos = BD.GetPromociones();
   //      ViewBag.Promociones=LPromos  ;
        
   //      return View("promociones", "Home");
   //   }

     public IActionResult verNotificaciones(int idUsuario)
     {
        List<NotificacionesUsuario> LNotis = BD.GetNotificacionesUsuario(idUsuario);
        ViewBag.NotificacionesUsuario=LNotis;
        return View("notificaciones", "Home");
     }


      public IActionResult verPerfil(int idUsuario)
     {
        Usuario usuarioAVer = BD.GetUsuario(idUsuario);
        ViewBag.NombreUsuario=usuarioAVer.nombre;
        return View("Perfil", "Home");
     }

     public IActionResult verInfoUsuario(int idUsuario)
     {
        Usuario usuarioAVer = BD.GetUsuario(idUsuario);
        ViewBag.InfoUsuario=usuarioAVer;
        return View("Perfil", "Home");
     }
     

}

