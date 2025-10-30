namespace TP06;
using Microsoft.Data.SqlClient;
using Dapper;

public static class BD{
    private static string conexion = @"Server=localhost; DataBase=sanni bd; Integrated Security = True; TrustServerCertificate=True";

    public static int Login(string email, string contraseña){
        int idUserLogged=-1;
        using(SqlConnection connection = new SqlConnection(conexion)){
            string query = "LoginUsuario";
            idUserLogged= connection.QueryFirstOrDefault<int>(query, new {pemail = email, pcontraseña = contraseña}, CommandType : CommandType.StoreProcedure);
        }

        return idUserLogged;
    }

     public static Usuario GetUsuario(int id){
        Usuario usuarioMostrar=null;

        using(SqlConnection connection = new SqlConnection(conexion)){
            string query = "GetUsuario";
            usuarioMostrar= connection.QueryFirstOrDefault<Usuario>(query, new {pid=id}, CommandType : CommandType.StoreProcedure);
        }

        return usuarioMostrar;
    }

     public static void Registro(string nombre, string apellido, string email, string contraseña, string direccion , int telefono)
    {
        using (SqlConnection connection = new SqlConnection(conexion))
        {
            string query = "Registro";
            connection.Execute(query, new { pnombre=nombre, papellido=apellido, pemail=email, pcontrasena=contraseña, pdireccion=direccion, ptelefono=telefono}, CommandType : CommandType.StoreProcedure);
        }
    }

    public static List<Restaurante> GetRestaurantes(int idRestaurante){
        List<Restaurante> LRestaurantes;
       using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetRestaurantes";
        LRestaurantes = connection.Query<Restaurante>(query, new { pidRestaurante = idRestaurante }, CommandType : CommandType.StoreProcedure).ToList();
    }
    return LRestaurantes;
    }


    public static List<Plato> GetPlatos(){
        List<Plato> LPlatos;
       using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetPlatos";
        LPlatos = connection.Query<Plato>(query, new { pidPlato = idPlato }, CommandType : CommandType.StoreProcedure).ToList();
    }
    return LPlatos;
    }

     public static List<Categoria> GetCategorias(){
        List<Categoria> LCategorias;
       using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetCategorias";
        LCategorias = connection.Query<Categoria>(query, new { pidCategoria = idCategoria }, CommandType : CommandType.StoreProcedure).ToList();
    }
    return LCategorias;

    }

        public static Plato GetPlatoBusqueda(int idPlato){
        Plato platoBuscado=null;

        using(SqlConnection connection = new SqlConnection(conexion)){
            string query = "GetPlatoBusqueda";
            platoBuscado= connection.QueryFirstOrDefault<Plato>(query, new {pidPlato=idPlato}, CommandType : CommandType.StoreProcedure);
        }

        return platoBuscado;
    }

    public static Restaurante GetRestauranteBusqueda(int idRestaurante){
        Restaurante restauranteBuscado=null;

        using(SqlConnection connection = new SqlConnection(conexion)){
            string query = "GetRestauranteBusqueda";
            restauranteBuscado= connection.QueryFirstOrDefault<Restaurante>(query, new {pidRestaurante=idRestaurante}, CommandType : CommandType.StoreProcedure);
        }

        return restauranteBuscado;
    }

    public static Restaurante GetRestauranteBusqueda(int idRestaurante){
        Restaurante restauranteBuscado=null;

        using(SqlConnection connection = new SqlConnection(conexion)){
            string query = "GetRestauranteBusqueda";
            restauranteBuscado= connection.QueryFirstOrDefault<Restaurante>(query, new {pidRestaurante=idRestaurante}, CommandType : CommandType.StoreProcedure);
        }

        return restauranteBuscado;
    }

    public static List<Categoria> GetCategorias(){
        List<Categoria> LCategorias;
       using (SqlConnection connection = new SqlConnection(conexion))
    {
        string query = "GetCategorias";
        LCategorias = connection.Query<Categoria>(query, new { pidCategoria = idCategoria }, CommandType : CommandType.StoreProcedure).ToList();
    }
    return LCategorias;

    }

    
}