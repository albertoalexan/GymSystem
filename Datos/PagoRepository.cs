using GymSystem.Datos;
using GymSystem.Entidades;
using Microsoft.Data.SqlClient;

namespace GymSystem.Datos;

public class PagoRepository
{
    public List<Pago> Buscar(
        string texto = "")
    {
        List<Pago> pagos = new();

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        const string consulta = """
            SELECT
                pg.IdPago,
                pg.IdCliente,
                pg.IdInscripcion,
                c.Nombre AS NombreCliente,
                p.Nombre AS NombrePlan,
                pg.Monto,
                pg.Fecha,
                pg.MetodoPago
            FROM Pagos pg
            INNER JOIN Clientes c
                ON pg.IdCliente = c.IdCliente
            LEFT JOIN Inscripciones i
                ON pg.IdInscripcion = i.IdInscripcion
            LEFT JOIN Planes p
                ON i.IdPlan = p.IdPlan
            WHERE
                c.Nombre LIKE @Buscar
                OR p.Nombre LIKE @Buscar
            ORDER BY pg.IdPago DESC;
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
            pagos.Add(
                MapearPago(lector));
        }

        return pagos;
    }

    public void Crear(
        Pago pago)
    {
        const string consulta = """
            INSERT INTO Pagos
            (
                IdCliente,
                IdInscripcion,
                Monto,
                Fecha,
                MetodoPago
            )
            VALUES
            (
                @IdCliente,
                @IdInscripcion,
                @Monto,
                CAST(GETDATE() AS DATE),
                @MetodoPago
            );
            """;

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        using SqlCommand comando =
            new(consulta, conexion);

        comando.Parameters.AddWithValue(
            "@IdCliente",
            pago.IdCliente);

        comando.Parameters.AddWithValue(
            "@IdInscripcion",
            pago.IdInscripcion.HasValue
                ? pago.IdInscripcion.Value
                : DBNull.Value);

        comando.Parameters.AddWithValue(
            "@Monto",
            pago.Monto);

        comando.Parameters.AddWithValue(
            "@MetodoPago",
            pago.MetodoPago);

        comando.ExecuteNonQuery();
    }

    private static Pago MapearPago(
        SqlDataReader lector)
    {
        return new Pago
        {
            IdPago =
                Convert.ToInt32(
                    lector["IdPago"]),

            IdCliente =
                Convert.ToInt32(
                    lector["IdCliente"]),

            IdInscripcion =
                lector["IdInscripcion"] == DBNull.Value
                    ? null
                    : Convert.ToInt32(
                        lector["IdInscripcion"]),

            NombreCliente =
                Convert.ToString(
                    lector["NombreCliente"]) ??
                string.Empty,

            NombrePlan =
                lector["NombrePlan"] == DBNull.Value
                    ? string.Empty
                    : Convert.ToString(
                        lector["NombrePlan"]) ??
                      string.Empty,

            Monto =
                Convert.ToDecimal(
                    lector["Monto"]),

            Fecha =
                Convert.ToDateTime(
                    lector["Fecha"]),

            MetodoPago =
                Convert.ToString(
                    lector["MetodoPago"]) ??
                string.Empty
        };
    }
}

