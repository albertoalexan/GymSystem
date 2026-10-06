namespace GymSystem.Entidades;

public class Pago
{
    public int IdPago { get; set; }

    public int IdCliente { get; set; }

    public int? IdInscripcion { get; set; }

    public decimal Monto { get; set; }

    public DateTime Fecha { get; set; }

    public string MetodoPago { get; set; } = string.Empty;

    public string NombreCliente { get; set; } = string.Empty;

    public string NombrePlan { get; set; } = string.Empty;
}
