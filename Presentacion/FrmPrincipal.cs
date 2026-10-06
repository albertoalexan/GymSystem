using GymSystem.Entidades;
using GymSystem.Negocio;

namespace GymSystem;

public partial class FrmPrincipal : Form
{
    private readonly string nombreUsuario;
    private readonly string rolUsuario;
    private readonly ResumenService resumenService;

    public FrmPrincipal(
        string nombreUsuario,
        string rolUsuario)
    {
        InitializeComponent();

        this.nombreUsuario = nombreUsuario;
        this.rolUsuario = rolUsuario;

        resumenService =
            new ResumenService();

        lblUsuario.Text =
            nombreUsuario;

        Load += FrmPrincipal_Load;
    }

    private void AplicarPermisos()
    {
        bool esAdministrador =
            rolUsuario.Equals(
                "Administrador",
                StringComparison.OrdinalIgnoreCase);

        btnPlanes.Enabled =
            esAdministrador;

        btnUsuarios.Enabled =
            esAdministrador;
    }

    private void FrmPrincipal_Load(
        object? sender,
        EventArgs e)
    {
        CargarResumen();
        AplicarPermisos();
    }

    private void CargarResumen()
    {
        try
        {
            ResumenSistema resumen =
                resumenService.ObtenerResumen();

            lblCantidadClientes.Text =
                resumen.CantidadClientes.ToString();

            lblCantidadPlanes.Text =
                resumen.CantidadPlanes.ToString();

            lblCantidadInscripciones.Text =
                resumen.CantidadInscripciones.ToString();

            lblCantidadPagos.Text =
                resumen.CantidadPagos.ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No fue posible cargar la información del inicio:\n\n" +
                ex.Message,
                "Error de base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void BtnClientes_Click(
        object? sender,
        EventArgs e)
    {
        using FrmClientes formulario =
            new FrmClientes();

        formulario.ShowDialog(this);

        CargarResumen();
    }

    private void BtnPlanes_Click(
        object? sender,
        EventArgs e)
    {
        using FrmPlanes formulario =
            new FrmPlanes();

        formulario.ShowDialog(this);

        CargarResumen();
    }

    private void BtnInscripciones_Click(
        object? sender,
        EventArgs e)
    {
        using FrmInscripciones formulario =
            new FrmInscripciones();

        formulario.ShowDialog(this);

        CargarResumen();
    }

    private void BtnPagos_Click(
        object? sender,
        EventArgs e)
    {
        using FrmPagos formulario =
            new FrmPagos();

        formulario.ShowDialog(this);

        CargarResumen();
    }

    private void BtnUsuarios_Click(
        object? sender,
        EventArgs e)
    {
        using FrmUsuarios formulario =
            new FrmUsuarios();

        formulario.ShowDialog(this);
    }

    private void BtnCerrarSesion_Click(
        object? sender,
        EventArgs e)
    {
        DialogResult respuesta =
            MessageBox.Show(
                "¿Desea cerrar la sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (respuesta ==
            DialogResult.Yes)
        {
            Close();
        }
    }
}
