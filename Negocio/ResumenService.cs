using GymSystem.Datos;
using GymSystem.Entidades;

namespace GymSystem.Negocio;

public partial class ResumenService
{
    private readonly ResumenRepository _repository;

    public ResumenService()
    {
        _repository = new ResumenRepository();
    }

}
