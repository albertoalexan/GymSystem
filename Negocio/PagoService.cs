using GymSystem.Datos;
using GymSystem.Entidades;

namespace GymSystem.Negocio;

public partial class PagoService
{
    private readonly PagoRepository _repository;

    public PagoService()
    {
        _repository = new PagoRepository();
    }

    private static void Validar(
        Pago pago)
    {
        if (pago.IdCliente <= 0)
        {
            throw new ArgumentException(
                "Seleccione un cliente.");
        }

        if (!pago.IdInscripcion.HasValue ||
            pago.IdInscripcion.Value <= 0)
        {
            throw new ArgumentException(
                "Seleccione una inscripción activa.");
        }

        if (pago.Monto <= 0)
        {
            throw new ArgumentException(
                "El monto debe ser mayor que 0.");
        }

        if (pago.Monto > 1_000_000)
        {
            throw new ArgumentException(
                "El monto no puede superar C$ 1,000,000.");
        }

        if (decimal.Round(pago.Monto, 2) !=
            pago.Monto)
        {
            throw new ArgumentException(
                "El monto solo puede tener hasta 2 decimales.");
        }

        string[] metodosPermitidos =
        {
            "Efectivo",
            "Tarjeta",
            "Transferencia"
        };

        if (!metodosPermitidos.Contains(
            pago.MetodoPago))
        {
            throw new ArgumentException(
                "Seleccione un método de pago válido.");
        }
    }
}
