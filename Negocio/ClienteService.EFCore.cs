using GymSystem.Entidades;

namespace GymSystem.Negocio;

public partial class ClienteService
{
    public async Task<List<Cliente>> ListarAsync(
        bool soloActivos = true,
        CancellationToken cancellationToken = default)
    {
        return await _repository.ListarAsync(
            soloActivos,
            cancellationToken);
    }

    public async Task<List<Cliente>> BuscarAsync(
        string texto,
        bool incluirInactivos = false,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(texto))
        {
            return await _repository.ListarAsync(
                !incluirInactivos,
                cancellationToken);
        }

        return await _repository.BuscarAsync(
            texto,
            incluirInactivos,
            cancellationToken);
    }

    public async Task GuardarAsync(
        Cliente cliente,
        CancellationToken cancellationToken = default)
    {
        Validar(cliente);

        bool duplicado = await _repository.ExisteDuplicadoAsync(
            cliente.NumeroCedula,
            cliente.Correo,
            cliente.IdCliente,
            cancellationToken);

        if (duplicado)
        {
            throw new InvalidOperationException(
                "La cédula o el correo ya están registrados.");
        }

        if (cliente.IdCliente == 0)
        {
            await _repository.CrearAsync(
                cliente,
                cancellationToken);
        }
        else
        {
            await _repository.ActualizarAsync(
                cliente,
                cancellationToken);
        }
    }

    public async Task DesactivarAsync(
        int idCliente,
        CancellationToken cancellationToken = default)
    {
        if (idCliente <= 0)
        {
            throw new ArgumentException(
                "El cliente seleccionado no es válido.");
        }

        await _repository.DesactivarAsync(
            idCliente,
            cancellationToken);
    }

    public async Task RestaurarAsync(
        int idCliente,
        CancellationToken cancellationToken = default)
    {
        if (idCliente <= 0)
        {
            throw new ArgumentException(
                "El cliente seleccionado no es válido.");
        }

        await _repository.RestaurarAsync(
            idCliente,
            cancellationToken);
    }
}
