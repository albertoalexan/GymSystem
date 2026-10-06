using Microsoft.Data.SqlClient;

namespace GymSystem.Datos
{
    public static class Conexion
    {
        private static readonly string cadenaConexion =
            "Server=localhost;Database=GymsystemDB;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}


