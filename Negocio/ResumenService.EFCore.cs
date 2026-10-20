using GymSystem.Entidades;

namespace GymSystem.Negocio;

public partial class ResumenService
{
    public async Task<ResumenSistema> ObtenerResumenAsync(
        CancellationToken cancellationToken = default)
    {
        return await _repository.ObtenerResumenAsync(
            cancellationToken);
    }
}
