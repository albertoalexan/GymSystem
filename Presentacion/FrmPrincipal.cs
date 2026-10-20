using System.Drawing;
using GymSystem.Entidades;
using GymSystem.Negocio;

namespace GymSystem;

public partial class FrmPrincipal : Form
{
    private readonly string nombreUsuario;
    private readonly string rolUsuario;
    private readonly ResumenService resumenService;

    // Formulario que se muestra actualmente dentro del área central.
    private Form? formularioActual;

    public FrmPrincipal(
        string nombreUsuario,
        string rolUsuario)
    {
        InitializeComponent();

        this.nombreUsuario = nombreUsuario;
        this.rolUsuario = rolUsuario;

        resumenService = new ResumenService();

        lblUsuario.Text = nombreUsuario;

        lblRol.Text = rolUsuario;

        lblAvatar.Text =
            string.IsNullOrWhiteSpace(nombreUsuario)
                ? "GS"
                : nombreUsuario.Trim()[0].ToString().ToUpperInvariant();

        lblBienvenida.Text =
            string.IsNullOrWhiteSpace(nombreUsuario)
                ? "¡Bienvenido!"
                : $"¡Bienvenido, {nombreUsuario}!";

        lblFechaInicio.Text = DateTime.Now.ToString(
            "dddd, dd 'de' MMMM 'de' yyyy",
            new System.Globalization.CultureInfo("es-NI"));

        panelContenido.Resize += PanelContenido_Resize;

        Load += FrmPrincipal_Load;

        // Garantiza que el botón Inicio tenga su evento.
        btnInicio.Click -= BtnInicio_Click;
        btnInicio.Click += BtnInicio_Click;
    }

    private async void FrmPrincipal_Load(
        object? sender,
        EventArgs e)
    {
        AplicarPermisos();
        await MostrarInicioAsync();
    }

    private void AplicarPermisos()
    {
        bool esAdministrador =
            rolUsuario.Equals(
                "Administrador",
                StringComparison.OrdinalIgnoreCase);

        btnPlanes.Enabled = esAdministrador;
        btnUsuarios.Enabled = esAdministrador;
    }

    // =========================================================
    // MOSTRAR EL PANEL PRINCIPAL
    // =========================================================

    private async Task MostrarInicioAsync()
    {
        CerrarFormularioActual();

        panelContenido.SuspendLayout();

        panelContenido.Controls.Clear();

        // Recuperamos las tarjetas del panel principal.
        panelContenido.Controls.AddRange(
            new Control[]
            {
                panelBienvenida,
                lblSeccionResumen,
                tarjetaClientes,
                tarjetaPlanes,
                tarjetaInscripciones,
                tarjetaPagos
            });

        lblTitulo.Text = "Panel principal";

        lblSubtituloSuperior.Text =
            "Resumen y actividad general del gimnasio";

        MarcarBotonActivo(btnInicio);

        panelContenido.ResumeLayout(true);

        AjustarDistribucionInicio();

        await CargarResumenAsync();
    }

    private void PanelContenido_Resize(
        object? sender,
        EventArgs e)
    {
        AjustarDistribucionInicio();
    }

    private void AjustarDistribucionInicio()
    {
        if (panelContenido == null ||
            panelBienvenida == null ||
            !ReferenceEquals(
                panelBienvenida.Parent,
                panelContenido))
        {
            return;
        }

        int anchoPanel = panelContenido.ClientSize.Width;

        if (anchoPanel <= 0)
        {
            return;
        }

        // Ajustar el panel de bienvenida al espacio disponible.

        int anchoBanner = Math.Max(320, anchoPanel - 56);

        panelBienvenida.Location = new Point(28, 24);

        panelBienvenida.Size = new Size(
            anchoBanner,
            132);

        // Evitar que el texto de bienvenida invada la fecha.

        int anchoTexto = Math.Max(
            250,
            Math.Min(640, anchoBanner - 320));

        lblBienvenida.Size = new Size(
            anchoTexto,
            39);

        lblTextoBienvenida.Size = new Size(
            anchoTexto,
            38);

        lblFechaInicio.Location = new Point(
            Math.Max(
                15,
                anchoBanner - lblFechaInicio.Width - 24),
            83);

        // Colocar las cuatro tarjetas de manera uniforme.

        lblSeccionResumen.Location = new Point(
            30,
            177);

        Panel[] tarjetas =
        {
            tarjetaClientes,
            tarjetaPlanes,
            tarjetaInscripciones,
            tarjetaPagos
        };

        int separacion = 16;

        int anchoDisponible = Math.Max(
            680,
            anchoPanel - 56);

        int anchoTarjeta = Math.Max(
            170,
            (anchoDisponible - (separacion * 3)) / 4);

        int posicionX = 28;

        foreach (Panel tarjeta in tarjetas)
        {
            tarjeta.Location = new Point(
                posicionX,
                218);

            tarjeta.Size = new Size(
                anchoTarjeta,
                166);

            posicionX += anchoTarjeta + separacion;
        }
    }

