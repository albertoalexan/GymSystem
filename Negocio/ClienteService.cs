using System.Net.Mail;
using GymSystem.Datos;
using GymSystem.Entidades;

namespace GymSystem.Negocio;

public partial class ClienteService
{
    private readonly ClienteRepository _repository;

    public ClienteService()
    {
        _repository = new ClienteRepository();
    }

    private static void Validar(
        Cliente cliente)
    {
        cliente.Nombre =
            cliente.Nombre.Trim();

        cliente.NumeroCedula =
            cliente.NumeroCedula.Trim();

        cliente.Correo =
            cliente.Correo.Trim();

        cliente.Telefono =
            string.IsNullOrWhiteSpace(
                cliente.Telefono)
                ? null
                : cliente.Telefono.Trim();

        cliente.Direccion =
            string.IsNullOrWhiteSpace(
                cliente.Direccion)
                ? null
                : cliente.Direccion.Trim();

        if (string.IsNullOrWhiteSpace(
            cliente.Nombre))
        {
            throw new ArgumentException(
                "Ingrese el nombre completo.");
        }

        if (cliente.Nombre.Length < 3)
        {
            throw new ArgumentException(
                "El nombre debe tener al menos 3 caracteres.");
        }

        if (cliente.Nombre.Length > 100)
        {
            throw new ArgumentException(
                "El nombre no puede superar los 100 caracteres.");
        }

        foreach (char caracter in cliente.Nombre)
        {
            if (!char.IsLetter(caracter) &&
                caracter != ' ')
            {
                throw new ArgumentException(
                    "El nombre solo puede contener letras y espacios.");
            }
        }

        if (string.IsNullOrWhiteSpace(
            cliente.NumeroCedula))
        {
            throw new ArgumentException(
                "Ingrese el número de cédula.");
        }

        if (cliente.NumeroCedula.Length > 20)
        {
            throw new ArgumentException(
                "La cédula no puede superar los 20 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(
            cliente.Correo))
        {
            throw new ArgumentException(
                "Ingrese el correo electrónico.");
        }

        if (cliente.Correo.Length > 100)
        {
            throw new ArgumentException(
                "El correo no puede superar los 100 caracteres.");
        }

        if (!EsCorreoValido(
            cliente.Correo))
        {
            throw new ArgumentException(
                "Ingrese un correo electrónico válido.");
        }

        if (cliente.Telefono != null)
        {
            if (cliente.Telefono.Length > 20)
            {
                throw new ArgumentException(
                    "El teléfono no puede superar los 20 caracteres.");
            }

            foreach (char caracter in cliente.Telefono)
            {
                if (!char.IsDigit(caracter))
                {
                    throw new ArgumentException(
                        "El teléfono solo puede contener números.");
                }
            }
        }

        if (cliente.Direccion != null &&
            cliente.Direccion.Length > 200)
        {
            throw new ArgumentException(
                "La dirección no puede superar los 200 caracteres.");
        }

        if (cliente.FechaNacimiento.HasValue &&
            cliente.FechaNacimiento.Value.Date >
            DateTime.Today)
        {
            throw new ArgumentException(
                "La fecha de nacimiento no puede ser futura.");
        }
    }

    private static bool EsCorreoValido(
        string correo)
    {
        int posicionArroba =
            correo.IndexOf('@');

        if (posicionArroba <= 0)
            return false;

        if (posicionArroba >=
            correo.Length - 1)
        {
            return false;
        }

        if (correo.IndexOf(
                '@',
                posicionArroba + 1) != -1)
        {
            return false;
        }

        if (!correo.Contains('.'))
            return false;

        if (correo.Contains(' '))
            return false;

        try
        {
            _ = new MailAddress(correo);
        }
        catch
        {
            return false;
        }

        return true;
    }
}
