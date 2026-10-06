namespace GymSystem;

partial class FrmPrincipal
{
    private System.ComponentModel.IContainer components = null;

    private Panel panelMenu;
    private Panel panelSuperior;
    private Panel panelContenido;

    private Label lblLogo;
    private Label lblUsuario;
    private Label lblTitulo;

    private Button btnInicio;
    private Button btnClientes;
    private Button btnPlanes;
    private Button btnInscripciones;
    private Button btnPagos;
    private Button btnUsuarios;
    private Button btnCerrarSesion;

    private Panel tarjetaClientes;
    private Panel tarjetaPlanes;
    private Panel tarjetaInscripciones;
    private Panel tarjetaPagos;

    private Label lblCantidadClientes;
    private Label lblCantidadPlanes;
    private Label lblCantidadInscripciones;
    private Label lblCantidadPagos;

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
        lblUsuario = new Label();
        lblTitulo = new Label();

        btnInicio = new Button();
        btnClientes = new Button();
        btnPlanes = new Button();
        btnInscripciones = new Button();
        btnPagos = new Button();
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

        SuspendLayout();

        // =====================================================
        // FORMULARIO PRINCIPAL
        // =====================================================

        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(241, 245, 249);
        ClientSize = new Size(1200, 720);
        MinimumSize = new Size(1050, 650);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "GymSystem";

        // =====================================================
        // MENÚ LATERAL
        // =====================================================

        panelMenu.BackColor = Color.FromArgb(15, 55, 75);
        panelMenu.Dock = DockStyle.Left;
        panelMenu.Size = new Size(240, 720);

        // Logo
        lblLogo.AutoSize = true;
        lblLogo.Font =
            new Font(
                "Segoe UI",
                21F,
                FontStyle.Bold);

        lblLogo.ForeColor = Color.White;
        lblLogo.Location =
            new Point(28, 28);

        lblLogo.Text = "GYMSYSTEM";

        // Línea visual debajo del logo
        Label lblLinea = new Label();

        lblLinea.BackColor =
            Color.FromArgb(37, 99, 235);

        lblLinea.Location =
            new Point(28, 72);

        lblLinea.Size =
            new Size(180, 3);

        // =====================================================
        // BOTONES DEL MENÚ
        // =====================================================

        ConfigurarBotonMenu(
            btnInicio,
            "Inicio",
            115);

        ConfigurarBotonMenu(
            btnClientes,
            "Clientes",
            165);

        ConfigurarBotonMenu(
            btnPlanes,
            "Planes",
            215);

        ConfigurarBotonMenu(
            btnInscripciones,
            "Inscripciones",
            265);

        ConfigurarBotonMenu(
            btnPagos,
            "Pagos",
            315);

        ConfigurarBotonMenu(
            btnUsuarios,
            "Usuarios",
            365);

        btnClientes.Click +=
            BtnClientes_Click;

        btnPlanes.Click +=
            BtnPlanes_Click;

        btnInscripciones.Click +=
            BtnInscripciones_Click;

        btnPagos.Click +=
            BtnPagos_Click;

        btnUsuarios.Click +=
            BtnUsuarios_Click;

        // =====================================================
        // BOTÓN CERRAR SESIÓN
        // =====================================================

        btnCerrarSesion.BackColor =
            Color.FromArgb(127, 29, 29);

        btnCerrarSesion.FlatAppearance.BorderSize =
            0;

        btnCerrarSesion.FlatAppearance.MouseOverBackColor =
            Color.FromArgb(153, 27, 27);

        btnCerrarSesion.FlatAppearance.MouseDownBackColor =
            Color.FromArgb(185, 28, 28);

        btnCerrarSesion.FlatStyle =
            FlatStyle.Flat;

        btnCerrarSesion.Font =
            new Font(
                "Segoe UI",
                9F,
                FontStyle.Bold);

        btnCerrarSesion.ForeColor =
            Color.White;

        btnCerrarSesion.Location =
            new Point(20, 650);

        btnCerrarSesion.Size =
            new Size(200, 42);

        btnCerrarSesion.Text =
            "Cerrar sesión";

        btnCerrarSesion.UseVisualStyleBackColor =
            false;

        btnCerrarSesion.Cursor =
            Cursors.Hand;

        btnCerrarSesion.Click +=
            BtnCerrarSesion_Click;

        // Agregar controles al menú
        panelMenu.Controls.Add(lblLogo);
        panelMenu.Controls.Add(lblLinea);

        panelMenu.Controls.Add(btnInicio);
        panelMenu.Controls.Add(btnClientes);
        panelMenu.Controls.Add(btnPlanes);
        panelMenu.Controls.Add(btnInscripciones);
        panelMenu.Controls.Add(btnPagos);
        panelMenu.Controls.Add(btnUsuarios);

        panelMenu.Controls.Add(btnCerrarSesion);

        // =====================================================
        // BARRA SUPERIOR
        // =====================================================

        panelSuperior.BackColor =
            Color.White;

        panelSuperior.Dock =
            DockStyle.Top;

        panelSuperior.Height =
            72;

        // Título
        lblTitulo.AutoSize = true;

