using GymSystem.Datos;
using GymSystem.Entidades;
using Microsoft.Data.SqlClient;

namespace GymSystem.Datos;

public class PlanRepository
{
    public List<Plan> Listar(bool soloActivos = true)
    {
        List<Plan> planes = new();

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        string consulta = soloActivos
            ? """
              SELECT
                  IdPlan,
                  Nombre,
                  DuracionDias,
                  Precio,
                  Descripcion,
                  Activo
              FROM Planes
              WHERE Activo = 1
              ORDER BY Nombre;
              """
            : """
              SELECT
                  IdPlan,
                  Nombre,
                  DuracionDias,
                  Precio,
                  Descripcion,
                  Activo
              FROM Planes
              ORDER BY Activo DESC, Nombre;
              """;

        using SqlCommand comando =
            new(consulta, conexion);

        using SqlDataReader lector =
            comando.ExecuteReader();

        while (lector.Read())
        {
            planes.Add(
                MapearPlan(lector));
        }

        return planes;
    }

    public List<Plan> Buscar(
        string texto,
        bool incluirInactivos = false)
    {
        List<Plan> planes = new();

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        string consulta = """
            SELECT
                IdPlan,
                Nombre,
                DuracionDias,
                Precio,
                Descripcion,
                Activo
            FROM Planes
            WHERE Nombre LIKE @Buscar
            """;

        if (!incluirInactivos)
        {
            consulta += " AND Activo = 1";
        }

        consulta +=
            " ORDER BY Activo DESC, Nombre;";

        using SqlCommand comando =
            new(consulta, conexion);

        comando.Parameters.AddWithValue(
            "@Buscar",
            $"%{texto.Trim()}%");

        using SqlDataReader lector =
            comando.ExecuteReader();

        while (lector.Read())
        {
            planes.Add(
                MapearPlan(lector));
        }

        return planes;
    }

    public void Crear(Plan plan)
    {
        const string consulta = """
            INSERT INTO Planes
            (
                Nombre,
                DuracionDias,
                Precio,
                Descripcion,
                Activo
            )
            VALUES
            (
                @Nombre,
                @DuracionDias,
                @Precio,
                @Descripcion,
                1
            );
            """;

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        using SqlCommand comando =
            new(consulta, conexion);

        AgregarParametros(
            comando,
            plan);

        comando.ExecuteNonQuery();
    }

    public void Actualizar(Plan plan)
    {
        const string consulta = """
            UPDATE Planes
            SET
                Nombre = @Nombre,
                DuracionDias = @DuracionDias,
                Precio = @Precio
            WHERE IdPlan = @IdPlan;
            """;

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        using SqlCommand comando =
            new(consulta, conexion);

        comando.Parameters.AddWithValue(
            "@Nombre",
            plan.Nombre);

        comando.Parameters.AddWithValue(
            "@DuracionDias",
            plan.DuracionDias);

        comando.Parameters.AddWithValue(
            "@Precio",
            plan.Precio);

        comando.Parameters.AddWithValue(
            "@IdPlan",
            plan.IdPlan);

        comando.ExecuteNonQuery();
    }

    public void CambiarEstado(
        int idPlan,
        bool activo)
    {
        const string consulta = """
            UPDATE Planes
            SET Activo = @Activo
            WHERE IdPlan = @IdPlan;
            """;

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        using SqlCommand comando =
            new(consulta, conexion);

        comando.Parameters.AddWithValue(
            "@Activo",
            activo);

        comando.Parameters.AddWithValue(
            "@IdPlan",
            idPlan);

        comando.ExecuteNonQuery();
    }

    private static void AgregarParametros(
        SqlCommand comando,
        Plan plan)
    {
        comando.Parameters.AddWithValue(
            "@Nombre",
            plan.Nombre);

        comando.Parameters.AddWithValue(
            "@DuracionDias",
            plan.DuracionDias);

        comando.Parameters.AddWithValue(
            "@Precio",
            plan.Precio);

        comando.Parameters.AddWithValue(
            "@Descripcion",
            (object?)plan.Descripcion ??
            DBNull.Value);
    }

    private static Plan MapearPlan(
        SqlDataReader lector)
    {
        return new Plan
        {
            IdPlan =
                Convert.ToInt32(
                    lector["IdPlan"]),

            Nombre =
                Convert.ToString(
                    lector["Nombre"]) ??
                string.Empty,

            DuracionDias =
                Convert.ToInt32(
                    lector["DuracionDias"]),

            Precio =
                Convert.ToDecimal(
                    lector["Precio"]),

            Descripcion =
                lector["Descripcion"] == DBNull.Value
                    ? null
                    : Convert.ToString(
                        lector["Descripcion"]),

            Activo =
                Convert.ToBoolean(
                    lector["Activo"])
        };
    }
}

