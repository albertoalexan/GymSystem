using GymSystem.Datos;
using GymSystem.Entidades;

namespace GymSystem.Negocio;

public class PlanService
{
    private readonly PlanRepository _repository;

    public PlanService()
    {
        _repository = new PlanRepository();
    }

    public List<Plan> Listar(
        bool soloActivos = true)
    {
        return _repository.Listar(
            soloActivos);
    }

    public List<Plan> Buscar(
        string texto,
        bool incluirInactivos = false)
    {
        if (string.IsNullOrWhiteSpace(texto))
        {
            return _repository.Listar(
                !incluirInactivos);
        }

        return _repository.Buscar(
            texto,
            incluirInactivos);
    }

    public void Guardar(Plan plan)
    {
        Validar(plan);

        if (plan.IdPlan == 0)
        {
            _repository.Crear(plan);
        }
        else
        {
            _repository.Actualizar(plan);
        }
    }

    public void Desactivar(int idPlan)
    {
        if (idPlan <= 0)
        {
            throw new ArgumentException(
                "El plan seleccionado no es válido.");
        }

        _repository.CambiarEstado(
            idPlan,
            false);
    }

    public void Restaurar(int idPlan)
    {
        if (idPlan <= 0)
        {
            throw new ArgumentException(
                "El plan seleccionado no es válido.");
        }

        _repository.CambiarEstado(
            idPlan,
            true);
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
