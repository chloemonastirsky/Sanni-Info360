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

    public IActionResult LoginGuardar(string email, string contrasena)
    {
        Usuario user= BD.Login(email,contrasena);
        if(user!=null){
           int idUser=user.idUsuario;
           HttpContext.Session.SetString("IdUsuario", idUser.ToString()); 
        }
        
        return RedirectToAction("Index", "Home");
    }

     public IActionResult Registro()
    {
        
        return View("registro", "Account");
    }

     public IActionResult RegistroGuardar(int idUsuario, string nombre, string apellido, string email, string contrasena, string direccion , int telefono)
    {
        BD.Registro(nombre, apellido, email, contrasena, direccion, telefono);
        Usuario userRegistrado = BD.GetUsuario(idUsuario);
        HttpContext.Session.SetString("idUsuario", idUsuario.ToString()); 
        return RedirectToAction("iniciarSesion", "Account");
    }


    public IActionResult CerrarSesion()
    {
        HttpContext.Session.Remove("IdUsuario");
        return RedirectToAction("Index", "Home");
    }

    public IActionResult CambiarContrasena(string email)
    {
        
        return RedirectToAction();
    }

    public IActionResult editarPerfil(int idUsuario){
        
        
        return View();
    }

    public IActionResult editarPerfilGuardar(int idUsuario, string nombre, string apellido, string direccion, string email, string contrasena, int telefono){

        BD.editarPerfil(idUsuario, nombre, apellido, direccion, email, contrasena, telefono);
        return View("Perfil","Home");
    }

    
}