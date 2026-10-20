namespace GymSystem;

partial class FrmClientes
{
    private System.ComponentModel.IContainer components = null;

    private Panel panelSuperior;
    private Panel panelFormulario;
    private Panel panelLista;

    private Label lblTitulo;
    private Label lblBuscar;
    private TextBox txtBuscar;
    private CheckBox chkInactivos;

    private Label lblNombre;
    private Label lblCedula;
    private Label lblCorreo;
    private Label lblTelefono;
    private Label lblDireccion;
    private Label lblFechaNacimiento;

    private TextBox txtNombre;
    private TextBox txtCedula;
    private TextBox txtCorreo;
    private TextBox txtTelefono;
    private TextBox txtDireccion;
    private DateTimePicker dtpFechaNacimiento;

    private Button btnNuevo;
    private Button btnGuardar;
    private Button btnEliminar;
    private Button btnRestaurar;

    private DataGridView dgvClientes;

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

        panelSuperior = new Panel();
        panelFormulario = new Panel();
        panelLista = new Panel();

        lblTitulo = new Label();
        lblBuscar = new Label();
        txtBuscar = new TextBox();
        chkInactivos = new CheckBox();

        lblNombre = new Label();
        lblCedula = new Label();
        lblCorreo = new Label();
        lblTelefono = new Label();
        lblDireccion = new Label();
        lblFechaNacimiento = new Label();

        txtNombre = new TextBox();
        txtCedula = new TextBox();
        txtCorreo = new TextBox();
        txtTelefono = new TextBox();
        txtDireccion = new TextBox();

        dtpFechaNacimiento = new DateTimePicker();

        btnNuevo = new Button();
        btnGuardar = new Button();
        btnEliminar = new Button();
        btnRestaurar = new Button();

        dgvClientes = new DataGridView();

        SuspendLayout();

        // =====================================================
        // FORMULARIO
        // =====================================================

        AutoScaleMode = AutoScaleMode.Font;

        BackColor = Color.FromArgb(246, 248, 252);

        ClientSize = new Size(1150, 700);

        MinimumSize = new Size(900, 580);

        StartPosition = FormStartPosition.CenterScreen;

