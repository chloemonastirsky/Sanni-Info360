namespace TP06;
using Microsoft.Data.SqlClient;
using Dapper;

public static class BD{
    private static string conexion = @"Server=localhost; DataBase=sanni bd; Integrated Security = True; TrustServerCertificate=True";

    public static int Login(string email, string contrasena){
        int idUserLogged=null;
        using(SqlConnection connection = new SqlConnection(conexion)){
            string query = "select Usuario.idUsuario from Usuario where email=@pemail and contrasena = @pcontrasena";
            idUserLogged= connection.QueryFirstOrDefault<int>(query, new {pemail = email, pcontraseña = contrasena});
        }

        return idUserLogged;
    }

     public static Usuario GetUsuario(int id){
        Usuario usuarioMostrar=null;

        using(SqlConnection connection = new SqlConnection(conexion)){
            string query = "select * from Usuario where idUsuario=@pId";
            usuarioMostrar= connection.QueryFirstOrDefault<Usuario>(query, new {pid=id});
        }

        return usuarioMostrar;
    }

     public static void Registro(string nombre, string apellido, string email, string contrasena, string direccion , int telefono)
    {
        using (SqlConnection connection = new SqlConnection(conexion))
        {
            string query = "insert into Usuario (nombre, apellido, email, contrasena, direccion, telefono) Values (@pnombre, @papellido, @pemail, @pcontrasena, @pdireccion, @ptelefono)";
            connection.Execute(query, new { pnombre=nombre, papellido=apellido, pemail=email, pcontrasena=contrasena, pdireccion=direccion, ptelefono=telefono});
        }
    }

    public static List<Restaurante> GetRestaurantes(int idRestaurante){
        List<Restaurante> LRestaurantes;
       using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "SELECT * FROM Restaurante WHERE idRestaurante = @pidRestaurante";
        LRestaurantes = connection.Query<Restaurante>(query, new { pidRestaurante = idRestaurante }).ToList();
    }
    return LRestaurantes;
    }

    public static Plato GetPlatoBusqueda(int idPlato){
        Plato platoBuscado=null;

        using(SqlConnection connection = new SqlConnection(conexion)){
            string query = "select * from Plato where idPlato=@pidPlato";
            platoBuscado= connection.QueryFirstOrDefault<Plato>(query, new {pidPlato=idPlato});
        }

        return platoBuscado;
    }

    public static Restaurante GetRestauranteBusqueda(int idRestaurante){
        Restaurante restauranteBuscado=null;

        using(SqlConnection connection = new SqlConnection(conexion)){
            string query = "select * from Restaurante where idRestaurante=@pidRestaurante";
            restauranteBuscado= connection.QueryFirstOrDefault<Restaurante>(query, new {pidRestaurante=idRestaurante});
        }

        return restauranteBuscado;
    }

    public static List<Plato> GetPlatos(){
        List<Plato> LPlatos;
       using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "SELECT * FROM Plato WHERE idPlato = @pidPlato";
        LPlatos = connection.Query<Plato>(query, new { pidPlato = idPlato }).ToList();
    }
    return LPlatos;
    }

     public static List<Categoria> GetRestricciones(){
        List<Categoria> LCategorias;
       using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "SELECT * FROM Categoria WHERE idCategoria = @pidCategoria";
        LCategorias = connection.Query<Categoria>(query, new { pidCategoria = idCategoria }).ToList();
    }
    return LCategorias;

    }
}