        lblTitulo.Font =
            new Font(
                "Segoe UI",
                17F,
                FontStyle.Bold);

        lblTitulo.ForeColor =
            Color.FromArgb(15, 23, 42);

        lblTitulo.Location =
            new Point(270, 21);

        lblTitulo.Text =
            "Inicio";

        // Usuario
        lblUsuario.AutoSize = true;

        lblUsuario.Anchor =
            AnchorStyles.Top |
            AnchorStyles.Right;

        lblUsuario.Font =
            new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold);

        lblUsuario.ForeColor =
            Color.FromArgb(71, 85, 105);

        lblUsuario.Location =
            new Point(1000, 26);

        lblUsuario.Text =
            "Usuario";

        panelSuperior.Controls.Add(
            lblTitulo);

        panelSuperior.Controls.Add(
            lblUsuario);

        // =====================================================
        // CONTENIDO
        // =====================================================

        panelContenido.BackColor =
            Color.FromArgb(241, 245, 249);

        panelContenido.Dock =
            DockStyle.Fill;

        panelContenido.Padding =
            new Padding(30);

        // =====================================================
        // TARJETA CLIENTES
        // =====================================================

        CrearTarjeta(
            tarjetaClientes,
            "Clientes",
            lblCantidadClientes,
            30,
            40);

        // =====================================================
        // TARJETA PLANES
        // =====================================================

        CrearTarjeta(
            tarjetaPlanes,
            "Planes",
            lblCantidadPlanes,
            275,
            40);

        // =====================================================
        // TARJETA INSCRIPCIONES
        // =====================================================

        CrearTarjeta(
            tarjetaInscripciones,
            "Inscripciones",
            lblCantidadInscripciones,
            520,
            40);

        // =====================================================
        // TARJETA PAGOS
        // =====================================================

        CrearTarjeta(
            tarjetaPagos,
            "Pagos",
            lblCantidadPagos,
            765,
            40);

        panelContenido.Controls.Add(
            tarjetaClientes);

        panelContenido.Controls.Add(
            tarjetaPlanes);

        panelContenido.Controls.Add(
            tarjetaInscripciones);

        panelContenido.Controls.Add(
            tarjetaPagos);

        // =====================================================
        // AGREGAR PANELES
        // =====================================================

        Controls.Add(panelContenido);
        Controls.Add(panelSuperior);
        Controls.Add(panelMenu);

        ResumeLayout(false);
    }

    // =========================================================
    // CONFIGURAR BOTONES DEL MENÚ
    // =========================================================

    private void ConfigurarBotonMenu(
        Button boton,
        string texto,
        int posicionY)
    {
        boton.BackColor =
            Color.FromArgb(15, 55, 75);

        boton.FlatAppearance.BorderSize =
            0;

        boton.FlatAppearance.MouseOverBackColor =
            Color.FromArgb(25, 75, 100);

        boton.FlatAppearance.MouseDownBackColor =
            Color.FromArgb(30, 90, 120);

        boton.FlatStyle =
            FlatStyle.Flat;

        boton.Font =
            new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold);

        boton.ForeColor =
            Color.FromArgb(226, 232, 240);

        boton.Location =
            new Point(20, posicionY);

        boton.Size =
            new Size(200, 42);

        boton.Text =
            texto;

        boton.TextAlign =
            ContentAlignment.MiddleLeft;

        boton.Padding =
            new Padding(18, 0, 0, 0);

        boton.UseVisualStyleBackColor =
            false;

        boton.Cursor =
            Cursors.Hand;
    }

    // =========================================================
    // CREAR TARJETAS DEL INICIO
    // =========================================================

    private void CrearTarjeta(
        Panel tarjeta,
        string titulo,
        Label cantidad,
        int posicionX,
        int posicionY)
    {
        tarjeta.BackColor =
            Color.White;

        tarjeta.BorderStyle =
            BorderStyle.None;

        tarjeta.Location =
            new Point(
                posicionX,
                posicionY);

        tarjeta.Size =
            new Size(
                210,
                145);

        // Línea superior de la tarjeta
        Panel linea =
            new Panel();

        linea.BackColor =
            Color.FromArgb(37, 99, 235);

        linea.Location =
            new Point(0, 0);

        linea.Size =
            new Size(210, 5);

        // Título
        Label lblTituloTarjeta =
            new Label();

        lblTituloTarjeta.AutoSize =
            true;

        lblTituloTarjeta.Font =
            new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold);

        lblTituloTarjeta.ForeColor =
            Color.FromArgb(71, 85, 105);

        lblTituloTarjeta.Location =
            new Point(20, 25);

        lblTituloTarjeta.Text =
            titulo;

        // Cantidad
        cantidad.AutoSize =
            true;

        cantidad.Font =
            new Font(
                "Segoe UI",
                30F,
                FontStyle.Bold);

        cantidad.ForeColor =
            Color.FromArgb(15, 55, 75);

        cantidad.Location =
            new Point(20, 58);

        cantidad.Text =
            "0";

        tarjeta.Controls.Add(
            linea);

        tarjeta.Controls.Add(
            lblTituloTarjeta);

        tarjeta.Controls.Add(
            cantidad);
    }
}
