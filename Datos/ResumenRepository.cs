using GymSystem.Datos;
using GymSystem.Entidades;
using Microsoft.Data.SqlClient;

namespace GymSystem.Datos;

public class ResumenRepository
{
    public ResumenSistema ObtenerResumen()
    {
        const string consulta = """
            SELECT
                (SELECT COUNT(*)
                 FROM Clientes
                 WHERE Activo = 1) AS CantidadClientes,

                (SELECT COUNT(*)
                 FROM Planes
                 WHERE Activo = 1) AS CantidadPlanes,

                (SELECT COUNT(*)
                 FROM Inscripciones
                 WHERE Estado = 'Activa') AS CantidadInscripciones,

                (SELECT COUNT(*)
                 FROM Pagos) AS CantidadPagos;
            """;

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        using SqlCommand comando =
            new(consulta, conexion);

        using SqlDataReader lector =
            comando.ExecuteReader();

        if (!lector.Read())
        {
            return new ResumenSistema();
        }

        return new ResumenSistema
        {
            CantidadClientes =
                Convert.ToInt32(
                    lector["CantidadClientes"]),

            CantidadPlanes =
                Convert.ToInt32(
                    lector["CantidadPlanes"]),

            CantidadInscripciones =
                Convert.ToInt32(
                    lector["CantidadInscripciones"]),

            CantidadPagos =
                Convert.ToInt32(
                    lector["CantidadPagos"])
        };
    }
}

