using System.Data;
using GymSystem.Entidades;
using GymSystem.Negocio;

namespace GymSystem;

public partial class FrmClientes : Form
{
    private int idClienteSeleccionado = 0;
    private int _versionCargaClientes;
    private readonly ClienteService clienteService;

    public FrmClientes()
    {
        InitializeComponent();

        clienteService = new ClienteService();

        Load += FrmClientes_Load;
        dgvClientes.CellClick += DgvClientes_CellClick;
        txtBuscar.TextChanged += TxtBuscar_TextChanged;
        chkInactivos.CheckedChanged += ChkInactivos_CheckedChanged;
    }

    private async void FrmClientes_Load(
        object? sender,
        EventArgs e)
    {
        LimpiarCampos();
        await CargarClientesAsync();
    }

    private async Task CargarClientesAsync(
        string textoBuscar = "")
    {
        int versionSolicitud =
            Interlocked.Increment(ref _versionCargaClientes);

        try
        {
            List<Cliente> clientes =
                await clienteService.BuscarAsync(
                    textoBuscar,
                    chkInactivos.Checked);

            // No mostrar resultados de una búsqueda anterior.
            if (IsDisposed ||
                versionSolicitud != Volatile.Read(ref _versionCargaClientes))
            {
                return;
            }

            DataTable tabla =
                CrearTablaClientes(clientes);

            dgvClientes.DataSource = tabla;

            if (dgvClientes.Columns.Contains("IdCliente"))
            {
                dgvClientes.Columns["IdCliente"]!.Visible = false;
            }

            if (dgvClientes.Columns.Contains("FechaNacimiento"))
            {
                dgvClientes.Columns["FechaNacimiento"]!.HeaderText =
                    "Fecha nacimiento";
            }

            if (dgvClientes.Columns.Contains("NumeroCedula"))
            {
                dgvClientes.Columns["NumeroCedula"]!.HeaderText =
                    "Cédula";
            }

            if (dgvClientes.Columns.Contains("Estado"))
            {
                dgvClientes.Columns["Estado"]!.HeaderText =
                    "Estado";
            }

            dgvClientes.ClearSelection();
        }
        catch (Exception ex)
        {
            if (IsDisposed || versionSolicitud != Volatile.Read(ref _versionCargaClientes)) return;
            MessageBox.Show(
                "No fue posible cargar los clientes:\n\n" +
                ex.Message,
                "Error de base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private static DataTable CrearTablaClientes(
        List<Cliente> clientes)
    {
        DataTable tabla = new DataTable();

        tabla.Columns.Add(
            "IdCliente",
            typeof(int));

        tabla.Columns.Add(
            "Nombre",
            typeof(string));

        tabla.Columns.Add(
            "NumeroCedula",
            typeof(string));

        tabla.Columns.Add(
            "Correo",
            typeof(string));

        tabla.Columns.Add(
            "Telefono",
            typeof(string));

        tabla.Columns.Add(
            "Direccion",
            typeof(string));

        tabla.Columns.Add(
            "FechaNacimiento",
            typeof(DateTime));

        tabla.Columns.Add(
            "Estado",
            typeof(string));

        foreach (Cliente cliente in clientes)
        {
            DataRow fila = tabla.NewRow();

            fila["IdCliente"] =
                cliente.IdCliente;

            fila["Nombre"] =
                cliente.Nombre;

            fila["NumeroCedula"] =
                cliente.NumeroCedula;

            fila["Correo"] =
                cliente.Correo;

            fila["Telefono"] =
                cliente.Telefono ?? (object)DBNull.Value;

            fila["Direccion"] =
                cliente.Direccion ?? (object)DBNull.Value;

            fila["FechaNacimiento"] =
                cliente.FechaNacimiento.HasValue
                    ? cliente.FechaNacimiento.Value
                    : DBNull.Value;

            fila["Estado"] =
                cliente.Activo
                    ? "Activo"
                    : "Inactivo";

            tabla.Rows.Add(fila);
        }

        return tabla;
    }

    private async void TxtBuscar_TextChanged(
        object? sender,
        EventArgs e)
    {
        await CargarClientesAsync(
            txtBuscar.Text.Trim());
    }

    private async void ChkInactivos_CheckedChanged(
        object? sender,
        EventArgs e)
    {
        LimpiarCampos();

        await CargarClientesAsync(
            txtBuscar.Text.Trim());
    }

    private void DgvClientes_CellClick(
        object? sender,
        DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        DataGridViewRow fila =
            dgvClientes.Rows[e.RowIndex];

        if (fila.Cells["IdCliente"].Value == null)
            return;

        idClienteSeleccionado =
            Convert.ToInt32(
                fila.Cells["IdCliente"].Value);

        txtNombre.Text =
            fila.Cells["Nombre"].Value?.ToString() ?? "";

        txtCedula.Text =
            fila.Cells["NumeroCedula"].Value?.ToString() ?? "";

        txtCorreo.Text =
            fila.Cells["Correo"].Value?.ToString() ?? "";

        txtTelefono.Text =
            fila.Cells["Telefono"].Value?.ToString() ?? "";

        txtDireccion.Text =
            fila.Cells["Direccion"].Value?.ToString() ?? "";

        object? fecha =
            fila.Cells["FechaNacimiento"].Value;

        if (fecha != null &&
            fecha != DBNull.Value &&
            DateTime.TryParse(
                fecha.ToString(),
                out DateTime fechaNacimiento))
        {
            dtpFechaNacimiento.Value =
                fechaNacimiento;
        }
        else
        {
            dtpFechaNacimiento.Value =
                DateTime.Today;
        }
    }

    private bool ValidarCampos()
    {
        string nombre =
            txtNombre.Text.Trim();

        string cedula =
            txtCedula.Text.Trim();

        string correo =
            txtCorreo.Text.Trim();

        string telefono =
            txtTelefono.Text.Trim();

        if (string.IsNullOrWhiteSpace(nombre))
        {
            MostrarValidacion(
                "Ingrese el nombre completo.",
                txtNombre);

            return false;
        }

        if (nombre.Length < 3)
        {
            MostrarValidacion(
                "El nombre debe tener al menos 3 caracteres.",
                txtNombre);

            return false;
        }

        if (nombre.Length > 100)
        {
            MostrarValidacion(
                "El nombre no puede superar los 100 caracteres.",
                txtNombre);

            return false;
        }

        foreach (char caracter in nombre)
        {
            if (!char.IsLetter(caracter) &&
                caracter != ' ')
            {
                MostrarValidacion(
                    "El nombre solo puede contener letras y espacios.",
                    txtNombre);

                return false;
            }
        }

        if (string.IsNullOrWhiteSpace(cedula))
        {
            MostrarValidacion(
                "Ingrese el número de cédula.",
                txtCedula);

            return false;
        }

        if (cedula.Length > 20)
        {
            MostrarValidacion(
                "La cédula no puede superar los 20 caracteres.",
                txtCedula);

            return false;
        }

        if (string.IsNullOrWhiteSpace(correo))
        {
            MostrarValidacion(
                "Ingrese el correo electrónico.",
                txtCorreo);

            return false;
        }

        if (correo.Length > 100)
        {
            MostrarValidacion(
                "El correo no puede superar los 100 caracteres.",
                txtCorreo);

            return false;
        }

        if (!EsCorreoValido(correo))
        {
            MostrarValidacion(
                "Ingrese un correo electrónico válido.",
                txtCorreo);

            return false;
        }

        if (!string.IsNullOrWhiteSpace(telefono))
        {
            if (telefono.Length > 20)
            {
                MostrarValidacion(
                    "El teléfono no puede superar los 20 caracteres.",
                    txtTelefono);

                return false;
            }

            foreach (char caracter in telefono)
            {
                if (!char.IsDigit(caracter))
                {
                    MostrarValidacion(
                        "El teléfono solo puede contener números.",
                        txtTelefono);

                    return false;
                }
            }
        }

        if (dtpFechaNacimiento.Value.Date >
            DateTime.Today)
        {
            MostrarValidacion(
                "La fecha de nacimiento no puede ser futura.",
                dtpFechaNacimiento);

            return false;
        }

        return true;
    }

    private bool EsCorreoValido(
        string correo)
    {
        int posicionArroba =
            correo.IndexOf('@');

        if (posicionArroba <= 0)
            return false;

        if (posicionArroba >=
            correo.Length - 1)
        {
            return false;
        }

        if (correo.IndexOf(
                '@',
                posicionArroba + 1) != -1)
        {
            return false;
        }

        if (!correo.Contains('.'))
            return false;

        if (correo.Contains(' '))
            return false;

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
        if (!ValidarCampos())
            return;

        Cliente cliente = new Cliente
        {
            IdCliente =
                idClienteSeleccionado,

            Nombre =
                txtNombre.Text.Trim(),

            NumeroCedula =
                txtCedula.Text.Trim(),

            Correo =
                txtCorreo.Text.Trim(),

            Telefono =
                string.IsNullOrWhiteSpace(
                    txtTelefono.Text)
                    ? null
                    : txtTelefono.Text.Trim(),

            Direccion =
                string.IsNullOrWhiteSpace(
                    txtDireccion.Text)
                    ? null
                    : txtDireccion.Text.Trim(),

            FechaNacimiento =
                dtpFechaNacimiento.Value.Date
        };

        try
        {
            await clienteService.GuardarAsync(cliente);

            MessageBox.Show(
                idClienteSeleccionado == 0
                    ? "Cliente registrado correctamente."
                    : "Cliente actualizado correctamente.",
                "GymSystem",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimpiarCampos();

            await CargarClientesAsync(
                txtBuscar.Text.Trim());
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Registro duplicado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
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
                "No fue posible guardar el cliente:\n\n" +
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
        if (idClienteSeleccionado == 0)
        {
            MessageBox.Show(
                "Seleccione un cliente.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        DialogResult respuesta =
            MessageBox.Show(
                "¿Desea desactivar este cliente?\n\n" +
                "El registro permanecerá en la base de datos.",
                "Desactivar cliente",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (respuesta != DialogResult.Yes)
            return;

        try
        {
            await clienteService.DesactivarAsync(
                idClienteSeleccionado);

            MessageBox.Show(
                "Cliente desactivado correctamente.",
                "GymSystem",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimpiarCampos();

            await CargarClientesAsync(
                txtBuscar.Text.Trim());
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No fue posible desactivar el cliente:\n\n" +
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
                "Active 'Mostrar inactivos' para restaurar un cliente.",
                "Restaurar cliente",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }

        if (idClienteSeleccionado == 0)
        {
            MessageBox.Show(
                "Seleccione un cliente inactivo.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        DialogResult respuesta =
            MessageBox.Show(
                "¿Desea restaurar este cliente?",
                "Restaurar cliente",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (respuesta != DialogResult.Yes)
            return;

        try
        {
            await clienteService.RestaurarAsync(
                idClienteSeleccionado);

            MessageBox.Show(
                "Cliente restaurado correctamente.",
                "GymSystem",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimpiarCampos();

            await CargarClientesAsync(
                txtBuscar.Text.Trim());
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No fue posible restaurar el cliente:\n\n" +
                ex.Message,
                "Error de base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void LimpiarCampos()
    {
        idClienteSeleccionado = 0;

        txtNombre.Clear();
        txtCedula.Clear();
        txtCorreo.Clear();
        txtTelefono.Clear();
        txtDireccion.Clear();

        dtpFechaNacimiento.Value =
            DateTime.Today;

        dgvClientes.ClearSelection();

        txtNombre.Focus();
    }
}
