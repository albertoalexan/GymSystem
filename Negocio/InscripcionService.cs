using GymSystem.Datos;
using GymSystem.Entidades;

namespace GymSystem.Negocio;

public class InscripcionService
{
    private readonly InscripcionRepository _repository;

    public InscripcionService()
    {
        _repository = new InscripcionRepository();
    }

    public List<Inscripcion> Buscar(
        string texto = "")
    {
        return _repository.Buscar(texto);
    }

    public List<Inscripcion> ListarActivasPorCliente(
        int idCliente)
    {
        if (idCliente <= 0)
        {
            return new List<Inscripcion>();
        }

        return _repository.ListarActivasPorCliente(
            idCliente);
    }

    public bool EsActiva(
        int idInscripcion,
        int idCliente)
    {
        if (idInscripcion <= 0 ||
            idCliente <= 0)
        {
            return false;
        }

        return _repository.EsActiva(
            idInscripcion,
            idCliente);
    }

    public void Registrar(
        Inscripcion inscripcion)
    {
        Validar(inscripcion);

        _repository.Crear(inscripcion);
    }

    public void Cancelar(
        int idInscripcion)
    {
        if (idInscripcion <= 0)
        {
            throw new ArgumentException(
                "La inscripción seleccionada no es válida.");
        }

        _repository.Cancelar(
            idInscripcion);
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
