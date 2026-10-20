using GymSystem.Entidades;

namespace GymSystem.Negocio;

public partial class UsuarioService
{
    public async Task<List<Usuario>> BuscarAsync(
        string texto = "",
        bool incluirInactivos = false,
        CancellationToken cancellationToken = default)
    {
        return await _repository.BuscarAsync(
            texto,
            incluirInactivos,
            cancellationToken);
    }

    public async Task<Usuario?> AutenticarAsync(
        string usuario,
        string clave,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(usuario) ||
            string.IsNullOrWhiteSpace(clave))
        {
            return null;
        }

        usuario = usuario.Trim();

        Usuario? usuarioEncontrado =
            await _repository.BuscarPorUsuarioAsync(
                usuario,
                cancellationToken);

        if (usuarioEncontrado is null)
        {
            return null;
        }

        bool claveCorrecta =
            Seguridad.VerificarClave(
                clave,
                usuarioEncontrado.ClaveHash);

        return claveCorrecta
            ? usuarioEncontrado
            : null;
    }

    public async Task DesactivarAsync(
        int idUsuario,
        CancellationToken cancellationToken = default)
    {
        ValidarId(idUsuario);

        await _repository.CambiarEstadoAsync(
            idUsuario,
            false,
            cancellationToken);
    }

    public async Task RestaurarAsync(
        int idUsuario,
        CancellationToken cancellationToken = default)
    {
        ValidarId(idUsuario);

        await _repository.CambiarEstadoAsync(
            idUsuario,
            true,
            cancellationToken);
    }

    public async Task CrearCuentaAsync(
        string nombre,
        string usuario,
        string clave,
        string rol,
        CancellationToken cancellationToken = default)
    {
        ValidarCuenta(
            nombre,
            usuario,
            clave,
            rol);

        nombre = nombre.Trim();
        usuario = usuario.Trim();
        rol = rol.Trim();

        bool existe = await _repository.ExisteUsuarioAsync(
            usuario,
            cancellationToken: cancellationToken);

        if (existe)
        {
            throw new InvalidOperationException(
                "Ese nombre de usuario ya está registrado.");
        }

        string claveHash = Seguridad.GenerarHash(clave);

        Usuario nuevoUsuario = new()
        {
            Nombre = nombre,
            UsuarioNombre = usuario,
            ClaveHash = claveHash,
            Rol = rol,
            Activo = true
        };

        await _repository.CrearAsync(
            nuevoUsuario,
            cancellationToken);
    }
}
