using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sanni.Models;

namespace Sanni.Controllers;

public class AccountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        
        return View("iniciarSesion");
    }

    public IActionResult LoginGuardar(string email, string contraseña)
    {
        Usuario usuarioLog= BD.Login(email,contraseña);
        if(usuarioLog!=null){
           int idUser=usuarioLog.idUsuario;
           ViewBag.NombreUsuario=usuarioLog.nombre;
           HttpContext.Session.SetString("IdUsuario", idUser.ToString()); 
        }
        
        return RedirectToAction("");
    }

     public IActionResult Registro()
    {
        
        return View("registro");
    }

     public IActionResult RegistroGuardar(string nombre, string apellido, string email, string contraseña, string direccion , int telefono)
    {
        BD.Registro(nombre, apellido, email, contraseña, direccion, telefono);
        Usuario userRegistrado = BD.GetUsuario(idUsuario);
        HttpContext.Session.SetString("IdUsuario", idUsuario.ToString()); 
        return RedirectToAction("iniciarSesion", "Account");
    }




    public IActionResult CambiarContrasena(string email)
    {
        
        return RedirectToAction();
    }
    
}