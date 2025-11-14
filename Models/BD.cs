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

    public static List<Restaurante> GetRestaurantes(){
        List<Restaurante> LRestaurantes;
       using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetRestaurantes";
        LRestaurantes = connection.Query<Restaurante>(query, new {  }, commandType : CommandType.StoredProcedure).ToList();
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

    public static List<Plato> GetPlatosRestaurante(int idRestaurante){
        List<Plato> LPlatos;
       using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetPlatosRestaurante";
        LPlatos = connection.Query<Plato>(query, new { pidRestaurante = idRestaurante }, commandType : CommandType.StoredProcedure).ToList();
    }
    return LPlatos;
    }

    public static List<Plato> GetBebidasRestaurante(int idRestaurante){
        List<Bebida> LBebidas;
       using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetBebidasRestaurante";
        LBebidas = connection.Query<Plato>(query, new { pidRestaurante = idRestaurante }, commandType : CommandType.StoredProcedure).ToList();
    }
    return LBebidas;
    }

     public static List<Categoria> GetCategorias(){
        List<Categoria> LCategorias;
       using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetCategorias";
        LCategorias = connection.Query<Categoria>(query, new {}, commandType : CommandType.StoredProcedure).ToList();
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
    

    public static List<NotificacionesUsuario> GetNotificacionesUsuario(int idUsuario)
{
    List<NotificacionesUsuario> LNotificaciones;
    using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetNotificacionesUsuario";
        LNotificaciones = connection.Query<NotificacionesUsuario>(
            query, 
            new { pidUsuario = idUsuario }, 
            commandType: CommandType.StoredProcedure
        ).ToList();
    }
    return LNotificaciones;
}

public static List<FavAgregados> GetFavoritos(int idUsuario){
    
    List<FavAgregados> LFavs;
    using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetFavoritos";
        LFavs = connection.Query<FavAgregados>(
            query, 
            new { pidUsuario = idUsuario }, 
            commandType: CommandType.StoredProcedure
        ).ToList();
    }

    return LFavs;
}

}