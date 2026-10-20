using GymSystem.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GymSystem.Datos;

public partial class UsuarioRepository
{
    public async Task<List<Usuario>> BuscarAsync(
        string texto = "",
        bool incluirInactivos = false,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        IQueryable<Usuario> consulta =
            db.Usuarios.AsNoTracking();

        if (!incluirInactivos)
        {
            consulta = consulta.Where(u => u.Activo);
        }

        if (!string.IsNullOrWhiteSpace(texto))
        {
            string termino = texto.Trim();

            consulta = consulta.Where(u =>
                u.Nombre.Contains(termino) ||
                u.UsuarioNombre.Contains(termino));
        }

        return await consulta
            .OrderByDescending(u => u.Activo)
            .ThenBy(u => u.Nombre)
            .ToListAsync(cancellationToken);
    }

    public async Task<Usuario?> BuscarPorUsuarioAsync(
        string usuario,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        return await db.Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(
                u => u.UsuarioNombre == usuario && u.Activo,
                cancellationToken);
    }

    public async Task<bool> ExisteUsuarioAsync(
        string usuario,
        int idExcluir = 0,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        return await db.Usuarios
            .AsNoTracking()
            .AnyAsync(
                u => u.UsuarioNombre == usuario &&
                     u.IdUsuario != idExcluir,
                cancellationToken);
    }

    public async Task CambiarEstadoAsync(
        int idUsuario,
        bool activo,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        var usuario = await db.Usuarios
            .FirstOrDefaultAsync(
                u => u.IdUsuario == idUsuario,
                cancellationToken);

        if (usuario is null)
        {
            throw new InvalidOperationException(
                "El usuario seleccionado ya no existe.");
        }

        usuario.Activo = activo;

        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task CrearAsync(
        Usuario usuario,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        usuario.Activo = true;

        db.Usuarios.Add(usuario);

        await db.SaveChangesAsync(cancellationToken);
    }
}
