using GymSystem.Datos;
using GymSystem.Entidades;

namespace GymSystem.Negocio;

public partial class InscripcionService
{
    private readonly InscripcionRepository _repository;

    public InscripcionService()
    {
        _repository = new InscripcionRepository();
    }

    private static void Validar(
        Inscripcion inscripcion)
    {
        if (inscripcion.IdCliente <= 0)
        {
            throw new ArgumentException(
                "Seleccione un cliente.");
        }

        if (inscripcion.IdPlan <= 0)
        {
            throw new ArgumentException(
                "Seleccione un plan.");
        }

        if (inscripcion.FechaFin <
            inscripcion.FechaInicio)
        {
            throw new ArgumentException(
                "La fecha de vencimiento no puede ser anterior a la fecha de inicio.");
        }
    }
}
