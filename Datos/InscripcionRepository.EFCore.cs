using GymSystem.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GymSystem.Datos;

public partial class InscripcionRepository
{
    public async Task<List<Inscripcion>> BuscarAsync(
        string texto = "",
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        var consulta =
            from i in db.Inscripciones.AsNoTracking()
            join c in db.Clientes.AsNoTracking()
                on i.IdCliente equals c.IdCliente
            join p in db.Planes.AsNoTracking()
                on i.IdPlan equals p.IdPlan
            where i.Estado != "Cancelada"
            select new
            {
                i.IdInscripcion,
                i.IdCliente,
                i.IdPlan,
                NombreCliente = c.Nombre,
                NombrePlan = p.Nombre,
                i.FechaInicio,
                i.FechaFin,
                i.Estado
            };

        if (!string.IsNullOrWhiteSpace(texto))
        {
            string termino = texto.Trim();

            consulta = consulta.Where(x =>
                x.NombreCliente.Contains(termino) ||
                x.NombrePlan.Contains(termino));
        }

        var filas = await consulta
            .OrderByDescending(x => x.IdInscripcion)
            .ToListAsync(cancellationToken);

        return filas.Select(x => new Inscripcion
        {
            IdInscripcion = x.IdInscripcion,
            IdCliente = x.IdCliente,
            IdPlan = x.IdPlan,
            NombreCliente = x.NombreCliente,
            NombrePlan = x.NombrePlan,
            FechaInicio = x.FechaInicio,
            FechaFin = x.FechaFin,
            Estado = x.Estado
        }).ToList();
    }

    public async Task<List<Inscripcion>> ListarActivasPorClienteAsync(
        int idCliente,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        DateTime hoy = DateTime.Today;

        var consulta =
            from i in db.Inscripciones.AsNoTracking()
            join c in db.Clientes.AsNoTracking()
                on i.IdCliente equals c.IdCliente
            join p in db.Planes.AsNoTracking()
                on i.IdPlan equals p.IdPlan
            where i.IdCliente == idCliente
                && i.Estado == "Activa"
                && i.FechaFin >= hoy
                && p.Activo
            orderby i.FechaFin descending
            select new
            {
                i.IdInscripcion,
                i.IdCliente,
                i.IdPlan,
                NombreCliente = c.Nombre,
                NombrePlan = p.Nombre,
                i.FechaInicio,
                i.FechaFin,
                i.Estado
            };

        var filas = await consulta
            .ToListAsync(cancellationToken);

        return filas.Select(x => new Inscripcion
        {
            IdInscripcion = x.IdInscripcion,
            IdCliente = x.IdCliente,
            IdPlan = x.IdPlan,
            NombreCliente = x.NombreCliente,
            NombrePlan = x.NombrePlan,
            FechaInicio = x.FechaInicio,
            FechaFin = x.FechaFin,
            Estado = x.Estado
        }).ToList();
    }

    public async Task CrearAsync(
        Inscripcion inscripcion,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        inscripcion.Estado = "Activa";

        db.Inscripciones.Add(inscripcion);

        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> EsActivaAsync(
        int idInscripcion,
        int idCliente,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        DateTime hoy = DateTime.Today;

        return await db.Inscripciones
            .AsNoTracking()
            .AnyAsync(i =>
                i.IdInscripcion == idInscripcion &&
                i.IdCliente == idCliente &&
                i.Estado == "Activa" &&
                i.FechaFin >= hoy,
                cancellationToken);
    }

    public async Task CancelarAsync(
        int idInscripcion,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        var inscripcion = await db.Inscripciones
            .FirstOrDefaultAsync(
                i => i.IdInscripcion == idInscripcion,
                cancellationToken);

        if (inscripcion is null)
        {
            throw new InvalidOperationException(
                "La inscripción seleccionada ya no existe.");
        }

        inscripcion.Estado = "Cancelada";

        await db.SaveChangesAsync(cancellationToken);
    }
}
