namespace GymSystem.Entidades;

public class Plan
{
    public int IdPlan { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int DuracionDias { get; set; }
    public decimal Precio { get; set; }
    public string? Descripcion { get; set; }
    public bool Activo { get; set; }
}