    private async Task CargarResumenAsync()
    {
        try
        {
            ResumenSistema resumen =
                await resumenService.ObtenerResumenAsync();

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
                "No fue posible cargar la información del inicio:\n\n"
                + ex.Message,
                "Error de base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // =========================================================
    // NAVEGACIÓN INTERNA
    // =========================================================

    private void AbrirModulo(
        Form formulario,
        string titulo,
        Button botonActivo)
    {
        // Si ya estamos en ese módulo, no lo reiniciamos.
        if (formularioActual != null &&
            formularioActual.GetType() == formulario.GetType())
        {
            formulario.Dispose();
            return;
        }

        CerrarFormularioActual();

        panelContenido.SuspendLayout();

        panelContenido.Controls.Clear();

        // Convertimos el formulario en contenido integrado.
        formulario.TopLevel = false;

        formulario.FormBorderStyle =
            FormBorderStyle.None;

        formulario.Dock = DockStyle.Fill;

        formulario.Margin = Padding.Empty;

        formulario.ShowInTaskbar = false;

        formulario.StartPosition =
            FormStartPosition.Manual;

        formularioActual = formulario;

        panelContenido.Controls.Add(formulario);

        formulario.BringToFront();

        lblTitulo.Text = titulo;

        MarcarBotonActivo(botonActivo);

        panelContenido.ResumeLayout(true);

        formulario.Show();
    }

    private void CerrarFormularioActual()
    {
        if (formularioActual == null)
            return;

        Form formulario = formularioActual;

        formularioActual = null;

        panelContenido.Controls.Remove(formulario);

        formulario.Close();

        formulario.Dispose();
    }

    // =========================================================
    // ESTILO DE NAVEGACIÓN
    // =========================================================

    private void MarcarBotonActivo(Button botonActivo)
    {
        Button[] botones =
        {
            btnInicio,
            btnClientes,
            btnPlanes,
            btnInscripciones,
            btnPagos,
            btnReportes,
            btnUsuarios
        };

        foreach (Button boton in botones)
        {
            boton.FlatStyle = FlatStyle.Flat;

            boton.FlatAppearance.BorderSize = 0;

            boton.BackColor =
                Color.FromArgb(31, 41, 55);

            boton.ForeColor = Color.WhiteSmoke;
        }

        botonActivo.BackColor =
            Color.FromArgb(37, 99, 235);

        botonActivo.ForeColor = Color.White;
    }

    // =========================================================
    // EVENTOS DEL MENÚ
    // =========================================================

    private async void BtnInicio_Click(
        object? sender,
        EventArgs e)
    {
        await MostrarInicioAsync();
    }

    private void BtnClientes_Click(
        object? sender,
        EventArgs e)
    {
        AbrirModulo(
            new FrmClientes(),
            "Clientes",
            btnClientes);
    }

    private void BtnPlanes_Click(
        object? sender,
        EventArgs e)
    {
        AbrirModulo(
            new FrmPlanes(),
            "Planes",
            btnPlanes);
    }

    private void BtnInscripciones_Click(
        object? sender,
        EventArgs e)
    {
        AbrirModulo(
            new FrmInscripciones(),
            "Inscripciones",
            btnInscripciones);
    }

    private void BtnPagos_Click(
        object? sender,
        EventArgs e)
    {
        AbrirModulo(
            new FrmPagos(),
            "Pagos",
            btnPagos);
    }

    private void BtnReportes_Click(
        object? sender,
        EventArgs e)
    {
        AbrirModulo(
            new FrmReportes(),
            "Reportes",
            btnReportes);
    }
    private void BtnUsuarios_Click(
        object? sender,
        EventArgs e)
    {
        AbrirModulo(
            new FrmUsuarios(),
            "Usuarios",
            btnUsuarios);
    }

    // =========================================================
    // CERRAR SESIÓN
    // =========================================================

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

        if (respuesta == DialogResult.Yes)
        {
            Close();
        }
    }
}
