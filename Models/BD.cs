namespace Sanni.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
public class BD{
    private static string conexion = @"Server=localhost; DataBase=sanni bd; Integrated Security = True; TrustServerCertificate=True";
    
    public static Usuario Login(string email, string contraseña){
        Usuario UserLogged=null;
        using(SqlConnection connection = new SqlConnection(conexion)){
            string query = "LoginUsuario";
            UserLogged= connection.QueryFirstOrDefault<Usuario>(query, new { pemail = email, pcontraseña = contraseña }, commandType : CommandType.StoredProcedure);
        }
        return UserLogged;
    }

     public static Usuario GetUsuario(int idUsuario){
        Usuario usuarioMostrar=null;
        using(SqlConnection connection = new SqlConnection(conexion)){
            string query = "GetUsuario";
            usuarioMostrar= connection.QueryFirstOrDefault<Usuario>(query, new {pidUsuario=idUsuario}, commandType : CommandType.StoredProcedure);
        }
        return usuarioMostrar;
    }

     public static void Registro(string nombre, string apellido, string email, string contraseña, string direccion , int telefono)
    {
        using (SqlConnection connection = new SqlConnection(conexion))
        {
            string query = "Registro";
            connection.Execute(query, new { pnombre=nombre, papellido=apellido, pemail=email, pcontrasena=contraseña, pdireccion=direccion, ptelefono=telefono}, commandType : CommandType.StoredProcedure);
        }
    }

    public static List<Restaurante> GetRestaurantes(int idRestaurante){
        List<Restaurante> LRestaurantes;
       using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetRestaurantes";
        LRestaurantes = connection.Query<Restaurante>(query, new { pidRestaurante = idRestaurante }, commandType : CommandType.StoredProcedure).ToList();
    }
    return LRestaurantes;
    }

    public static List<Plato> GetPlatos(int idPlato){
        List<Plato> LPlatos;
       using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetPlatos";
        LPlatos = connection.Query<Plato>(query, new { pidPlato = idPlato }, commandType : CommandType.StoredProcedure).ToList();
    }
    return LPlatos;
    }

     public static List<Categoria> GetCategorias(int idCategoria){
        List<Categoria> LCategorias;
       using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetCategorias";
        LCategorias = connection.Query<Categoria>(query, new { pidCategoria = idCategoria }, commandType : CommandType.StoredProcedure).ToList();
    }
    return LCategorias;

    }
        public static Plato GetPlatoBusqueda(int idPlato){
        Plato platoBuscado=null;

        using(SqlConnection connection = new SqlConnection(conexion)){
            string query = "GetPlatoBusqueda";
            platoBuscado= connection.QueryFirstOrDefault<Plato>(query, new {pidPlato=idPlato},commandType : CommandType.StoredProcedure);
        }
        return platoBuscado;
    }

    public static Restaurante GetRestauranteBusqueda(int idRestaurante){
        Restaurante restauranteBuscado=null;

        using(SqlConnection connection = new SqlConnection(conexion)){
            string query = "GetRestauranteBusqueda";
            restauranteBuscado= connection.QueryFirstOrDefault<Restaurante>(query, new {pidRestaurante=idRestaurante}, commandType : CommandType.StoredProcedure);
        }
        return restauranteBuscado;
    }

}