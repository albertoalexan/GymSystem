namespace GymSystem;

partial class FrmPrincipal
{
    private System.ComponentModel.IContainer components = null!;

    private Panel panelMenu = null!;
    private Panel panelSuperior = null!;
    private Panel panelContenido = null!;

    private Label lblLogo = null!;
    private Label lblLogoSigla = null!;
    private Label lblMarcaDescripcion = null!;

    private Label lblUsuario = null!;
    private Label lblRol = null!;
    private Label lblAvatar = null!;
    private Label lblTitulo = null!;
    private Label lblSubtituloSuperior = null!;

    private Panel panelAvatar = null!;

    private Button btnInicio = null!;
    private Button btnClientes = null!;
    private Button btnPlanes = null!;
    private Button btnInscripciones = null!;
    private Button btnPagos = null!;
    private Button btnReportes = null!;
    private Button btnUsuarios = null!;
    private Button btnCerrarSesion = null!;

    private Panel tarjetaClientes = null!;
    private Panel tarjetaPlanes = null!;
    private Panel tarjetaInscripciones = null!;
    private Panel tarjetaPagos = null!;

    private Label lblCantidadClientes = null!;
    private Label lblCantidadPlanes = null!;
    private Label lblCantidadInscripciones = null!;
    private Label lblCantidadPagos = null!;

    private Panel panelBienvenida = null!;
    private Panel panelAcentoBienvenida = null!;

    private Label lblBienvenida = null!;
    private Label lblTextoBienvenida = null!;
    private Label lblFechaInicio = null!;
    private Label lblSeccionResumen = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        panelMenu = new Panel();
        panelSuperior = new Panel();
        panelContenido = new Panel();

        lblLogo = new Label();
        lblLogoSigla = new Label();
        lblMarcaDescripcion = new Label();

        lblUsuario = new Label();
        lblRol = new Label();
        lblAvatar = new Label();
        lblTitulo = new Label();
        lblSubtituloSuperior = new Label();

        panelAvatar = new Panel();

        btnInicio = new Button();
        btnClientes = new Button();
        btnPlanes = new Button();
        btnInscripciones = new Button();
        btnPagos = new Button();
        btnReportes = new Button();
        btnUsuarios = new Button();
        btnCerrarSesion = new Button();

        tarjetaClientes = new Panel();
        tarjetaPlanes = new Panel();
        tarjetaInscripciones = new Panel();
        tarjetaPagos = new Panel();

        lblCantidadClientes = new Label();
        lblCantidadPlanes = new Label();
        lblCantidadInscripciones = new Label();
        lblCantidadPagos = new Label();

        panelBienvenida = new Panel();
        panelAcentoBienvenida = new Panel();

        lblBienvenida = new Label();
        lblTextoBienvenida = new Label();
        lblFechaInicio = new Label();
        lblSeccionResumen = new Label();

        SuspendLayout();

        // =====================================================
        // FORMULARIO
        // =====================================================

        AutoScaleMode = AutoScaleMode.Font;

        BackColor = Color.FromArgb(246, 248, 252);

        ClientSize = new Size(1360, 800);

        MinimumSize = new Size(1100, 680);

        StartPosition = FormStartPosition.CenterScreen;

        WindowState = FormWindowState.Maximized;

