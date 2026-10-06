namespace GymSystem.Entidades;

public class Inscripcion
{
    public int IdInscripcion { get; set; }

    public int IdCliente { get; set; }

    public int IdPlan { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public string Estado { get; set; } = "Activa";

    public string NombreCliente { get; set; } = string.Empty;

    public string NombrePlan { get; set; } = string.Empty;
}
