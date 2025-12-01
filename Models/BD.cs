namespace Sanni.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
public class BD{
    private static string conexion = @"Server=localhost; DataBase=Sanni; Integrated Security = True; TrustServerCertificate=True";    
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

    public static List<Bebida> GetBebidasRestaurante(int idRestaurante){
        List<Bebida> LBebidas;
       using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetBebidasRestaurante";
        LBebidas = connection.Query<Bebida>(query, new { pidRestaurante = idRestaurante }, commandType : CommandType.StoredProcedure).ToList();
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

     public static Bebida GetBebidaBusqueda(int idBebida){
        Bebida bebida=null;

        using(SqlConnection connection = new SqlConnection(conexion)){
            string query = "GetBebidaBusqueda";
            bebida= connection.QueryFirstOrDefault<Bebida>(query, new {pidBebida=idBebida},commandType : CommandType.StoredProcedure);
        }
        return bebida;
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
    //ver pq no funciona
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

public static List<FavAgregados> GetFavoritosRestaurante(int idUsuario, int idRestaurante){
    
    List<FavAgregados> LFavs;
    using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetFavoritosRestaurante";
        LFavs = connection.Query<FavAgregados>(
            query, 
            new { pidUsuario = idUsuario , pidRestaurante=idRestaurante}, 
            commandType: CommandType.StoredProcedure
        ).ToList();
    }

    return LFavs;
}


public static Categoria GetRestriccionBusqueda(int idCategoria){
    
    Categoria restriccion;
    using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetRestriccionBusqueda";
        restriccion = connection.QueryFirstOrDefault<Categoria>(query, new {pidCategoria=idCategoria}, commandType : CommandType.StoredProcedure);
    }

    return restriccion;
}


public static Categoria BusquedaRestricciones(string busqueda){

    Categoria restriccion;
    using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "BusquedaRestricciones";
        restriccion = connection.QueryFirstOrDefault<Categoria>(query, new {pbusqueda=busqueda}, commandType : CommandType.StoredProcedure);
    } 
    return restriccion;
}

public static List<Restaurante> GetRestauranteRestriccion(int idCategoria){
    
    List<Restaurante> LRestaurantes;
       using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetRestaurantesRestriccion";
        LRestaurantes = connection.Query<Restaurante>(query, new { pidCategoria = idCategoria }, commandType : CommandType.StoredProcedure).ToList();
    }
    return LRestaurantes;
}
public static List<Plato> GetPlatosRestriccion(int idCategoria){
    
    List<Plato> LPlatos;
       using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetPlatosRestriccion";
        LPlatos = connection.Query<Plato>(query, new { pidCategoria = idCategoria }, commandType : CommandType.StoredProcedure).ToList();
    }
    return LPlatos;
}

public static List<Bebida> GetBebidasRestriccion(int idCategoria){
    
    List<Bebida> LBebidas;
       using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetBebidasRestriccion";
        LBebidas = connection.Query<Bebida>(query, new { pidCategoria = idCategoria }, commandType : CommandType.StoredProcedure).ToList();
    }
    return LBebidas;
}

public static List<Promocion> GetPromosRestaurante(int idRestaurante){
    
    List<Promocion> LPromos;
    using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetPromosRestaurante";
        LPromos = connection.Query<Promocion>(
            query, 
            new {pidRestaurante=idRestaurante}, 
            commandType: CommandType.StoredProcedure
        ).ToList();
    }

    return LPromos;
}
public static void editarPerfil(int idUsuario, string nombre, string apellido, string direccion, string email, string contrasena, int telefono){
    
    using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "editarPerfil";
        connection.Execute(query, new { pnombre=nombre, papellido=apellido, pemail=email, pcontrasena=contrasena, pdireccion=direccion, ptelefono=telefono}, commandType : CommandType.StoredProcedure);
    }

}
public static Restaurante RecibirApi(){
        Restaurante ubicacion= new Restaurante();
        string query = "recibirApi";
        using (SqlConnection connection = new SqlConnection(conexion)){
            ubicacion= connection.QueryFirstOrDefault<Restaurante>(query, new {}, commandType : CommandType.StoredProcedure);
        }
        return ubicacion;
    }
}


