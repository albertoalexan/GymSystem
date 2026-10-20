using GymSystem.Datos;
using GymSystem.Entidades;

namespace GymSystem.Negocio;

public partial class UsuarioService
{
    private readonly UsuarioRepository _repository;

    public UsuarioService()
    {
        _repository = new UsuarioRepository();
    }

    private static void ValidarCuenta(
        string nombre,
        string usuario,
        string clave,
        string rol)
    {
        nombre =
            nombre.Trim();

        usuario =
            usuario.Trim();

        rol =
            rol.Trim();

        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException(
                "Ingrese el nombre completo.");
        }

        if (nombre.Length < 3)
        {
            throw new ArgumentException(
                "El nombre debe tener al menos 3 caracteres.");
        }

        if (nombre.Length > 100)
        {
            throw new ArgumentException(
                "El nombre no puede superar los 100 caracteres.");
        }

        foreach (char caracter in nombre)
        {
            if (!char.IsLetter(caracter) &&
                caracter != ' ')
            {
                throw new ArgumentException(
                    "El nombre solo puede contener letras y espacios.");
            }
        }

        if (string.IsNullOrWhiteSpace(usuario))
        {
            throw new ArgumentException(
                "Ingrese un nombre de usuario.");
        }

        if (usuario.Length < 3)
        {
            throw new ArgumentException(
                "El usuario debe tener al menos 3 caracteres.");
        }

        if (usuario.Length > 50)
        {
            throw new ArgumentException(
                "El usuario no puede superar los 50 caracteres.");
        }

        if (usuario.Contains(' '))
        {
            throw new ArgumentException(
                "El usuario no puede contener espacios.");
        }

        if (string.IsNullOrWhiteSpace(clave))
        {
            throw new ArgumentException(
                "Ingrese una contraseña.");
        }

        if (clave.Length < 6)
        {
            throw new ArgumentException(
                "La contraseña debe tener al menos 6 caracteres.");
        }

        if (clave.Length > 50)
        {
            throw new ArgumentException(
                "La contraseña no puede superar los 50 caracteres.");
        }

        if (rol != "Administrador" &&
            rol != "Empleado")
        {
            throw new ArgumentException(
                "Seleccione un rol válido.");
        }
    }

    private static void ValidarId(
        int idUsuario)
    {
        if (idUsuario <= 0)
        {
            throw new ArgumentException(
                "El usuario seleccionado no es válido.");
        }
    }
}
