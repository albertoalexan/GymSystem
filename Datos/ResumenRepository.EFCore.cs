using GymSystem.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GymSystem.Datos;

public partial class ResumenRepository
{
    public async Task<ResumenSistema> ObtenerResumenAsync(
        CancellationToken cancellationToken = default)
    {
        await using var db = new GymDbContext();

        var resumen = new ResumenSistema
        {
            CantidadClientes = await db.Clientes
                .AsNoTracking()
                .CountAsync(c => c.Activo, cancellationToken),

            CantidadPlanes = await db.Planes
                .AsNoTracking()
                .CountAsync(p => p.Activo, cancellationToken),

            CantidadInscripciones = await db.Inscripciones
                .AsNoTracking()
                .CountAsync(i => i.Estado == "Activa", cancellationToken),

            CantidadPagos = await db.Pagos
                .AsNoTracking()
                .CountAsync(cancellationToken)
        };

        return resumen;
    }
}