        Text = "GymSystem | Panel de administración";

        Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Regular);

        // =====================================================
        // BARRA LATERAL
        // =====================================================

        panelMenu.BackColor = Color.FromArgb(15, 23, 42);

        panelMenu.Dock = DockStyle.Left;

        panelMenu.Width = 252;

        // Insignia GS

        lblLogoSigla.BackColor = Color.FromArgb(22, 163, 74);

        lblLogoSigla.Font = new Font(
            "Segoe UI",
            15F,
            FontStyle.Bold);

        lblLogoSigla.ForeColor = Color.White;

        lblLogoSigla.Location = new Point(24, 27);

        lblLogoSigla.Size = new Size(46, 46);

        lblLogoSigla.Text = "GS";

        lblLogoSigla.TextAlign = ContentAlignment.MiddleCenter;

        // Nombre

        lblLogo.AutoSize = false;

        lblLogo.Font = new Font(
            "Segoe UI",
            17F,
            FontStyle.Bold);

        lblLogo.ForeColor = Color.White;

        lblLogo.Location = new Point(81, 28);

        lblLogo.Size = new Size(155, 29);

        lblLogo.Text = "GYMSYSTEM";

        lblLogo.TextAlign = ContentAlignment.MiddleLeft;

        // Descripción de la marca

        lblMarcaDescripcion.AutoSize = false;

        lblMarcaDescripcion.Font = new Font(
            "Segoe UI",
            8F,
            FontStyle.Regular);

        lblMarcaDescripcion.ForeColor = Color.FromArgb(148, 163, 184);

        lblMarcaDescripcion.Location = new Point(83, 55);

        lblMarcaDescripcion.Size = new Size(155, 19);

        lblMarcaDescripcion.Text = "GESTIÓN DE GIMNASIO";

        // Línea decorativa

        Panel panelLineaLogo = new Panel();

        panelLineaLogo.BackColor = Color.FromArgb(34, 197, 94);

        panelLineaLogo.Location = new Point(24, 91);

        panelLineaLogo.Size = new Size(204, 3);

        // Título del menú

        Label lblEtiquetaMenu = new Label();

        lblEtiquetaMenu.AutoSize = false;

        lblEtiquetaMenu.Font = new Font(
            "Segoe UI",
            8F,
            FontStyle.Bold);

        lblEtiquetaMenu.ForeColor = Color.FromArgb(148, 163, 184);

        lblEtiquetaMenu.Location = new Point(26, 113);

        lblEtiquetaMenu.Size = new Size(200, 22);

        lblEtiquetaMenu.Text = "MENÚ PRINCIPAL";

        // =====================================================
        // NAVEGACIÓN
        // =====================================================

        ConfigurarBotonMenu(
            btnInicio,
            "⌂    Inicio",
            151);

        ConfigurarBotonMenu(
            btnClientes,
            "●    Clientes",
            203);

        ConfigurarBotonMenu(
            btnPlanes,
            "▦    Planes",
            255);

        ConfigurarBotonMenu(
            btnInscripciones,
            "▣    Inscripciones",
            307);

        ConfigurarBotonMenu(
            btnPagos,
            "$    Pagos",
            359);

        ConfigurarBotonMenu(
            btnReportes,
            "▤    Reportes",
            411);

        ConfigurarBotonMenu(
            btnUsuarios,
            "⚙    Usuarios",
            463);

        btnClientes.Click += BtnClientes_Click;

        btnPlanes.Click += BtnPlanes_Click;

        btnInscripciones.Click += BtnInscripciones_Click;

        btnPagos.Click += BtnPagos_Click;

        btnReportes.Click += BtnReportes_Click;

        btnUsuarios.Click += BtnUsuarios_Click;

        // =====================================================
        // PIE DEL MENÚ
        // =====================================================

        Panel panelSeparadorPie = new Panel();

        panelSeparadorPie.BackColor = Color.FromArgb(51, 65, 85);

        panelSeparadorPie.Anchor =
            AnchorStyles.Left |
            AnchorStyles.Right |
            AnchorStyles.Bottom;

        panelSeparadorPie.Location = new Point(22, 0);

        panelSeparadorPie.Size = new Size(208, 1);

        btnCerrarSesion.BackColor = Color.FromArgb(127, 29, 29);

        btnCerrarSesion.FlatAppearance.BorderSize = 0;

        btnCerrarSesion.FlatAppearance.MouseOverBackColor =
            Color.FromArgb(153, 27, 27);

        btnCerrarSesion.FlatAppearance.MouseDownBackColor =
            Color.FromArgb(185, 28, 28);

        btnCerrarSesion.FlatStyle = FlatStyle.Flat;

        btnCerrarSesion.Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Bold);

        btnCerrarSesion.ForeColor = Color.White;

        btnCerrarSesion.Location = new Point(20, 0);

        btnCerrarSesion.Size = new Size(212, 42);

        btnCerrarSesion.Anchor =
            AnchorStyles.Left |
            AnchorStyles.Right |
            AnchorStyles.Bottom;

        btnCerrarSesion.Text = "Cerrar sesión";

        btnCerrarSesion.UseVisualStyleBackColor = false;

        btnCerrarSesion.Cursor = Cursors.Hand;

        btnCerrarSesion.Click += BtnCerrarSesion_Click;

        // Agregar controles al menú

        panelMenu.Controls.Add(lblLogoSigla);
        panelMenu.Controls.Add(lblLogo);
        panelMenu.Controls.Add(lblMarcaDescripcion);
        panelMenu.Controls.Add(panelLineaLogo);
        panelMenu.Controls.Add(lblEtiquetaMenu);

        panelMenu.Controls.Add(btnInicio);
        panelMenu.Controls.Add(btnClientes);
        panelMenu.Controls.Add(btnPlanes);
        panelMenu.Controls.Add(btnInscripciones);
        panelMenu.Controls.Add(btnPagos);
        panelMenu.Controls.Add(btnReportes);
        panelMenu.Controls.Add(btnUsuarios);

        panelMenu.Controls.Add(panelSeparadorPie);
        panelMenu.Controls.Add(btnCerrarSesion);

        // =====================================================
        // BARRA SUPERIOR
        // =====================================================

        panelSuperior.BackColor = Color.White;

        panelSuperior.Dock = DockStyle.Top;

        panelSuperior.Height = 82;

        // Título del módulo

        lblTitulo.AutoSize = false;

        lblTitulo.Font = new Font(
            "Segoe UI",
            18F,
            FontStyle.Bold);

        lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);

        lblTitulo.Location = new Point(280, 11);

        lblTitulo.Size = new Size(530, 35);

        lblTitulo.Text = "Panel principal";

        // Subtítulo del encabezado

        lblSubtituloSuperior.AutoSize = false;

        lblSubtituloSuperior.Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Regular);

        lblSubtituloSuperior.ForeColor = Color.FromArgb(100, 116, 139);

        lblSubtituloSuperior.Location = new Point(282, 46);

        lblSubtituloSuperior.Size = new Size(500, 22);

        lblSubtituloSuperior.Text = "Administración del gimnasio";

        // Avatar

        panelAvatar.BackColor = Color.FromArgb(22, 163, 74);

        panelAvatar.Anchor =
            AnchorStyles.Top |
            AnchorStyles.Right;

        panelAvatar.Location = new Point(992, 18);

        panelAvatar.Size = new Size(44, 44);

        lblAvatar.Dock = DockStyle.Fill;

        lblAvatar.Font = new Font(
            "Segoe UI",
            14F,
            FontStyle.Bold);

        lblAvatar.ForeColor = Color.White;

        lblAvatar.Text = "GS";

        lblAvatar.TextAlign = ContentAlignment.MiddleCenter;

        panelAvatar.Controls.Add(lblAvatar);

        // Nombre del usuario

        lblUsuario.AutoSize = false;

        lblUsuario.Anchor =
            AnchorStyles.Top |
            AnchorStyles.Right;

        lblUsuario.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Bold);

        lblUsuario.ForeColor = Color.FromArgb(15, 23, 42);

        lblUsuario.Location = new Point(1048, 16);

        lblUsuario.Size = new Size(235, 24);

        lblUsuario.Text = "Usuario";

        lblUsuario.TextAlign = ContentAlignment.MiddleLeft;

        lblUsuario.AutoEllipsis = true;

        // Rol del usuario

        lblRol.AutoSize = false;

        lblRol.Anchor =
            AnchorStyles.Top |
            AnchorStyles.Right;

        lblRol.Font = new Font(
            "Segoe UI",
            8.5F,
            FontStyle.Regular);

        lblRol.ForeColor = Color.FromArgb(100, 116, 139);

        lblRol.Location = new Point(1048, 42);

        lblRol.Size = new Size(235, 20);

        lblRol.Text = "Usuario";

        lblRol.TextAlign = ContentAlignment.MiddleLeft;

        panelSuperior.Controls.Add(lblTitulo);
        panelSuperior.Controls.Add(lblSubtituloSuperior);
        panelSuperior.Controls.Add(panelAvatar);
        panelSuperior.Controls.Add(lblUsuario);
        panelSuperior.Controls.Add(lblRol);

        // =====================================================
        // ÁREA DE CONTENIDO
        // =====================================================

        panelContenido.BackColor = Color.FromArgb(246, 248, 252);

        panelContenido.Dock = DockStyle.Fill;

        panelContenido.Padding = new Padding(28, 24, 28, 24);

        panelContenido.AutoScroll = true;

        // =====================================================
        // PANEL DE BIENVENIDA
        // =====================================================

        panelBienvenida.BackColor = Color.FromArgb(30, 41, 59);

        panelBienvenida.Location = new Point(28, 24);

        panelBienvenida.Size = new Size(900, 132);

        panelBienvenida.BorderStyle = BorderStyle.None;

        // Barra de acento

        panelAcentoBienvenida.BackColor = Color.FromArgb(34, 197, 94);

        panelAcentoBienvenida.Dock = DockStyle.Left;

        panelAcentoBienvenida.Width = 6;

        // Saludo

        lblBienvenida.AutoSize = false;

        lblBienvenida.Font = new Font(
            "Segoe UI",
            21F,
            FontStyle.Bold);

        lblBienvenida.ForeColor = Color.White;

        lblBienvenida.Location = new Point(27, 20);

        lblBienvenida.Size = new Size(570, 39);

        lblBienvenida.Text = "¡Bienvenido!";

        lblBienvenida.AutoEllipsis = true;

        // Descripción

        lblTextoBienvenida.AutoSize = false;

        lblTextoBienvenida.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Regular);

        lblTextoBienvenida.ForeColor = Color.FromArgb(203, 213, 225);

        lblTextoBienvenida.Location = new Point(29, 66);

        lblTextoBienvenida.Size = new Size(570, 38);

        lblTextoBienvenida.Text =
            "Este es el resumen de actividad de tu gimnasio.";

        // Fecha

        lblFechaInicio.AutoSize = false;

        lblFechaInicio.Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Bold);

        lblFechaInicio.ForeColor = Color.FromArgb(134, 239, 172);

        lblFechaInicio.Location = new Point(650, 83);

        lblFechaInicio.Size = new Size(225, 25);

        lblFechaInicio.Text = "Fecha actual";

        lblFechaInicio.TextAlign = ContentAlignment.MiddleRight;

        // Agregar etiquetas al banner

        panelBienvenida.Controls.Add(lblBienvenida);
        panelBienvenida.Controls.Add(lblTextoBienvenida);
        panelBienvenida.Controls.Add(lblFechaInicio);
        panelBienvenida.Controls.Add(panelAcentoBienvenida);

        // =====================================================
        // ENCABEZADO DE LAS TARJETAS
        // =====================================================

        lblSeccionResumen.AutoSize = false;

        lblSeccionResumen.Font = new Font(
            "Segoe UI",
            11F,
            FontStyle.Bold);

        lblSeccionResumen.ForeColor = Color.FromArgb(51, 65, 85);

        lblSeccionResumen.Location = new Point(30, 177);

        lblSeccionResumen.Size = new Size(350, 25);

        lblSeccionResumen.Text = "RESUMEN GENERAL";

        // =====================================================
        // TARJETA DE CLIENTES
        // =====================================================

        CrearTarjeta(
            tarjetaClientes,
            "Clientes",
            lblCantidadClientes,
            28,
            218);

        // =====================================================
        // TARJETA DE PLANES
        // =====================================================

        CrearTarjeta(
            tarjetaPlanes,
            "Planes",
            lblCantidadPlanes,
            252,
            218);

        // =====================================================
        // TARJETA DE INSCRIPCIONES
        // =====================================================

        CrearTarjeta(
            tarjetaInscripciones,
            "Inscripciones",
            lblCantidadInscripciones,
            476,
            218);

        // =====================================================
        // TARJETA DE PAGOS
        // =====================================================

        CrearTarjeta(
            tarjetaPagos,
            "Pagos",
            lblCantidadPagos,
            700,
            218);

        // Contenido del panel principal

        panelContenido.Controls.Add(panelBienvenida);
        panelContenido.Controls.Add(lblSeccionResumen);

        panelContenido.Controls.Add(tarjetaClientes);
        panelContenido.Controls.Add(tarjetaPlanes);
        panelContenido.Controls.Add(tarjetaInscripciones);
        panelContenido.Controls.Add(tarjetaPagos);

        // =====================================================
        // AGREGAR PANELES AL FORMULARIO
        // =====================================================

        Controls.Add(panelContenido);
        Controls.Add(panelSuperior);
        Controls.Add(panelMenu);

        ResumeLayout(false);
    }

    // =========================================================
    // ESTILO DE LOS BOTONES DEL MENÚ
    // =========================================================

    private void ConfigurarBotonMenu(
        Button boton,
        string texto,
        int posicionY)
    {
        boton.BackColor = Color.FromArgb(15, 23, 42);

        boton.FlatAppearance.BorderSize = 0;

        boton.FlatAppearance.MouseOverBackColor =
            Color.FromArgb(30, 41, 59);

        boton.FlatAppearance.MouseDownBackColor =
            Color.FromArgb(51, 65, 85);

        boton.FlatStyle = FlatStyle.Flat;

        boton.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Bold);

        boton.ForeColor = Color.FromArgb(226, 232, 240);

        boton.Location = new Point(18, posicionY);

        boton.Size = new Size(216, 43);

        boton.Text = texto;

        boton.TextAlign = ContentAlignment.MiddleLeft;

        boton.Padding = new Padding(15, 0, 0, 0);

        boton.UseVisualStyleBackColor = false;

        boton.Cursor = Cursors.Hand;
    }

    // =========================================================
    // CREAR TARJETAS DEL PANEL PRINCIPAL
    // =========================================================

    private void CrearTarjeta(
        Panel tarjeta,
        string titulo,
        Label cantidad,
        int posicionX,
        int posicionY)
    {
        tarjeta.BackColor = Color.White;

        tarjeta.BorderStyle = BorderStyle.FixedSingle;

        tarjeta.Location = new Point(posicionX, posicionY);

        tarjeta.Size = new Size(220, 166);

        Color colorAcento;

        string sigla;

        string descripcion;

        switch (titulo)
        {
            case "Clientes":
                colorAcento = Color.FromArgb(22, 163, 74);
                sigla = "CL";
                descripcion = "Personas registradas";
                break;

            case "Planes":
                colorAcento = Color.FromArgb(37, 99, 235);
                sigla = "PL";
                descripcion = "Planes disponibles";
                break;

            case "Inscripciones":
                colorAcento = Color.FromArgb(217, 119, 6);
                sigla = "IN";
                descripcion = "Membresías activas";
                break;

            default:
                colorAcento = Color.FromArgb(124, 58, 237);
                sigla = "PG";
                descripcion = "Pagos registrados";
                break;
        }

        // Línea superior

        Panel linea = new Panel();

        linea.BackColor = colorAcento;

        linea.Location = new Point(0, 0);

        linea.Size = new Size(220, 4);

        linea.Anchor =
            AnchorStyles.Top |
            AnchorStyles.Left |
            AnchorStyles.Right;

        // Insignia de la tarjeta

        Panel panelSigla = new Panel();

        panelSigla.BackColor = colorAcento;

        panelSigla.Location = new Point(17, 19);

        panelSigla.Size = new Size(40, 40);

        Label lblSigla = new Label();

        lblSigla.Dock = DockStyle.Fill;

        lblSigla.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Bold);

        lblSigla.ForeColor = Color.White;

        lblSigla.Text = sigla;

        lblSigla.TextAlign = ContentAlignment.MiddleCenter;

        panelSigla.Controls.Add(lblSigla);

        // Título

        Label lblTituloTarjeta = new Label();

        lblTituloTarjeta.AutoSize = false;

        lblTituloTarjeta.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Bold);

        lblTituloTarjeta.ForeColor = Color.FromArgb(71, 85, 105);

        lblTituloTarjeta.Location = new Point(67, 25);

        lblTituloTarjeta.Size = new Size(140, 31);

        lblTituloTarjeta.Anchor =
            AnchorStyles.Top |
            AnchorStyles.Left |
            AnchorStyles.Right;

        lblTituloTarjeta.Text = titulo;

        lblTituloTarjeta.TextAlign = ContentAlignment.MiddleLeft;

        lblTituloTarjeta.AutoEllipsis = true;

        // Cantidad obtenida de SQL Server

        cantidad.AutoSize = false;

        cantidad.Font = new Font(
            "Segoe UI",
            28F,
            FontStyle.Bold);

        cantidad.ForeColor = Color.FromArgb(15, 23, 42);

        cantidad.Location = new Point(18, 75);

        cantidad.Size = new Size(180, 45);

        cantidad.Anchor =
            AnchorStyles.Top |
            AnchorStyles.Left |
            AnchorStyles.Right;

        cantidad.Text = "0";

        cantidad.TextAlign = ContentAlignment.MiddleLeft;

        // Descripción

        Label lblDescripcion = new Label();

        lblDescripcion.AutoSize = false;

        lblDescripcion.Font = new Font(
            "Segoe UI",
            8F,
            FontStyle.Regular);

        lblDescripcion.ForeColor = Color.FromArgb(100, 116, 139);

        lblDescripcion.Location = new Point(18, 128);

        lblDescripcion.Size = new Size(180, 20);

        lblDescripcion.Anchor =
            AnchorStyles.Bottom |
            AnchorStyles.Left |
            AnchorStyles.Right;

        lblDescripcion.Text = descripcion;

        // Agregar al panel

        tarjeta.Controls.Add(linea);
        tarjeta.Controls.Add(panelSigla);
        tarjeta.Controls.Add(lblTituloTarjeta);
        tarjeta.Controls.Add(cantidad);
        tarjeta.Controls.Add(lblDescripcion);
    }
}