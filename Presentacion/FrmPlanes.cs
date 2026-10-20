using System.Data;
using GymSystem.Entidades;
using GymSystem.Negocio;

namespace GymSystem;

public partial class FrmPlanes : Form
{
    private int idPlanSeleccionado = 0;
    private int _versionCargaPlanes;
    private readonly PlanService planService;

    public FrmPlanes()
    {
        InitializeComponent();

        planService = new PlanService();

        Load += FrmPlanes_Load;
        dgvPlanes.CellClick += DgvPlanes_CellClick;
        txtBuscar.TextChanged += TxtBuscar_TextChanged;
        chkInactivos.CheckedChanged += ChkInactivos_CheckedChanged;
    }

    private async void FrmPlanes_Load(
        object? sender,
        EventArgs e)
    {
        await CargarPlanesAsync();
    }

    private async Task CargarPlanesAsync(
        string textoBuscar = "")
    {
        int versionSolicitud =
            Interlocked.Increment(ref _versionCargaPlanes);

        try
        {
            List<Plan> planes =
                await planService.BuscarAsync(
                    textoBuscar,
                    chkInactivos.Checked);

            if (IsDisposed ||
                versionSolicitud != Volatile.Read(ref _versionCargaPlanes))
            {
                return;
            }

            DataTable tabla =
                CrearTablaPlanes(planes);

            dgvPlanes.DataSource = tabla;

            if (dgvPlanes.Columns.Contains("IdPlan"))
            {
                dgvPlanes.Columns["IdPlan"]!.Visible = false;
            }

            if (dgvPlanes.Columns.Contains("DuracionDias"))
            {
                dgvPlanes.Columns["DuracionDias"]!.HeaderText =
                    "Duración (días)";
            }

            if (dgvPlanes.Columns.Contains("Estado"))
            {
                dgvPlanes.Columns["Estado"]!.HeaderText =
                    "Estado";
            }

            dgvPlanes.ClearSelection();
            idPlanSeleccionado = 0;
        }
        catch (Exception ex)
        {
            if (IsDisposed || versionSolicitud != Volatile.Read(ref _versionCargaPlanes)) return;
            MessageBox.Show(
                "No fue posible cargar los planes:\n\n" +
                ex.Message,
                "Error de base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private static DataTable CrearTablaPlanes(
        List<Plan> planes)
    {
        DataTable tabla =
            new DataTable();

        tabla.Columns.Add(
            "IdPlan",
            typeof(int));

        tabla.Columns.Add(
            "Nombre",
            typeof(string));

        tabla.Columns.Add(
            "DuracionDias",
            typeof(int));

        tabla.Columns.Add(
            "Precio",
            typeof(decimal));

        tabla.Columns.Add(
            "Estado",
            typeof(string));

        foreach (Plan plan in planes)
        {
            DataRow fila =
                tabla.NewRow();

            fila["IdPlan"] =
                plan.IdPlan;

            fila["Nombre"] =
                plan.Nombre;

            fila["DuracionDias"] =
                plan.DuracionDias;

            fila["Precio"] =
                plan.Precio;

            fila["Estado"] =
                plan.Activo
                    ? "Activo"
                    : "Inactivo";

            tabla.Rows.Add(fila);
        }

        return tabla;
    }

    private void DgvPlanes_CellClick(
        object? sender,
        DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        DataGridViewRow fila =
            dgvPlanes.Rows[e.RowIndex];

        if (fila.Cells["IdPlan"].Value == null)
            return;

        idPlanSeleccionado =
            Convert.ToInt32(
                fila.Cells["IdPlan"].Value);

        txtNombre.Text =
            fila.Cells["Nombre"].Value?.ToString() ?? "";

        txtDuracion.Text =
            fila.Cells["DuracionDias"].Value?.ToString() ?? "";

        txtPrecio.Text =
            fila.Cells["Precio"].Value?.ToString() ?? "";
    }

    private async void TxtBuscar_TextChanged(
        object? sender,
        EventArgs e)
    {
        await CargarPlanesAsync(
            txtBuscar.Text.Trim());
    }

    private async void ChkInactivos_CheckedChanged(
        object? sender,
        EventArgs e)
    {
        LimpiarCampos();

        await CargarPlanesAsync(
            txtBuscar.Text.Trim());
    }

    private void BtnNuevo_Click(
        object? sender,
        EventArgs e)
    {
        LimpiarCampos();
    }

    private async void BtnGuardar_Click(
        object? sender,
        EventArgs e)
    {
        string nombre =
            txtNombre.Text.Trim();

        string duracionTexto =
            txtDuracion.Text.Trim();

        string precioTexto =
            txtPrecio.Text.Trim();

        if (string.IsNullOrWhiteSpace(nombre))
        {
            MessageBox.Show(
                "Ingrese el nombre del plan.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtNombre.Focus();
            return;
        }

        if (!int.TryParse(
            duracionTexto,
            out int duracion) ||
            duracion <= 0)
        {
            MessageBox.Show(
                "Ingrese una duración válida.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtDuracion.Focus();
            return;
        }

        if (!decimal.TryParse(
            precioTexto,
            out decimal precio) ||
            precio <= 0)
        {
            MessageBox.Show(
                "Ingrese un precio válido.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtPrecio.Focus();
            return;
        }

        Plan plan = new Plan
        {
            IdPlan =
                idPlanSeleccionado,

            Nombre =
                nombre,

            DuracionDias =
                duracion,

            Precio =
                precio,

            Descripcion =
                null
        };

        try
        {
            await planService.GuardarAsync(plan);

            MessageBox.Show(
                idPlanSeleccionado == 0
                    ? "El plan se guardó correctamente."
                    : "El plan se actualizó correctamente.",
                "GymSystem",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimpiarCampos();

            await CargarPlanesAsync(
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
                "No fue posible guardar el plan:\n\n" +
                ex.Message,
                "Error de base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void BtnEliminar_Click(
        object? sender,
        EventArgs e)
    {
        if (idPlanSeleccionado == 0)
        {
            MessageBox.Show(
                "Seleccione un plan.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        DialogResult respuesta =
            MessageBox.Show(
                "¿Desea desactivar este plan?\n\n" +
                "El registro permanecerá en la base de datos.",
                "Desactivar plan",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (respuesta != DialogResult.Yes)
            return;

        try
        {
            await planService.DesactivarAsync(
                idPlanSeleccionado);

            MessageBox.Show(
                "Plan desactivado correctamente.",
                "GymSystem",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimpiarCampos();

            await CargarPlanesAsync(
                txtBuscar.Text.Trim());
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No fue posible actualizar el plan:\n\n" +
                ex.Message,
                "Error de base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void BtnRestaurar_Click(
        object? sender,
        EventArgs e)
    {
        if (!chkInactivos.Checked)
        {
            MessageBox.Show(
                "Active 'Mostrar inactivos' para restaurar un plan.",
                "Restaurar plan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }

        if (idPlanSeleccionado == 0)
        {
            MessageBox.Show(
                "Seleccione un plan inactivo.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        DialogResult respuesta =
            MessageBox.Show(
                "¿Desea restaurar este plan?",
                "Restaurar plan",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (respuesta != DialogResult.Yes)
            return;

        try
        {
            await planService.RestaurarAsync(
                idPlanSeleccionado);

            MessageBox.Show(
                "Plan restaurado correctamente.",
                "GymSystem",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimpiarCampos();

            await CargarPlanesAsync(
                txtBuscar.Text.Trim());
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No fue posible actualizar el plan:\n\n" +
                ex.Message,
                "Error de base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void LimpiarCampos()
    {
        idPlanSeleccionado = 0;

        txtNombre.Clear();
        txtDuracion.Clear();
        txtPrecio.Clear();

        dgvPlanes.ClearSelection();

        txtNombre.Focus();
    }
}
