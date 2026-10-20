using GymSystem.Entidades;

namespace GymSystem.Negocio;

public partial class PlanService
{
    public async Task<List<Plan>> ListarAsync(
        bool soloActivos = true,
        CancellationToken cancellationToken = default)
    {
        return await _repository.ListarAsync(
            soloActivos,
            cancellationToken);
    }

    public async Task<List<Plan>> BuscarAsync(
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
        Plan plan,
        CancellationToken cancellationToken = default)
    {
        Validar(plan);

        if (plan.IdPlan == 0)
        {
            await _repository.CrearAsync(
                plan,
                cancellationToken);
        }
        else
        {
            await _repository.ActualizarAsync(
                plan,
                cancellationToken);
        }
    }

    public async Task DesactivarAsync(
        int idPlan,
        CancellationToken cancellationToken = default)
    {
        if (idPlan <= 0)
        {
            throw new ArgumentException(
                "El plan seleccionado no es válido.");
        }

        await _repository.CambiarEstadoAsync(
            idPlan,
            false,
            cancellationToken);
    }

    public async Task RestaurarAsync(
        int idPlan,
        CancellationToken cancellationToken = default)
    {
        if (idPlan <= 0)
        {
            throw new ArgumentException(
                "El plan seleccionado no es válido.");
        }

        await _repository.CambiarEstadoAsync(
            idPlan,
            true,
            cancellationToken);
    }
}
