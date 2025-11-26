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
        // CORRECCIÓN: Si el archivo se llama Index.cshtml, basta con llamar a View()
        return View();
    }

    public IActionResult verRestricciones()
    {
        List<Categoria> LCategorias = BD.GetCategorias();
        ViewBag.Restricciones = LCategorias;

        // CORRECCIÓN: Retorna la vista "restricciones"
        return View("restricciones");
    }

    public IActionResult verRestaurantes()
    {
        List<Restaurante> LRestaurantes = BD.GetRestaurantes();
        ViewBag.catalogoRestaurantes = BD.GetRestaurantes();
        
        // CORRECCIÓN: Retorna la vista "restaurantes"
        return View("restaurantes");
    }
    
    public IActionResult verRestaurante(int idRestaurante)
    {
        Restaurante restaurante = BD.GetRestauranteBusqueda(idRestaurante);
        ViewBag.Restaurante = BD.GetRestauranteBusqueda(idRestaurante);
        List<Plato> LP = BD.GetPlatosRestaurante(idRestaurante);
        ViewBag.PlatosRestaurante = LP;
        List<Bebida> LB = BD.GetBebidasRestaurante(idRestaurante);
        ViewBag.BebidasRestaurante = LB;
        List<Promocion>LPromos=BD.GetPromosRestaurante(idRestaurante);
        ViewBag.Promos=LPromos;
        
        return View("Restaurante"); 
    }

    public IActionResult verPlato(int idPlato)
    {
        Plato plato = BD.GetPlatoBusqueda(idPlato);
        int idRestaurante= plato.idRestaurante;
        ViewBag.Plato = plato;
        Restaurante restaurantePlato=BD.GetRestauranteBusqueda(idRestaurante);
        ViewBag.restaurante=restaurantePlato;
        string nombreRestaurante=restaurantePlato.nombre;
        ViewBag.nombreRestaurante=nombreRestaurante;
        return View("Plato");
    }

    public IActionResult verBebida(int idBebida)
    {
        Bebida bebida = BD.GetBebidaBusqueda(idBebida);
        ViewBag.Bebida = bebida;
        return View("bebida");
    }


    public IActionResult verFavoritos(int idUsuario)
    {
        List<FavAgregados> LFavs = BD.GetFavoritos(idUsuario);
        ViewBag.Favoritos = LFavs;
        return View("favoritos");
    }

    // Si quieres usar esta acción, debes descomentarla y corregirla:
    // public IActionResult verPromociones()
    // {
    //     List<Promocion> LPromos = BD.GetPromociones();
    //     ViewBag.Promociones = LPromos;
    //     return View("promociones");
    // }

    public IActionResult verNotificaciones(int idUsuario)
    {
        List<NotificacionesUsuario> LNotis = BD.GetNotificacionesUsuario(idUsuario);
        ViewBag.NotificacionesUsuario = LNotis;
        // CORRECCIÓN: Retorna la vista "notificaciones"
        return View("notificaciones");
    }


    public IActionResult verPerfil(int idUsuario)
    {
        Usuario usuarioAVer = BD.GetUsuario(idUsuario);
        ViewBag.NombreUsuario = usuarioAVer.nombre;
        ViewBag.DireccionUsuario = usuarioAVer.direccion;
        // CORRECCIÓN: Retorna la vista "Perfil"
        return View("Perfil");
    }

    public IActionResult verInfoUsuario(int idUsuario)
    {
        Usuario usuarioAVer = BD.GetUsuario(idUsuario);
        ViewBag.InfoUsuario = usuarioAVer;
         return View("Perfil");
    }

    

   public IActionResult verRestriccion(int idCategoria){
        ViewBag.Restriccion = BD.GetRestriccionBusqueda(idCategoria);
        List<Plato> LP = BD.GetPlatosRestriccion(idCategoria);
        ViewBag.PlatosRestriccion = LP;
        List<Bebida> LB = BD.GetBebidasRestriccion(idCategoria);
        ViewBag.BebidasRestriccion = LB;
        return View("restriccion");
   }

    

}