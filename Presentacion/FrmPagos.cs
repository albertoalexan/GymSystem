using System.Data;
using GymSystem.Entidades;
using GymSystem.Negocio;

namespace GymSystem;

public partial class FrmPagos : Form
{
    private readonly ClienteService clienteService;
    private readonly InscripcionService inscripcionService;
    private readonly PagoService pagoService;

    public FrmPagos()
    {
        InitializeComponent();

        clienteService = new ClienteService();
        inscripcionService = new InscripcionService();
        pagoService = new PagoService();

        Load += FrmPagos_Load;
        txtBuscar.TextChanged += TxtBuscar_TextChanged;
    }

    private async void FrmPagos_Load(
        object? sender,
        EventArgs e)
    {
        await CargarClientesAsync();
        await CargarPagosAsync();

        cmbCliente.SelectedIndex = -1;
        cmbInscripcion.DataSource = null;
        cmbMetodo.SelectedIndex = -1;
    }

    private async Task CargarClientesAsync()
    {
        try
        {
            List<Cliente> clientes =
                await clienteService.ListarAsync(true);

            cmbCliente.DataSource = clientes;
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "IdCliente";
            cmbCliente.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No fue posible cargar los clientes:\n\n" +
                ex.Message,
                "Error de base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void CmbCliente_SelectedIndexChanged(
        object? sender,
        EventArgs e)
    {
        if (cmbCliente.SelectedValue == null)
            return;

        if (cmbCliente.SelectedValue is DataRowView)
            return;

        if (!int.TryParse(
            cmbCliente.SelectedValue.ToString(),
            out int idCliente))
        {
            return;
        }

        await CargarInscripcionesAsync(idCliente);
    }

    private async Task CargarInscripcionesAsync(
        int idCliente)
    {
        try
        {
            List<Inscripcion> inscripciones =
                await inscripcionService.ListarActivasPorClienteAsync(
                    idCliente);

            cmbInscripcion.DataSource =
                inscripciones;

            cmbInscripcion.DisplayMember =
                "NombrePlan";

            cmbInscripcion.ValueMember =
                "IdInscripcion";

            cmbInscripcion.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No fue posible cargar las inscripciones:\n\n" +
                ex.Message,
                "Error de base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async Task CargarPagosAsync(
        string textoBuscar = "")
    {
        try
        {
            List<Pago> pagos =
                await pagoService.BuscarAsync(
                    textoBuscar);

            DataTable tabla =
                CrearTablaPagos(pagos);

            dgvPagos.DataSource = tabla;

            if (dgvPagos.Columns.Contains("IdPago"))
            {
                dgvPagos.Columns["IdPago"]!.Visible =
                    false;
            }

            if (dgvPagos.Columns.Contains("IdCliente"))
            {
                dgvPagos.Columns["IdCliente"]!.Visible =
                    false;
            }

            if (dgvPagos.Columns.Contains("IdInscripcion"))
            {
                dgvPagos.Columns["IdInscripcion"]!.Visible =
                    false;
            }

            if (dgvPagos.Columns.Contains("NombrePlan"))
            {
                dgvPagos.Columns["NombrePlan"]!.HeaderText =
                    "Plan";
            }

            if (dgvPagos.Columns.Contains("MetodoPago"))
            {
                dgvPagos.Columns["MetodoPago"]!.HeaderText =
                    "Método de pago";
            }

            if (dgvPagos.Columns.Contains("Fecha"))
            {
                dgvPagos.Columns["Fecha"]!.HeaderText =
                    "Fecha";
            }

            if (dgvPagos.Columns.Contains("Monto"))
            {
                dgvPagos.Columns["Monto"]!
                    .DefaultCellStyle.Format = "C2";
            }

            dgvPagos.ClearSelection();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No fue posible cargar los pagos:\n\n" +
                ex.Message,
                "Error de base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private static DataTable CrearTablaPagos(
        List<Pago> pagos)
    {
        DataTable tabla =
            new DataTable();

        tabla.Columns.Add(
            "IdPago",
            typeof(int));

        tabla.Columns.Add(
            "IdCliente",
            typeof(int));

        tabla.Columns.Add(
            "IdInscripcion",
            typeof(int));

        tabla.Columns.Add(
            "Cliente",
            typeof(string));

        tabla.Columns.Add(
            "NombrePlan",
            typeof(string));

        tabla.Columns.Add(
            "Monto",
            typeof(decimal));

        tabla.Columns.Add(
            "Fecha",
            typeof(DateTime));

        tabla.Columns.Add(
            "MetodoPago",
            typeof(string));

        foreach (Pago pago in pagos)
        {
            DataRow fila =
                tabla.NewRow();

            fila["IdPago"] =
                pago.IdPago;

            fila["IdCliente"] =
                pago.IdCliente;

            fila["IdInscripcion"] =
                pago.IdInscripcion.HasValue
                    ? pago.IdInscripcion.Value
                    : DBNull.Value;

            fila["Cliente"] =
                pago.NombreCliente;

            fila["NombrePlan"] =
                pago.NombrePlan;

            fila["Monto"] =
                pago.Monto;

            fila["Fecha"] =
                pago.Fecha;

            fila["MetodoPago"] =
                pago.MetodoPago;

            tabla.Rows.Add(fila);
        }

        return tabla;
    }

    private void BtnNuevo_Click(
        object? sender,
        EventArgs e)
    {
        cmbCliente.SelectedIndex = -1;
        cmbInscripcion.DataSource = null;
        txtMonto.Clear();
        cmbMetodo.SelectedIndex = -1;

        cmbCliente.Focus();
    }

    private bool ValidarCampos()
    {
        if (cmbCliente.SelectedIndex < 0)
        {
            MostrarValidacion(
                "Seleccione un cliente.",
                cmbCliente);

            return false;
        }

        if (cmbInscripcion.SelectedIndex < 0)
        {
            MostrarValidacion(
                "Seleccione una inscripción activa.",
                cmbInscripcion);

            return false;
        }

        string montoTexto =
            txtMonto.Text.Trim();

        if (string.IsNullOrWhiteSpace(
            montoTexto))
        {
            MostrarValidacion(
                "Ingrese el monto del pago.",
                txtMonto);

            return false;
        }

        if (!decimal.TryParse(
            montoTexto,
            out decimal monto))
        {
            MostrarValidacion(
                "Ingrese un monto numérico válido.",
                txtMonto);

            return false;
        }

        if (monto <= 0)
        {
            MostrarValidacion(
                "El monto debe ser mayor que 0.",
                txtMonto);

            return false;
        }

        if (monto > 1_000_000)
        {
            MostrarValidacion(
                "El monto no puede superar C$ 1,000,000.",
                txtMonto);

            return false;
        }

        if (decimal.Round(monto, 2) !=
            monto)
        {
            MostrarValidacion(
                "El monto solo puede tener hasta 2 decimales.",
                txtMonto);

            return false;
        }

        if (cmbMetodo.SelectedIndex < 0)
        {
            MostrarValidacion(
                "Seleccione un método de pago.",
                cmbMetodo);

            return false;
        }

        return true;
    }

    private void MostrarValidacion(
        string mensaje,
        Control control)
    {
        MessageBox.Show(
            mensaje,
            "Validación",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        control.Focus();
    }

    private async void BtnGuardar_Click(
        object? sender,
        EventArgs e)
    {
        if (!ValidarCampos())
            return;

        if (!int.TryParse(
            cmbCliente.SelectedValue?.ToString(),
            out int idCliente))
        {
            MessageBox.Show(
                "No se pudo identificar el cliente.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (!int.TryParse(
            cmbInscripcion.SelectedValue?.ToString(),
            out int idInscripcion))
        {
            MessageBox.Show(
                "No se pudo identificar la inscripción.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (!decimal.TryParse(
            txtMonto.Text.Trim(),
            out decimal monto))
        {
            MessageBox.Show(
                "Ingrese un monto válido.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtMonto.Focus();
            return;
        }

        string metodo =
            cmbMetodo.SelectedItem?.ToString() ?? "";

        Pago pago = new Pago
        {
            IdCliente =
                idCliente,

            IdInscripcion =
                idInscripcion,

            Monto =
                monto,

            MetodoPago =
                metodo,

            Fecha =
                DateTime.Today
        };

        try
        {
            await pagoService.RegistrarAsync(
                pago,
                inscripcionService);

            MessageBox.Show(
                "Pago registrado correctamente.",
                "GymSystem",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            BtnNuevo_Click(
                null,
                EventArgs.Empty);

            await CargarPagosAsync(
                txtBuscar.Text.Trim());
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            await CargarInscripcionesAsync(
                idCliente);
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No fue posible registrar el pago:\n\n" +
                ex.Message,
                "Error de base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void TxtBuscar_TextChanged(
        object? sender,
        EventArgs e)
    {
        await CargarPagosAsync(
            txtBuscar.Text.Trim());
    }
}
