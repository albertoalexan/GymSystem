using GymSystem.Datos;
using GymSystem.Entidades;
using Microsoft.Data.SqlClient;

namespace GymSystem.Datos;

public class InscripcionRepository
{
    public List<Inscripcion> Buscar(
        string texto = "")
    {
        List<Inscripcion> inscripciones = new();

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        const string consulta = """
            SELECT
                i.IdInscripcion,
                i.IdCliente,
                i.IdPlan,
                c.Nombre AS NombreCliente,
                p.Nombre AS NombrePlan,
                i.FechaInicio,
                i.FechaFin,
                i.Estado
            FROM Inscripciones i
            INNER JOIN Clientes c
                ON i.IdCliente = c.IdCliente
            INNER JOIN Planes p
                ON i.IdPlan = p.IdPlan
            WHERE
                i.Estado <> 'Cancelada'
                AND
                (
                    c.Nombre LIKE @Buscar
                    OR p.Nombre LIKE @Buscar
                )
            ORDER BY i.IdInscripcion DESC;
            """;

        using SqlCommand comando =
            new(consulta, conexion);

        comando.Parameters.AddWithValue(
            "@Buscar",
            $"%{texto.Trim()}%");

        using SqlDataReader lector =
            comando.ExecuteReader();

        while (lector.Read())
        {
            inscripciones.Add(
                MapearInscripcion(lector));
        }

        return inscripciones;
    }

    public List<Inscripcion> ListarActivasPorCliente(
        int idCliente)
    {
        List<Inscripcion> inscripciones = new();

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        const string consulta = """
            SELECT
                i.IdInscripcion,
                i.IdCliente,
                i.IdPlan,
                c.Nombre AS NombreCliente,
                p.Nombre AS NombrePlan,
                i.FechaInicio,
                i.FechaFin,
                i.Estado
            FROM Inscripciones i
            INNER JOIN Clientes c
                ON i.IdCliente = c.IdCliente
            INNER JOIN Planes p
                ON i.IdPlan = p.IdPlan
            WHERE
                i.IdCliente = @IdCliente
                AND i.Estado = 'Activa'
                AND i.FechaFin >= CAST(GETDATE() AS DATE)
                AND p.Activo = 1
            ORDER BY i.FechaFin DESC;
            """;

        using SqlCommand comando =
            new(consulta, conexion);

        comando.Parameters.AddWithValue(
            "@IdCliente",
            idCliente);

        using SqlDataReader lector =
            comando.ExecuteReader();

        while (lector.Read())
        {
            inscripciones.Add(
                MapearInscripcion(lector));
        }

        return inscripciones;
    }

    public void Crear(
        Inscripcion inscripcion)
    {
        const string consulta = """
            INSERT INTO Inscripciones
            (
                IdCliente,
                IdPlan,
                FechaInicio,
                FechaFin,
                Estado
            )
            VALUES
            (
                @IdCliente,
                @IdPlan,
                @FechaInicio,
                @FechaFin,
                'Activa'
            );
            """;

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        using SqlCommand comando =
            new(consulta, conexion);

        comando.Parameters.AddWithValue(
            "@IdCliente",
            inscripcion.IdCliente);

        comando.Parameters.AddWithValue(
            "@IdPlan",
            inscripcion.IdPlan);

        comando.Parameters.AddWithValue(
            "@FechaInicio",
            inscripcion.FechaInicio);

        comando.Parameters.AddWithValue(
            "@FechaFin",
            inscripcion.FechaFin);

        comando.ExecuteNonQuery();
    }

    public bool EsActiva(
        int idInscripcion,
        int idCliente)
    {
        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        const string consulta = """
            SELECT COUNT(*)
            FROM Inscripciones
            WHERE
                IdInscripcion = @IdInscripcion
                AND IdCliente = @IdCliente
                AND Estado = 'Activa'
                AND FechaFin >= CAST(GETDATE() AS DATE);
            """;

        using SqlCommand comando =
            new(consulta, conexion);

        comando.Parameters.AddWithValue(
            "@IdInscripcion",
            idInscripcion);

        comando.Parameters.AddWithValue(
            "@IdCliente",
            idCliente);

        return Convert.ToInt32(
            comando.ExecuteScalar()) > 0;
    }

    public void Cancelar(
        int idInscripcion)
    {
        const string consulta = """
            UPDATE Inscripciones
            SET Estado = 'Cancelada'
            WHERE IdInscripcion = @IdInscripcion;
            """;

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        using SqlCommand comando =
            new(consulta, conexion);

        comando.Parameters.AddWithValue(
            "@IdInscripcion",
            idInscripcion);

        comando.ExecuteNonQuery();
    }

    private static Inscripcion MapearInscripcion(
        SqlDataReader lector)
    {
        return new Inscripcion
        {
            IdInscripcion =
                Convert.ToInt32(
                    lector["IdInscripcion"]),

            IdCliente =
                Convert.ToInt32(
                    lector["IdCliente"]),

            IdPlan =
                Convert.ToInt32(
                    lector["IdPlan"]),

            NombreCliente =
                Convert.ToString(
                    lector["NombreCliente"]) ??
                string.Empty,

            NombrePlan =
                Convert.ToString(
                    lector["NombrePlan"]) ??
                string.Empty,

            FechaInicio =
                Convert.ToDateTime(
                    lector["FechaInicio"]),

            FechaFin =
                Convert.ToDateTime(
                    lector["FechaFin"]),

            Estado =
                Convert.ToString(
                    lector["Estado"]) ??
                string.Empty
        };
    }
}