        Text = "GymSystem | Gestión de clientes";

        Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Regular);

        // =====================================================
        // ENCABEZADO Y BÚSQUEDA
        // =====================================================

        panelSuperior.BackColor = Color.White;

        panelSuperior.Dock = DockStyle.Top;

        panelSuperior.Height = 100;

        TableLayoutPanel layoutSuperior = new TableLayoutPanel();

        layoutSuperior.Dock = DockStyle.Fill;

        layoutSuperior.BackColor = Color.White;

        layoutSuperior.Padding = new Padding(22, 10, 18, 10);

        layoutSuperior.Margin = Padding.Empty;

        layoutSuperior.ColumnCount = 3;

        layoutSuperior.RowCount = 2;

        layoutSuperior.ColumnStyles.Add(
            new ColumnStyle(SizeType.Percent, 42F));

        layoutSuperior.ColumnStyles.Add(
            new ColumnStyle(SizeType.Percent, 37F));

        layoutSuperior.ColumnStyles.Add(
            new ColumnStyle(SizeType.Percent, 21F));

        layoutSuperior.RowStyles.Add(
            new RowStyle(SizeType.Percent, 48F));

        layoutSuperior.RowStyles.Add(
            new RowStyle(SizeType.Percent, 52F));

        // Título y descripción

        Panel panelTituloClientes = new Panel();

        panelTituloClientes.Dock = DockStyle.Fill;

        panelTituloClientes.BackColor = Color.White;

        lblTitulo.AutoSize = false;

        lblTitulo.Font = new Font(
            "Segoe UI",
            21F,
            FontStyle.Bold);

        lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);

        lblTitulo.Location = new Point(0, 7);

        lblTitulo.Size = new Size(310, 38);

        lblTitulo.Text = "Clientes";

        Label lblDescripcionSuperior = new Label();

        lblDescripcionSuperior.AutoSize = false;

        lblDescripcionSuperior.Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Regular);

        lblDescripcionSuperior.ForeColor =
            Color.FromArgb(100, 116, 139);

        lblDescripcionSuperior.Location = new Point(2, 45);

        lblDescripcionSuperior.Size = new Size(330, 22);

        lblDescripcionSuperior.Text =
            "Administra la información de tus clientes.";

        panelTituloClientes.Controls.Add(lblTitulo);

        panelTituloClientes.Controls.Add(
            lblDescripcionSuperior);

        layoutSuperior.Controls.Add(
            panelTituloClientes,
            0,
            0);

        layoutSuperior.SetRowSpan(
            panelTituloClientes,
            2);

        // Etiqueta de búsqueda

        lblBuscar.Dock = DockStyle.Fill;

        lblBuscar.Font = new Font(
            "Segoe UI",
            8.5F,
            FontStyle.Bold);

        lblBuscar.ForeColor = Color.FromArgb(71, 85, 105);

        lblBuscar.Margin = new Padding(10, 0, 5, 0);

        lblBuscar.Text = "BUSCAR CLIENTE";

        lblBuscar.TextAlign =
            ContentAlignment.BottomLeft;

        layoutSuperior.Controls.Add(
            lblBuscar,
            1,
            0);

        // Campo de búsqueda

        txtBuscar.Dock = DockStyle.Fill;

        txtBuscar.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Regular);

        txtBuscar.BackColor = Color.FromArgb(248, 250, 252);

        txtBuscar.ForeColor = Color.FromArgb(15, 23, 42);

        txtBuscar.BorderStyle = BorderStyle.FixedSingle;

        txtBuscar.Margin = new Padding(10, 4, 12, 5);

        txtBuscar.PlaceholderText =
            "Nombre, cédula o correo";

        layoutSuperior.Controls.Add(
            txtBuscar,
            1,
            1);

        // Filtro de inactivos

        Label lblFiltro = new Label();

        lblFiltro.Dock = DockStyle.Fill;

        lblFiltro.Font = new Font(
            "Segoe UI",
            8.5F,
            FontStyle.Bold);

        lblFiltro.ForeColor = Color.FromArgb(71, 85, 105);

        lblFiltro.Margin = new Padding(6, 0, 0, 0);

        lblFiltro.Text = "FILTROS";

        lblFiltro.TextAlign = ContentAlignment.BottomLeft;

        layoutSuperior.Controls.Add(
            lblFiltro,
            2,
            0);

        chkInactivos.AutoSize = true;

        chkInactivos.BackColor = Color.White;

        chkInactivos.Cursor = Cursors.Hand;

        chkInactivos.Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Regular);

        chkInactivos.ForeColor =
            Color.FromArgb(51, 65, 85);

        chkInactivos.Margin = new Padding(6, 7, 0, 0);

        chkInactivos.Text = "Mostrar inactivos";

        chkInactivos.Checked = false;

        layoutSuperior.Controls.Add(
            chkInactivos,
            2,
            1);

        panelSuperior.Controls.Add(layoutSuperior);

        // =====================================================
        // PANEL DE DATOS DEL CLIENTE
        // =====================================================

        panelFormulario.BackColor = Color.White;

        panelFormulario.Dock = DockStyle.Left;

        panelFormulario.Width = 370;

        panelFormulario.Padding = new Padding(18, 12, 18, 12);

        panelFormulario.AutoScroll = true;

        // Encabezado del formulario

        Label lblTituloFormulario = new Label();

        lblTituloFormulario.AutoSize = false;

        lblTituloFormulario.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Bold);

        lblTituloFormulario.ForeColor =
            Color.FromArgb(22, 163, 74);

        lblTituloFormulario.Location = new Point(18, 11);

        lblTituloFormulario.Size = new Size(320, 23);

        lblTituloFormulario.Text = "DATOS DEL CLIENTE";

        Label lblAyudaFormulario = new Label();

        lblAyudaFormulario.AutoSize = false;

        lblAyudaFormulario.Font = new Font(
            "Segoe UI",
            8F,
            FontStyle.Regular);

        lblAyudaFormulario.ForeColor =
            Color.FromArgb(100, 116, 139);

        lblAyudaFormulario.Location = new Point(18, 34);

        lblAyudaFormulario.Size = new Size(320, 19);

        lblAyudaFormulario.Text =
            "Completa los campos para registrar o editar.";

        // Nombre

        ConfigurarEtiquetaCliente(
            lblNombre,
            "Nombre completo",
            61);

        ConfigurarCampoCliente(
            txtNombre,
            82,
            324);

        txtNombre.MaxLength = 100;

        txtNombre.PlaceholderText =
            "Nombre y apellidos";

        // Cédula

        ConfigurarEtiquetaCliente(
            lblCedula,
            "Número de cédula",
            122);

        ConfigurarCampoCliente(
            txtCedula,
            143,
            324);

        txtCedula.MaxLength = 20;

        txtCedula.PlaceholderText =
            "Número de identificación";

        // Correo

        ConfigurarEtiquetaCliente(
            lblCorreo,
            "Correo electrónico",
            183);

        ConfigurarCampoCliente(
            txtCorreo,
            204,
            324);

        txtCorreo.MaxLength = 100;

        txtCorreo.PlaceholderText =
            "nombre@correo.com";

        // Teléfono

        ConfigurarEtiquetaCliente(
            lblTelefono,
            "Teléfono",
            244);

        ConfigurarCampoCliente(
            txtTelefono,
            265,
            324);

        txtTelefono.MaxLength = 20;

        txtTelefono.PlaceholderText =
            "Número de teléfono";

        // Dirección

        ConfigurarEtiquetaCliente(
            lblDireccion,
            "Dirección",
            305);

        txtDireccion.Font = new Font(
            "Segoe UI",
            9.5F,
            FontStyle.Regular);

        txtDireccion.Location = new Point(18, 326);

        txtDireccion.Multiline = true;

        txtDireccion.ScrollBars = ScrollBars.Vertical;

        txtDireccion.Size = new Size(324, 43);

        txtDireccion.BorderStyle = BorderStyle.FixedSingle;

        txtDireccion.BackColor =
            Color.FromArgb(248, 250, 252);

        txtDireccion.ForeColor =
            Color.FromArgb(15, 23, 42);

        // Fecha de nacimiento

        ConfigurarEtiquetaCliente(
            lblFechaNacimiento,
            "Fecha de nacimiento",
            379);

        dtpFechaNacimiento.Font = new Font(
            "Segoe UI",
            9.5F,
            FontStyle.Regular);

        dtpFechaNacimiento.Format =
            DateTimePickerFormat.Short;

        dtpFechaNacimiento.Location =
            new Point(18, 400);

        dtpFechaNacimiento.Size =
            new Size(185, 29);

        dtpFechaNacimiento.MaxDate =
            DateTime.Today;

        dtpFechaNacimiento.Value =
            DateTime.Today;

        // =====================================================
        // BOTONES
        // =====================================================

        ConfigurarBotonCliente(
            btnNuevo,
            "Nuevo",
            new Point(18, 447),
            new Size(157, 39),
            Color.White,
            Color.FromArgb(51, 65, 85),
            Color.FromArgb(203, 213, 225),
            Color.FromArgb(248, 250, 252),
            Color.FromArgb(226, 232, 240),
            true);

        btnNuevo.Click += BtnNuevo_Click;

        ConfigurarBotonCliente(
            btnGuardar,
            "Guardar",
            new Point(185, 447),
            new Size(157, 39),
            Color.FromArgb(22, 163, 74),
            Color.White,
            Color.Transparent,
            Color.FromArgb(21, 128, 61),
            Color.FromArgb(22, 101, 52),
            false);

        btnGuardar.Click += BtnGuardar_Click;

        ConfigurarBotonCliente(
            btnEliminar,
            "Desactivar",
            new Point(18, 495),
            new Size(157, 39),
            Color.FromArgb(220, 38, 38),
            Color.White,
            Color.Transparent,
            Color.FromArgb(185, 28, 28),
            Color.FromArgb(153, 27, 27),
            false);

        btnEliminar.Click += BtnEliminar_Click;

        ConfigurarBotonCliente(
            btnRestaurar,
            "Restaurar",
            new Point(185, 495),
            new Size(157, 39),
            Color.FromArgb(37, 99, 235),
            Color.White,
            Color.Transparent,
            Color.FromArgb(29, 78, 216),
            Color.FromArgb(30, 64, 175),
            false);

        btnRestaurar.Click += BtnRestaurar_Click;

        // Agregar los controles del formulario

        panelFormulario.Controls.Add(lblTituloFormulario);

        panelFormulario.Controls.Add(lblAyudaFormulario);

        panelFormulario.Controls.Add(lblNombre);
        panelFormulario.Controls.Add(txtNombre);

        panelFormulario.Controls.Add(lblCedula);
        panelFormulario.Controls.Add(txtCedula);

        panelFormulario.Controls.Add(lblCorreo);
        panelFormulario.Controls.Add(txtCorreo);

        panelFormulario.Controls.Add(lblTelefono);
        panelFormulario.Controls.Add(txtTelefono);

        panelFormulario.Controls.Add(lblDireccion);
        panelFormulario.Controls.Add(txtDireccion);

        panelFormulario.Controls.Add(lblFechaNacimiento);
        panelFormulario.Controls.Add(dtpFechaNacimiento);

        panelFormulario.Controls.Add(btnNuevo);
        panelFormulario.Controls.Add(btnGuardar);
        panelFormulario.Controls.Add(btnEliminar);
        panelFormulario.Controls.Add(btnRestaurar);

        // =====================================================
        // PANEL DE LISTADO
        // =====================================================

        panelLista.BackColor =
            Color.FromArgb(246, 248, 252);

        panelLista.Dock = DockStyle.Fill;

        panelLista.Padding = new Padding(18);

        // Encabezado del listado

        Panel panelEncabezadoLista = new Panel();

        panelEncabezadoLista.Dock = DockStyle.Top;

        panelEncabezadoLista.Height = 63;

        panelEncabezadoLista.BackColor =
            Color.FromArgb(246, 248, 252);

        Label lblTituloLista = new Label();

        lblTituloLista.AutoSize = false;

        lblTituloLista.Font = new Font(
            "Segoe UI",
            13F,
            FontStyle.Bold);

        lblTituloLista.ForeColor =
            Color.FromArgb(15, 23, 42);

        lblTituloLista.Location = new Point(1, 0);

        lblTituloLista.Size = new Size(500, 29);

        lblTituloLista.Text = "Listado de clientes";

        Label lblDescripcionLista = new Label();

        lblDescripcionLista.AutoSize = false;

        lblDescripcionLista.Font = new Font(
            "Segoe UI",
            8.5F,
            FontStyle.Regular);

        lblDescripcionLista.ForeColor =
            Color.FromArgb(100, 116, 139);

        lblDescripcionLista.Location = new Point(2, 31);

        lblDescripcionLista.Size = new Size(520, 22);

        lblDescripcionLista.Text =
            "Selecciona una fila para ver o editar sus datos.";

        panelEncabezadoLista.Controls.Add(lblTituloLista);

        panelEncabezadoLista.Controls.Add(lblDescripcionLista);

        // =====================================================
        // TABLA DE CLIENTES
        // =====================================================

        dgvClientes.BackgroundColor = Color.White;

        dgvClientes.BorderStyle = BorderStyle.None;

        dgvClientes.GridColor =
            Color.FromArgb(226, 232, 240);

        dgvClientes.RowHeadersVisible = false;

        dgvClientes.AllowUserToAddRows = false;

        dgvClientes.AllowUserToDeleteRows = false;

        dgvClientes.AllowUserToResizeRows = false;

        dgvClientes.MultiSelect = false;

        dgvClientes.ReadOnly = true;

        dgvClientes.Dock = DockStyle.Fill;

        dgvClientes.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dgvClientes.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        dgvClientes.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.None;

        dgvClientes.ColumnHeadersHeight = 44;

        dgvClientes.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

        dgvClientes.EnableHeadersVisualStyles = false;

        dgvClientes.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;

        dgvClientes.CellBorderStyle =
            DataGridViewCellBorderStyle.SingleHorizontal;

        dgvClientes.DefaultCellStyle =
            new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(51, 65, 85),
                SelectionBackColor = Color.FromArgb(220, 252, 231),
                SelectionForeColor = Color.FromArgb(15, 23, 42),
                Font = new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Regular),
                Padding = new Padding(7, 0, 3, 0)
            };

        dgvClientes.ColumnHeadersDefaultCellStyle =
            new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(15, 23, 42),
                ForeColor = Color.White,
                SelectionBackColor = Color.FromArgb(15, 23, 42),
                SelectionForeColor = Color.White,
                Font = new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(7, 0, 3, 0)
            };

        dgvClientes.AlternatingRowsDefaultCellStyle =
            new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 250, 252),
                ForeColor = Color.FromArgb(51, 65, 85),
                SelectionBackColor = Color.FromArgb(220, 252, 231),
                SelectionForeColor = Color.FromArgb(15, 23, 42)
            };

        dgvClientes.RowTemplate.Height = 37;

        dgvClientes.DataError += (sender, e) =>
        {
            e.ThrowException = false;
        };

        // Primero se agrega la tabla y después el encabezado.
        // El encabezado ocupa la parte superior y la tabla el espacio restante.

        panelLista.Controls.Add(dgvClientes);

        panelLista.Controls.Add(panelEncabezadoLista);

        // =====================================================
        // AGREGAR PANELES AL FORMULARIO
        // =====================================================

        Controls.Add(panelLista);

        Controls.Add(panelFormulario);

        Controls.Add(panelSuperior);

        ResumeLayout(false);
    }

    // =========================================================
    // ESTILO DE ETIQUETAS
    // =========================================================

    private void ConfigurarEtiquetaCliente(
        Label etiqueta,
        string texto,
        int posicionY)
    {
        etiqueta.AutoSize = false;

        etiqueta.Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Bold);

        etiqueta.ForeColor =
            Color.FromArgb(51, 65, 85);

        etiqueta.Location =
            new Point(18, posicionY);

        etiqueta.Size =
            new Size(324, 21);

        etiqueta.Text = texto;
    }

    // =========================================================
    // ESTILO DE CAMPOS DE TEXTO
    // =========================================================

    private void ConfigurarCampoCliente(
        TextBox campo,
        int posicionY,
        int ancho)
    {
        campo.Font = new Font(
            "Segoe UI",
            9.5F,
            FontStyle.Regular);

        campo.Location =
            new Point(18, posicionY);

        campo.Size =
            new Size(ancho, 29);

        campo.BorderStyle =
            BorderStyle.FixedSingle;

        campo.BackColor =
            Color.FromArgb(248, 250, 252);

        campo.ForeColor =
            Color.FromArgb(15, 23, 42);
    }

    // =========================================================
    // ESTILO DE BOTONES
    // =========================================================

    private void ConfigurarBotonCliente(
        Button boton,
        string texto,
        Point posicion,
        Size tamano,
        Color fondo,
        Color primerPlano,
        Color borde,
        Color hover,
        Color presionado,
        bool tieneBorde)
    {
        boton.BackColor = fondo;

        boton.ForeColor = primerPlano;

        boton.FlatStyle = FlatStyle.Flat;

        boton.FlatAppearance.BorderSize =
            tieneBorde ? 1 : 0;

        if (tieneBorde)
        {
            boton.FlatAppearance.BorderColor = borde;
        }

        boton.FlatAppearance.MouseOverBackColor = hover;

        boton.FlatAppearance.MouseDownBackColor = presionado;

        boton.Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Bold);

        boton.Location = posicion;

        boton.Size = tamano;

        boton.Text = texto;

        boton.UseVisualStyleBackColor = false;

        boton.Cursor = Cursors.Hand;
    }
}