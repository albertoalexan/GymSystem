using GymSystem.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GymSystem.Datos;

public partial class PlanRepository
{
    public async Task<List<Plan>> ListarAsync(
        bool soloActivos = true,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        IQueryable<Plan> consulta =
            db.Planes.AsNoTracking();

        if (soloActivos)
        {
            consulta = consulta.Where(p => p.Activo);
        }

        return await consulta
            .OrderByDescending(p => p.Activo)
            .ThenBy(p => p.Nombre)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Plan>> BuscarAsync(
        string texto,
        bool incluirInactivos = false,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        IQueryable<Plan> consulta =
            db.Planes.AsNoTracking();

        if (!incluirInactivos)
        {
            consulta = consulta.Where(p => p.Activo);
        }

        if (!string.IsNullOrWhiteSpace(texto))
        {
            string termino = texto.Trim();

            consulta = consulta.Where(
                p => p.Nombre.Contains(termino));
        }

        return await consulta
            .OrderByDescending(p => p.Activo)
            .ThenBy(p => p.Nombre)
            .ToListAsync(cancellationToken);
    }

    public async Task CrearAsync(
        Plan plan,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        plan.Activo = true;

        db.Planes.Add(plan);

        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task ActualizarAsync(
        Plan plan,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        var existente = await db.Planes
            .FirstOrDefaultAsync(
                p => p.IdPlan == plan.IdPlan,
                cancellationToken);

        if (existente is null)
        {
            throw new InvalidOperationException(
                "El plan seleccionado ya no existe.");
        }

        existente.Nombre = plan.Nombre;
        existente.DuracionDias = plan.DuracionDias;
        existente.Precio = plan.Precio;

        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task CambiarEstadoAsync(
        int idPlan,
        bool activo,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        var plan = await db.Planes
            .FirstOrDefaultAsync(
                p => p.IdPlan == idPlan,
                cancellationToken);

        if (plan is null)
        {
            throw new InvalidOperationException(
                "El plan seleccionado ya no existe.");
        }

        plan.Activo = activo;

        await db.SaveChangesAsync(cancellationToken);
    }
}
