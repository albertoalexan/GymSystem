using GymSystem.Datos;
using GymSystem.Entidades;
using Microsoft.Data.SqlClient;

namespace GymSystem.Datos;

public class ClienteRepository
{
    public List<Cliente> Listar(bool soloActivos = true)
    {
        List<Cliente> clientes = new();

        using SqlConnection conexion = Conexion.ObtenerConexion();
        conexion.Open();

        string consulta = soloActivos
            ? """
              SELECT
                  IdCliente,
                  Nombre,
                  NumeroCedula,
                  Correo,
                  Telefono,
                  Direccion,
                  FechaNacimiento,
                  Activo
              FROM Clientes
              WHERE Activo = 1
              ORDER BY Nombre;
              """
            : """
              SELECT
                  IdCliente,
                  Nombre,
                  NumeroCedula,
                  Correo,
                  Telefono,
                  Direccion,
                  FechaNacimiento,
                  Activo
              FROM Clientes
              ORDER BY Activo DESC, Nombre;
              """;

        using SqlCommand comando = new(consulta, conexion);
        using SqlDataReader lector = comando.ExecuteReader();

        while (lector.Read())
        {
            clientes.Add(MapearCliente(lector));
        }

        return clientes;
    }

    public List<Cliente> Buscar(
        string texto,
        bool incluirInactivos = false)
    {
        List<Cliente> clientes = new();

        using SqlConnection conexion = Conexion.ObtenerConexion();
        conexion.Open();

        string consulta = """
            SELECT
                IdCliente,
                Nombre,
                NumeroCedula,
                Correo,
                Telefono,
                Direccion,
                FechaNacimiento,
                Activo
            FROM Clientes
            WHERE
                (
                    Nombre LIKE @Buscar
                    OR NumeroCedula LIKE @Buscar
                    OR Correo LIKE @Buscar
                    OR Telefono LIKE @Buscar
                )
            """;

        if (!incluirInactivos)
        {
            consulta += " AND Activo = 1";
        }

        consulta += " ORDER BY Activo DESC, Nombre;";

        using SqlCommand comando = new(consulta, conexion);

        comando.Parameters.AddWithValue(
            "@Buscar",
            $"%{texto.Trim()}%");

        using SqlDataReader lector = comando.ExecuteReader();

        while (lector.Read())
        {
            clientes.Add(MapearCliente(lector));
        }

        return clientes;
    }

    public bool ExisteDuplicado(
        string cedula,
        string correo,
        int idExcluir)
    {
        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        const string consulta = """
            SELECT COUNT(*)
            FROM Clientes
            WHERE
                (NumeroCedula = @Cedula OR Correo = @Correo)
                AND IdCliente <> @IdCliente;
            """;

        using SqlCommand comando =
            new(consulta, conexion);

        comando.Parameters.AddWithValue(
            "@Cedula",
            cedula);

        comando.Parameters.AddWithValue(
            "@Correo",
            correo);

        comando.Parameters.AddWithValue(
            "@IdCliente",
            idExcluir);

        return Convert.ToInt32(
            comando.ExecuteScalar()) > 0;
    }

    public void Crear(Cliente cliente)
    {
        const string consulta = """
            INSERT INTO Clientes
            (
                Nombre,
                NumeroCedula,
                Correo,
                Telefono,
                Direccion,
                FechaNacimiento,
                Activo
            )
            VALUES
            (
                @Nombre,
                @NumeroCedula,
                @Correo,
                @Telefono,
                @Direccion,
                @FechaNacimiento,
                1
            );
            """;

        EjecutarComando(
            consulta,
            cliente);
    }

    public void Actualizar(Cliente cliente)
    {
        const string consulta = """
            UPDATE Clientes
            SET
                Nombre = @Nombre,
                NumeroCedula = @NumeroCedula,
                Correo = @Correo,
                Telefono = @Telefono,
                Direccion = @Direccion,
                FechaNacimiento = @FechaNacimiento
            WHERE IdCliente = @IdCliente;
            """;

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        using SqlCommand comando =
            new(consulta, conexion);

        AgregarParametros(
            comando,
            cliente);

        comando.Parameters.AddWithValue(
            "@IdCliente",
            cliente.IdCliente);

        comando.ExecuteNonQuery();
    }

    public void Desactivar(int idCliente)
    {
        const string consulta = """
            UPDATE Clientes
            SET Activo = 0
            WHERE IdCliente = @IdCliente;
            """;

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        using SqlCommand comando =
            new(consulta, conexion);

        comando.Parameters.AddWithValue(
            "@IdCliente",
            idCliente);

        comando.ExecuteNonQuery();
    }

    public void Restaurar(int idCliente)
    {
        const string consulta = """
            UPDATE Clientes
            SET Activo = 1
            WHERE IdCliente = @IdCliente;
            """;

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        using SqlCommand comando =
            new(consulta, conexion);

        comando.Parameters.AddWithValue(
            "@IdCliente",
            idCliente);

        comando.ExecuteNonQuery();
    }

    private static void EjecutarComando(
        string consulta,
        Cliente cliente)
    {
        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        using SqlCommand comando =
            new(consulta, conexion);

        AgregarParametros(
            comando,
            cliente);

        comando.ExecuteNonQuery();
    }

    private static void AgregarParametros(
        SqlCommand comando,
        Cliente cliente)
    {
        comando.Parameters.AddWithValue(
            "@Nombre",
            cliente.Nombre);

        comando.Parameters.AddWithValue(
            "@NumeroCedula",
            cliente.NumeroCedula);

        comando.Parameters.AddWithValue(
            "@Correo",
            cliente.Correo);

        comando.Parameters.AddWithValue(
            "@Telefono",
            (object?)cliente.Telefono ??
            DBNull.Value);

        comando.Parameters.AddWithValue(
            "@Direccion",
            (object?)cliente.Direccion ??
            DBNull.Value);

        comando.Parameters.AddWithValue(
            "@FechaNacimiento",
            (object?)cliente.FechaNacimiento ??
            DBNull.Value);
    }

    private static Cliente MapearCliente(
        SqlDataReader lector)
    {
        return new Cliente
        {
            IdCliente =
                Convert.ToInt32(
                    lector["IdCliente"]),

            Nombre =
                Convert.ToString(
                    lector["Nombre"]) ??
                string.Empty,

            NumeroCedula =
                Convert.ToString(
                    lector["NumeroCedula"]) ??
                string.Empty,

            Correo =
                Convert.ToString(
                    lector["Correo"]) ??
                string.Empty,

            Telefono =
                lector["Telefono"] == DBNull.Value
                    ? null
                    : Convert.ToString(
                        lector["Telefono"]),

            Direccion =
                lector["Direccion"] == DBNull.Value
                    ? null
                    : Convert.ToString(
                        lector["Direccion"]),

            FechaNacimiento =
                lector["FechaNacimiento"] == DBNull.Value
                    ? null
                    : Convert.ToDateTime(
                        lector["FechaNacimiento"]),

            Activo =
                Convert.ToBoolean(
                    lector["Activo"])
        };
    }
}

