using System.Data;
using GymSystem.Entidades;
using GymSystem.Negocio;

namespace GymSystem;

public partial class FrmInscripciones : Form
{
    private int idInscripcionSeleccionada = 0;

    private readonly ClienteService clienteService;
    private readonly PlanService planService;
    private readonly InscripcionService inscripcionService;

    public FrmInscripciones()
    {
        InitializeComponent();

        clienteService = new ClienteService();
        planService = new PlanService();
        inscripcionService = new InscripcionService();

        Load += FrmInscripciones_Load;
        cmbPlan.SelectedIndexChanged += CmbPlan_SelectedIndexChanged;
        dtpFechaInicio.ValueChanged += DtpFechaInicio_ValueChanged;
        dgvInscripciones.CellClick += DgvInscripciones_CellClick;
        txtBuscar.TextChanged += TxtBuscar_TextChanged;
    }

    private void FrmInscripciones_Load(
        object? sender,
        EventArgs e)
    {
        CargarClientes();
        CargarPlanes();
        CargarInscripciones();

        dtpFechaInicio.Value =
            DateTime.Today;

        dtpFechaFin.Value =
            DateTime.Today;

        cmbCliente.SelectedIndex = -1;
        cmbPlan.SelectedIndex = -1;
    }

    private void CargarClientes()
    {
        try
        {
            List<Cliente> clientes =
                clienteService.Listar(true);

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

    private void CargarPlanes()
    {
        try
        {
            List<Plan> planes =
                planService.Listar(true);

            cmbPlan.DataSource = planes;
            cmbPlan.DisplayMember = "Nombre";
            cmbPlan.ValueMember = "IdPlan";
            cmbPlan.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No fue posible cargar los planes:\n\n" +
                ex.Message,
                "Error de base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void CargarInscripciones(
        string textoBuscar = "")
    {
        try
        {
            List<Inscripcion> inscripciones =
                inscripcionService.Buscar(
                    textoBuscar);

            DataTable tabla =
                CrearTablaInscripciones(
                    inscripciones);

            dgvInscripciones.DataSource =
                tabla;

            if (dgvInscripciones.Columns.Contains(
                "IdInscripcion"))
            {
                dgvInscripciones.Columns[
                    "IdInscripcion"]!.Visible = false;
            }

            if (dgvInscripciones.Columns.Contains(
                "IdCliente"))
            {
                dgvInscripciones.Columns[
                    "IdCliente"]!.Visible = false;
            }

            if (dgvInscripciones.Columns.Contains(
                "IdPlan"))
            {
                dgvInscripciones.Columns[
                    "IdPlan"]!.Visible = false;
            }

            if (dgvInscripciones.Columns.Contains(
                "Cliente"))
            {
                dgvInscripciones.Columns[
                    "Cliente"]!.HeaderText =
                    "Cliente";
            }

            if (dgvInscripciones.Columns.Contains(
                "NombrePlan"))
            {
                dgvInscripciones.Columns[
                    "NombrePlan"]!.HeaderText =
                    "Plan";
            }

            if (dgvInscripciones.Columns.Contains(
                "FechaInicio"))
            {
                dgvInscripciones.Columns[
                    "FechaInicio"]!.HeaderText =
                    "Fecha inicio";
            }

            if (dgvInscripciones.Columns.Contains(
                "FechaFin"))
            {
                dgvInscripciones.Columns[
                    "FechaFin"]!.HeaderText =
                    "Fecha vencimiento";
            }

            if (dgvInscripciones.Columns.Contains(
                "Estado"))
            {
                dgvInscripciones.Columns[
                    "Estado"]!.HeaderText =
                    "Estado";
            }

            dgvInscripciones.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvInscripciones.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvInscripciones.MultiSelect = false;
            dgvInscripciones.ReadOnly = true;
            dgvInscripciones.ClearSelection();
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

    private static DataTable CrearTablaInscripciones(
        List<Inscripcion> inscripciones)
    {
        DataTable tabla =
            new DataTable();

        tabla.Columns.Add(
            "IdInscripcion",
            typeof(int));

        tabla.Columns.Add(
            "IdCliente",
            typeof(int));

        tabla.Columns.Add(
            "IdPlan",
            typeof(int));

        tabla.Columns.Add(
            "Cliente",
            typeof(string));

        tabla.Columns.Add(
            "NombrePlan",
            typeof(string));

        tabla.Columns.Add(
            "FechaInicio",
            typeof(DateTime));

        tabla.Columns.Add(
            "FechaFin",
            typeof(DateTime));

        tabla.Columns.Add(
            "Estado",
            typeof(string));

        foreach (
            Inscripcion inscripcion
            in inscripciones)
        {
            DataRow fila =
                tabla.NewRow();

            fila["IdInscripcion"] =
                inscripcion.IdInscripcion;

            fila["IdCliente"] =
                inscripcion.IdCliente;

            fila["IdPlan"] =
                inscripcion.IdPlan;

            fila["Cliente"] =
                inscripcion.NombreCliente;

            fila["NombrePlan"] =
                inscripcion.NombrePlan;

            fila["FechaInicio"] =
                inscripcion.FechaInicio;

            fila["FechaFin"] =
                inscripcion.FechaFin;

            fila["Estado"] =
                inscripcion.Estado;

            tabla.Rows.Add(fila);
        }

        return tabla;
    }

    private void CmbPlan_SelectedIndexChanged(
        object? sender,
        EventArgs e)
    {
        CalcularFechaFin();
    }

    private void DtpFechaInicio_ValueChanged(
        object? sender,
        EventArgs e)
    {
        CalcularFechaFin();
    }

    private void CalcularFechaFin()
    {
        if (cmbPlan.SelectedItem is Plan plan)
        {
            dtpFechaFin.Value =
                dtpFechaInicio.Value.Date.AddDays(
                    plan.DuracionDias);
        }
    }

    private void BtnNuevo_Click(
        object? sender,
        EventArgs e)
    {
        idInscripcionSeleccionada = 0;

        cmbCliente.SelectedIndex = -1;
        cmbPlan.SelectedIndex = -1;

        dtpFechaInicio.Value =
            DateTime.Today;

        dtpFechaFin.Value =
            DateTime.Today;
    }

    private bool ValidarCampos()
    {
        if (cmbCliente.SelectedIndex < 0)
        {
            MessageBox.Show(
                "Seleccione un cliente.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            cmbCliente.Focus();
            return false;
        }

        if (cmbPlan.SelectedIndex < 0)
        {
            MessageBox.Show(
                "Seleccione un plan.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            cmbPlan.Focus();
            return false;
        }

        return true;
    }

    private void BtnGuardar_Click(
        object? sender,
        EventArgs e)
    {
        if (!ValidarCampos())
            return;

        int idCliente =
            Convert.ToInt32(
                cmbCliente.SelectedValue);

        int idPlan =
            Convert.ToInt32(
                cmbPlan.SelectedValue);

        Inscripcion inscripcion =
            new Inscripcion
            {
                IdCliente =
                    idCliente,

                IdPlan =
                    idPlan,

                FechaInicio =
                    dtpFechaInicio.Value.Date,

                FechaFin =
                    dtpFechaFin.Value.Date,

                Estado =
                    "Activa"
            };

        try
        {
            inscripcionService.Registrar(
                inscripcion);

            MessageBox.Show(
                "Inscripción registrada correctamente.",
                "GymSystem",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            BtnNuevo_Click(
                null,
                EventArgs.Empty);

            CargarInscripciones(
                txtBuscar.Text.Trim());
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
                "No fue posible registrar la inscripción:\n\n" +
                ex.Message,
                "Error de base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void BtnEliminar_Click(
        object? sender,
        EventArgs e)
    {
        if (dgvInscripciones.CurrentRow == null)
        {
            MessageBox.Show(
                "Seleccione una inscripción.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        int idInscripcion =
            Convert.ToInt32(
                dgvInscripciones.CurrentRow
                    .Cells["IdInscripcion"]
                    .Value);

        DialogResult respuesta =
            MessageBox.Show(
                "¿Desea cancelar esta inscripción?\n\n" +
                "La información permanecerá guardada.",
                "Cancelar inscripción",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (respuesta != DialogResult.Yes)
            return;

        try
        {
            inscripcionService.Cancelar(
                idInscripcion);

            MessageBox.Show(
                "La inscripción fue cancelada correctamente.",
                "GymSystem",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            BtnNuevo_Click(
                null,
                EventArgs.Empty);

            CargarInscripciones(
                txtBuscar.Text.Trim());
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No fue posible cancelar la inscripción:\n\n" +
                ex.Message,
                "Error de base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void DgvInscripciones_CellClick(
        object? sender,
        DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        DataGridViewRow fila =
            dgvInscripciones.Rows[e.RowIndex];

        if (fila.Cells["IdCliente"].Value == null ||
            fila.Cells["IdPlan"].Value == null ||
            fila.Cells["IdInscripcion"].Value == null)
        {
            return;
        }

        int idCliente =
            Convert.ToInt32(
                fila.Cells["IdCliente"].Value);

        int idPlan =
            Convert.ToInt32(
                fila.Cells["IdPlan"].Value);

        idInscripcionSeleccionada =
            Convert.ToInt32(
                fila.Cells["IdInscripcion"].Value);

        cmbCliente.SelectedValue =
            idCliente;

        cmbPlan.SelectedValue =
            idPlan;

        if (DateTime.TryParse(
            fila.Cells["FechaInicio"]
                .Value?.ToString(),
            out DateTime fechaInicio))
        {
            dtpFechaInicio.Value =
                fechaInicio;
        }

        if (DateTime.TryParse(
            fila.Cells["FechaFin"]
                .Value?.ToString(),
            out DateTime fechaFin))
        {
            dtpFechaFin.Value =
                fechaFin;
        }
    }

    private void TxtBuscar_TextChanged(
        object? sender,
        EventArgs e)
    {
        CargarInscripciones(
            txtBuscar.Text.Trim());
    }
}
