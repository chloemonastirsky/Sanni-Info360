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
        return View("Index");
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
        int idRestaurante= bebida.idRestaurante;
        Restaurante restauranteBebida=BD.GetRestauranteBusqueda(idRestaurante);
        ViewBag.restaurante=restauranteBebida;
        return View("bebida");
    }


    public IActionResult verFavoritos(int idUsuario)
    {
        string stringIdUsuario= HttpContext.Session.GetString("IdUsuario");
        int IdUsuario=int.Parse(stringIdUsuario);   
        List<FavAgregados> LFavs = BD.GetFavoritos(IdUsuario);
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
        string stringIdUsuario= HttpContext.Session.GetString("IdUsuario");
        int IdUsuario=int.Parse(stringIdUsuario);
        List<NotificacionesUsuario> LNotis = BD.GetNotificacionesUsuario(IdUsuario);
        ViewBag.NotificacionesUsuario = LNotis;
        // CORRECCIÓN: Retorna la vista "notificaciones"
        return View("notificaciones");
    }


    public IActionResult verPerfil(int idUsuario)
    {
        string stringIdUsuario= HttpContext.Session.GetString("IdUsuario");
        int IdUsuario=int.Parse(stringIdUsuario);
        ViewBag.Usuario=BD.GetUsuario(IdUsuario);
        // CORRECCIÓN: Retorna la vista "Perfil"
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


   public IActionResult BuscarRestricciones(string busqueda)
{
    // 1. Ejecuta la búsqueda y guarda el resultado potencial
    Categoria restriccion = BD.BusquedaRestricciones(busqueda);

    // 2. VERIFICACIÓN CRÍTICA: Asegurarse de que se encontró algo
    if (restriccion != null)
    {
        // El objeto existe, ahora podemos acceder a sus propiedades sin error.
        int idCategoria = restriccion.idCategoria; 
        ViewBag.Restriccion = restriccion; 
        ViewBag.RestaurantesRelacionados=BD.GetRestauranteRestriccion(idCategoria);
        List<Plato> LP = BD.GetPlatosRestriccion(idCategoria);
        ViewBag.PlatosRestriccion = LP;
        List<Bebida> LB = BD.GetBebidasRestriccion(idCategoria);
        ViewBag.BebidasRestriccion = LB;
        // Retornar a la vista que muestra los resultados
        return View("RestriccionesEncontradas", restriccion); 
    }
    else
    {
        
        
        ViewBag.Error = $"No se encontró ninguna restricción o categoría que coincida con '{busqueda}'.";
        
        return View("restricciones"); 
    }
}



    

}