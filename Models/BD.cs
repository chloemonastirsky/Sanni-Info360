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
            connection.Execute(query, new { pnombre=nombre, papellido=apellido, pemail=email, pcontrasena=contraseña, pdireccion=direccion, ptelefono=telefono}, CommandType : CommandType.StoreProcedure);
        }
    }

}