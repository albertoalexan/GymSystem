using GymSystem.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GymSystem.Datos;

public partial class PagoRepository
{
    public async Task<List<Pago>> ReportePorFechasAsync(
        DateTime desde,
        DateTime hasta,
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        DateTime fechaDesde = desde.Date;
        DateTime fechaHastaExclusiva = hasta.Date.AddDays(1);

        var consulta =
            from pago in db.Pagos.AsNoTracking()
            join cliente in db.Clientes.AsNoTracking()
                on pago.IdCliente equals cliente.IdCliente
            join inscripcionDb in db.Inscripciones.AsNoTracking()
                on pago.IdInscripcion equals (int?)inscripcionDb.IdInscripcion
                into inscripciones
            from inscripcion in inscripciones.DefaultIfEmpty()
            join planDb in db.Planes.AsNoTracking()
                on (inscripcion == null
                    ? (int?)null
                    : (int?)inscripcion.IdPlan)
                equals (int?)planDb.IdPlan
                into planes
            from plan in planes.DefaultIfEmpty()
            where pago.Fecha >= fechaDesde
                && pago.Fecha < fechaHastaExclusiva
            select new
            {
                pago.IdPago,
                pago.IdCliente,
                pago.IdInscripcion,
                NombreCliente = cliente.Nombre,
                NombrePlan = plan == null
                    ? string.Empty
                    : plan.Nombre,
                pago.Monto,
                pago.Fecha,
                pago.MetodoPago
            };

        var filas = await consulta
            .OrderBy(p => p.Fecha)
            .ThenBy(p => p.IdPago)
            .ToListAsync(cancellationToken);

        return filas.Select(p => new Pago
        {
            IdPago = p.IdPago,
            IdCliente = p.IdCliente,
            IdInscripcion = p.IdInscripcion,
            NombreCliente = p.NombreCliente,
            NombrePlan = p.NombrePlan,
            Monto = p.Monto,
            Fecha = p.Fecha,
            MetodoPago = p.MetodoPago
        }).ToList();
    }
    public async Task<List<Pago>> BuscarAsync(
        string texto = "",
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        var consulta =
            from pago in db.Pagos.AsNoTracking()
            join cliente in db.Clientes.AsNoTracking()
                on pago.IdCliente equals cliente.IdCliente
            join inscripcionDb in db.Inscripciones.AsNoTracking()
                on pago.IdInscripcion equals (int?)inscripcionDb.IdInscripcion
                into inscripciones
            from inscripcion in inscripciones.DefaultIfEmpty()
            join planDb in db.Planes.AsNoTracking()
                on (inscripcion == null
                    ? (int?)null
                    : (int?)inscripcion.IdPlan)
                equals (int?)planDb.IdPlan
                into planes
            from plan in planes.DefaultIfEmpty()
            select new
            {
                pago.IdPago,
                pago.IdCliente,
                pago.IdInscripcion,
                NombreCliente = cliente.Nombre,
                NombrePlan = plan == null
                    ? string.Empty
                    : plan.Nombre,
                pago.Monto,
                pago.Fecha,
                pago.MetodoPago
            };

        if (!string.IsNullOrWhiteSpace(texto))
        {
            string termino = texto.Trim();

            consulta = consulta.Where(p =>
                p.NombreCliente.Contains(termino) ||
                p.NombrePlan.Contains(termino));
        }

        var filas = await consulta
            .OrderByDescending(p => p.IdPago)
            .ToListAsync(cancellationToken);

        return filas.Select(p => new Pago
        {
            IdPago = p.IdPago,
            IdCliente = p.IdCliente,
            IdInscripcion = p.IdInscripcion,
            NombreCliente = p.NombreCliente,
            NombrePlan = p.NombrePlan,
            Monto = p.Monto,
            Fecha = p.Fecha,
            MetodoPago = p.MetodoPago
        }).ToList();
    }

    public async Task CrearAsync(
        Pago pago,
        CancellationToken cancellationToken = default)
    {
        if (!pago.IdInscripcion.HasValue)
        {
            throw new ArgumentException(
                "Seleccione una inscripción activa.");
        }

        await using var db = new GymDbContext();

        // Verificar la inscripción y guardar el pago dentro
        // de la misma transacción.
        await using var transaccion =
            await db.Database.BeginTransactionAsync(
                System.Data.IsolationLevel.Serializable,
                cancellationToken);

        DateTime hoy = DateTime.Today;
        int idInscripcion = pago.IdInscripcion.Value;

        bool inscripcionValida = await db.Inscripciones
            .AsNoTracking()
            .AnyAsync(i =>
                i.IdInscripcion == idInscripcion &&
                i.IdCliente == pago.IdCliente &&
                i.Estado == "Activa" &&
                i.FechaFin >= hoy,
                cancellationToken);

        if (!inscripcionValida)
        {
            throw new InvalidOperationException(
                "La inscripción seleccionada ya no está activa " +
                "o no pertenece al cliente seleccionado.");
        }

        db.Pagos.Add(pago);

        await db.SaveChangesAsync(cancellationToken);

        await transaccion.CommitAsync(cancellationToken);
    }
}
