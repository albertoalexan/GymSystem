using GymSystem.Datos;
using GymSystem.Entidades;

namespace GymSystem.Negocio;

public class ResumenService
{
    private readonly ResumenRepository _repository;

    public ResumenService()
    {
        _repository = new ResumenRepository();
    }

    public ResumenSistema ObtenerResumen()
    {
        return _repository.ObtenerResumen();
    }
}
