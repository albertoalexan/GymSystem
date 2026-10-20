using GymSystem.Entidades;

namespace GymSystem.Negocio;

public partial class InscripcionService
{
    public async Task<List<Inscripcion>> BuscarAsync(
        string texto = "",
        CancellationToken cancellationToken = default)
    {
        return await _repository.BuscarAsync(
            texto,
            cancellationToken);
    }

    public async Task<List<Inscripcion>> ListarActivasPorClienteAsync(
        int idCliente,
        CancellationToken cancellationToken = default)
    {
        if (idCliente <= 0)
        {
            return new List<Inscripcion>();
        }

        return await _repository.ListarActivasPorClienteAsync(
            idCliente,
            cancellationToken);
    }

    public async Task<bool> EsActivaAsync(
        int idInscripcion,
        int idCliente,
        CancellationToken cancellationToken = default)
    {
        if (idInscripcion <= 0 || idCliente <= 0)
        {
            return false;
        }

        return await _repository.EsActivaAsync(
            idInscripcion,
            idCliente,
            cancellationToken);
    }

    public async Task RegistrarAsync(
        Inscripcion inscripcion,
        CancellationToken cancellationToken = default)
    {
        Validar(inscripcion);

        await _repository.CrearAsync(
            inscripcion,
            cancellationToken);
    }

    public async Task CancelarAsync(
        int idInscripcion,
        CancellationToken cancellationToken = default)
    {
        if (idInscripcion <= 0)
        {
            throw new ArgumentException(
                "La inscripción seleccionada no es válida.");
        }

        await _repository.CancelarAsync(
            idInscripcion,
            cancellationToken);
    }
}
