///<summary>
///Esta clase se coloca en esta carpeta ya que es repetitiva, y sirve para realizar la conexión a la base de datos.
///</summary>

using Microsoft.Data.Sqlite;
using System.IO;

namespace TickNager.Helper
{
    public class DatabaseHelper
    {
        private static string conexionBaseDatos = @"Data Source=BBDD/TickNager.db";

        public static SqliteConnection getConexionBaseDatos()
        {
            return new SqliteConnection(conexionBaseDatos);
        }

        public static void iniciarConexion()
        {
            using var conexion = getConexionBaseDatos();
            conexion.Open();

            string script = File.ReadAllText("SQL/script.sql");

            using var comando = conexion.CreateCommand();
            comando.CommandText = script;
            comando.ExecuteNonQuery();
        }
    }
}