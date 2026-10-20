using GymSystem.Entidades;

namespace GymSystem.Negocio;

public partial class PagoService
{
    public async Task<List<Pago>> GenerarReporteAsync(
        DateTime desde,
        DateTime hasta,
        CancellationToken cancellationToken = default)
    {
        desde = desde.Date;
        hasta = hasta.Date;

        if (desde > hasta)
        {
            throw new ArgumentException(
                "La fecha inicial no puede ser posterior a la fecha final.");
        }

        return await _repository.ReportePorFechasAsync(
            desde,
            hasta,
            cancellationToken);
    }
    public async Task<List<Pago>> BuscarAsync(
        string texto = "",
        CancellationToken cancellationToken = default)
    {
        return await _repository.BuscarAsync(
            texto,
            cancellationToken);
    }

    public async Task RegistrarAsync(
        Pago pago,
        InscripcionService inscripcionService,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(pago);
        ArgumentNullException.ThrowIfNull(inscripcionService);

        Validar(pago);

        if (!pago.IdInscripcion.HasValue)
        {
            throw new ArgumentException(
                "Seleccione una inscripción activa.");
        }

        bool inscripcionActiva =
            await inscripcionService.EsActivaAsync(
                pago.IdInscripcion.Value,
                pago.IdCliente,
                cancellationToken);

        if (!inscripcionActiva)
        {
            throw new InvalidOperationException(
                "La inscripción seleccionada ya no está activa.");
        }

        await _repository.CrearAsync(
            pago,
            cancellationToken);
    }
}
