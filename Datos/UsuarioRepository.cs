using GymSystem.Datos;
using GymSystem.Entidades;
using Microsoft.Data.SqlClient;

namespace GymSystem.Datos;

public class UsuarioRepository
{
    public List<Usuario> Buscar(
        string texto = "",
        bool incluirInactivos = false)
    {
        List<Usuario> usuarios = new();

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        string consulta = """
            SELECT
                IdUsuario,
                Nombre,
                Usuario,
                ClaveHash,
                Rol,
                Activo
            FROM Usuarios
            WHERE
                (
                    Nombre LIKE @Buscar
                    OR Usuario LIKE @Buscar
                )
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
            usuarios.Add(
                MapearUsuario(lector));
        }

        return usuarios;
    }

    public Usuario? BuscarPorUsuario(
        string usuario)
    {
        const string consulta = """
            SELECT
                IdUsuario,
                Nombre,
                Usuario,
                ClaveHash,
                Rol,
                Activo
            FROM Usuarios
            WHERE Usuario = @Usuario
              AND Activo = 1;
            """;

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        using SqlCommand comando =
            new(consulta, conexion);

        comando.Parameters.AddWithValue(
            "@Usuario",
            usuario);

        using SqlDataReader lector =
            comando.ExecuteReader();

        if (!lector.Read())
        {
            return null;
        }

        return MapearUsuario(lector);
    }

    public void CambiarEstado(
        int idUsuario,
        bool activo)
    {
        const string consulta = """
            UPDATE Usuarios
            SET Activo = @Activo
            WHERE IdUsuario = @IdUsuario;
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
            "@IdUsuario",
            idUsuario);

        comando.ExecuteNonQuery();
    }

    public bool ExisteUsuario(
        string usuario,
        int idExcluir = 0)
    {
        const string consulta = """
            SELECT COUNT(*)
            FROM Usuarios
            WHERE Usuario = @Usuario
              AND IdUsuario <> @IdUsuario;
            """;

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        using SqlCommand comando =
            new(consulta, conexion);

        comando.Parameters.AddWithValue(
            "@Usuario",
            usuario);

        comando.Parameters.AddWithValue(
            "@IdUsuario",
            idExcluir);

        return Convert.ToInt32(
            comando.ExecuteScalar()) > 0;
    }

    public void Crear(
        Usuario usuario)
    {
        const string consulta = """
            INSERT INTO Usuarios
            (
                Nombre,
                Usuario,
                ClaveHash,
                Rol,
                Activo
            )
            VALUES
            (
                @Nombre,
                @Usuario,
                @ClaveHash,
                @Rol,
                1
            );
            """;

        using SqlConnection conexion =
            Conexion.ObtenerConexion();

        conexion.Open();

        using SqlCommand comando =
            new(consulta, conexion);

        comando.Parameters.AddWithValue(
            "@Nombre",
            usuario.Nombre);

        comando.Parameters.AddWithValue(
            "@Usuario",
            usuario.UsuarioNombre);

        comando.Parameters.AddWithValue(
            "@ClaveHash",
            usuario.ClaveHash);

        comando.Parameters.AddWithValue(
            "@Rol",
            usuario.Rol);

        comando.ExecuteNonQuery();
    }

    private static Usuario MapearUsuario(
        SqlDataReader lector)
    {
        return new Usuario
        {
            IdUsuario =
                Convert.ToInt32(
                    lector["IdUsuario"]),

            Nombre =
                Convert.ToString(
                    lector["Nombre"]) ??
                string.Empty,

            UsuarioNombre =
                Convert.ToString(
                    lector["Usuario"]) ??
                string.Empty,

            ClaveHash =
                Convert.ToString(
                    lector["ClaveHash"]) ??
                string.Empty,

            Rol =
                Convert.ToString(
                    lector["Rol"]) ??
                "Empleado",

            Activo =
                Convert.ToBoolean(
                    lector["Activo"])
        };
    }
}

