using GymSystem.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GymSystem.Datos;

public partial class ClienteRepository
{
    public async Task<List<Cliente>> ListarAsync(
        bool soloActivos = true,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        IQueryable<Cliente> consulta =
            db.Clientes.AsNoTracking();

        if (soloActivos)
        {
            consulta = consulta.Where(c => c.Activo);
        }

        return await consulta
            .OrderByDescending(c => c.Activo)
            .ThenBy(c => c.Nombre)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Cliente>> BuscarAsync(
        string texto,
        bool incluirInactivos = false,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        IQueryable<Cliente> consulta =
            db.Clientes.AsNoTracking();

        if (!incluirInactivos)
        {
            consulta = consulta.Where(c => c.Activo);
        }

        if (!string.IsNullOrWhiteSpace(texto))
        {
            string termino = texto.Trim();

            consulta = consulta.Where(c =>
                c.Nombre.Contains(termino) ||
                c.NumeroCedula.Contains(termino) ||
                c.Correo.Contains(termino) ||
                (c.Telefono != null &&
                 c.Telefono.Contains(termino)));
        }

        return await consulta
            .OrderByDescending(c => c.Activo)
            .ThenBy(c => c.Nombre)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> ExisteDuplicadoAsync(
        string cedula,
        string correo,
        int idExcluir,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        return await db.Clientes
            .AsNoTracking()
            .AnyAsync(c =>
                (c.NumeroCedula == cedula ||
                 c.Correo == correo) &&
                c.IdCliente != idExcluir,
                cancellationToken);
    }

    public async Task CrearAsync(
        Cliente cliente,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        cliente.Activo = true;

        db.Clientes.Add(cliente);

        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task ActualizarAsync(
        Cliente cliente,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        var existente = await db.Clientes
            .FirstOrDefaultAsync(
                c => c.IdCliente == cliente.IdCliente,
                cancellationToken);

        if (existente is null)
        {
            throw new InvalidOperationException(
                "El cliente ya no existe en la base de datos.");
        }

        existente.Nombre = cliente.Nombre;
        existente.NumeroCedula = cliente.NumeroCedula;
        existente.Correo = cliente.Correo;
        existente.Telefono = cliente.Telefono;
        existente.Direccion = cliente.Direccion;
        existente.FechaNacimiento = cliente.FechaNacimiento;

        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task DesactivarAsync(
        int idCliente,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        var cliente = await db.Clientes
            .FirstOrDefaultAsync(
                c => c.IdCliente == idCliente,
                cancellationToken);

        if (cliente is null)
        {
            throw new InvalidOperationException(
                "El cliente seleccionado ya no existe.");
        }

        cliente.Activo = false;

        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task RestaurarAsync(
        int idCliente,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        var cliente = await db.Clientes
            .FirstOrDefaultAsync(
                c => c.IdCliente == idCliente,
                cancellationToken);

        if (cliente is null)
        {
            throw new InvalidOperationException(
                "El cliente seleccionado ya no existe.");
        }

        cliente.Activo = true;

        await db.SaveChangesAsync(cancellationToken);
    }
}
