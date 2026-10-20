using GymSystem.Datos;
using GymSystem.Entidades;

namespace GymSystem.Negocio;

public partial class PlanService
{
    private readonly PlanRepository _repository;

    public PlanService()
    {
        _repository = new PlanRepository();
    }

    private static void Validar(
        Plan plan)
    {
        plan.Nombre =
            plan.Nombre.Trim();

        if (string.IsNullOrWhiteSpace(
            plan.Nombre))
        {
            throw new ArgumentException(
                "Ingrese el nombre del plan.");
        }

        if (plan.Nombre.Length > 100)
        {
            throw new ArgumentException(
                "El nombre del plan no puede superar los 100 caracteres.");
        }

        if (plan.DuracionDias <= 0)
        {
            throw new ArgumentException(
                "Ingrese una duración válida.");
        }

        if (plan.Precio <= 0)
        {
            throw new ArgumentException(
                "Ingrese un precio válido.");
        }
    }
}
