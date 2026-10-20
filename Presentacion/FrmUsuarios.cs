using System.Data;
using GymSystem.Entidades;
using GymSystem.Negocio;

namespace GymSystem;

public partial class FrmUsuarios : Form
{
    private int idUsuarioSeleccionado = 0;
    private readonly UsuarioService usuarioService;

    public FrmUsuarios()
    {
        InitializeComponent();

        usuarioService = new UsuarioService();

        Load += FrmUsuarios_Load;
        txtBuscar.TextChanged += TxtBuscar_TextChanged;
        chkInactivos.CheckedChanged += ChkInactivos_CheckedChanged;
        dgvUsuarios.CellClick += DgvUsuarios_CellClick;
    }

    private async void FrmUsuarios_Load(
        object? sender,
        EventArgs e)
    {
        await CargarUsuariosAsync();
    }

    private async Task CargarUsuariosAsync(
        string textoBuscar = "")
    {
        try
        {
            List<Usuario> usuarios =
                await usuarioService.BuscarAsync(
                    textoBuscar,
                    chkInactivos.Checked);

            DataTable tabla =
                CrearTablaUsuarios(usuarios);

            dgvUsuarios.DataSource = tabla;

            if (dgvUsuarios.Columns.Contains("IdUsuario"))
            {
                dgvUsuarios.Columns[
                    "IdUsuario"]!.Visible = false;
            }

            if (dgvUsuarios.Columns.Contains("Estado"))
            {
                dgvUsuarios.Columns[
                    "Estado"]!.HeaderText = "Estado";
            }

            dgvUsuarios.ClearSelection();
            idUsuarioSeleccionado = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No fue posible cargar los usuarios:\n\n" +
                ex.Message,
                "Error de base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private static DataTable CrearTablaUsuarios(
        List<Usuario> usuarios)
    {
        DataTable tabla =
            new DataTable();

        tabla.Columns.Add(
            "IdUsuario",
            typeof(int));

        tabla.Columns.Add(
            "Nombre",
            typeof(string));

        tabla.Columns.Add(
            "Usuario",
            typeof(string));

        tabla.Columns.Add(
            "Estado",
            typeof(string));

        foreach (Usuario usuario in usuarios)
        {
            DataRow fila =
                tabla.NewRow();

            fila["IdUsuario"] =
                usuario.IdUsuario;

            fila["Nombre"] =
                usuario.Nombre;

            fila["Usuario"] =
                usuario.UsuarioNombre;

            fila["Estado"] =
                usuario.Activo
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
        await CargarUsuariosAsync(
            txtBuscar.Text.Trim());
    }

    private async void ChkInactivos_CheckedChanged(
        object? sender,
        EventArgs e)
    {
        await CargarUsuariosAsync(
            txtBuscar.Text.Trim());
    }

    private void DgvUsuarios_CellClick(
        object? sender,
        DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        DataGridViewRow fila =
            dgvUsuarios.Rows[e.RowIndex];

        if (fila.Cells["IdUsuario"].Value == null)
            return;

        idUsuarioSeleccionado =
            Convert.ToInt32(
                fila.Cells["IdUsuario"].Value);
    }

    private async void BtnDesactivar_Click(
        object? sender,
        EventArgs e)
    {
        if (idUsuarioSeleccionado == 0)
        {
            MessageBox.Show(
                "Seleccione un usuario.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        DialogResult respuesta =
            MessageBox.Show(
                "¿Desea desactivar este usuario?",
                "Desactivar usuario",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (respuesta != DialogResult.Yes)
            return;

        try
        {
            await usuarioService.DesactivarAsync(
                idUsuarioSeleccionado);

            MessageBox.Show(
                "Usuario desactivado correctamente.",
                "GymSystem",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await CargarUsuariosAsync(
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
                "No fue posible actualizar el usuario:\n\n" +
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
                "Active 'Mostrar inactivos' para restaurar un usuario.",
                "Restaurar usuario",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }

        if (idUsuarioSeleccionado == 0)
        {
            MessageBox.Show(
                "Seleccione un usuario inactivo.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        DialogResult respuesta =
            MessageBox.Show(
                "¿Desea restaurar este usuario?",
                "Restaurar usuario",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (respuesta != DialogResult.Yes)
            return;

        try
        {
            await usuarioService.RestaurarAsync(
                idUsuarioSeleccionado);

            MessageBox.Show(
                "Usuario restaurado correctamente.",
                "GymSystem",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await CargarUsuariosAsync(
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
                "No fue posible actualizar el usuario:\n\n" +
                ex.Message,
                "Error de base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void BtnCrearUsuario_Click(
        object? sender,
        EventArgs e)
    {
        using FrmCrearCuenta formularioCrearCuenta =
            new FrmCrearCuenta();

        formularioCrearCuenta.ShowDialog(this);

        await CargarUsuariosAsync(
            txtBuscar.Text.Trim());
    }
}
