namespace GymSystem;

partial class FrmPlanes
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
    private Label lblDuracion;
    private Label lblPrecio;

    private TextBox txtNombre;
    private TextBox txtDuracion;
    private TextBox txtPrecio;

    private Button btnNuevo;
    private Button btnGuardar;
    private Button btnEliminar;
    private Button btnRestaurar;

    private DataGridView dgvPlanes;

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
        lblDuracion = new Label();
        lblPrecio = new Label();

        txtNombre = new TextBox();
        txtDuracion = new TextBox();
        txtPrecio = new TextBox();

        btnNuevo = new Button();
        btnGuardar = new Button();
        btnEliminar = new Button();
        btnRestaurar = new Button();

        dgvPlanes = new DataGridView();

        SuspendLayout();

        // =====================================================
        // FORMULARIO
        // =====================================================

        AutoScaleMode = AutoScaleMode.Font;

        BackColor = Color.FromArgb(246, 248, 252);

        ClientSize = new Size(1150, 700);

        MinimumSize = new Size(900, 580);

        StartPosition = FormStartPosition.CenterScreen;

        Text = "GymSystem | Gestión de planes";

        Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Regular);

        // =====================================================
        // ENCABEZADO
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

        Panel panelTituloPlanes = new Panel();

        panelTituloPlanes.Dock = DockStyle.Fill;

        panelTituloPlanes.BackColor = Color.White;

        lblTitulo.AutoSize = false;

        lblTitulo.Font = new Font(
            "Segoe UI",
            21F,
            FontStyle.Bold);

        lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);

        lblTitulo.Location = new Point(0, 7);

        lblTitulo.Size = new Size(310, 38);

        lblTitulo.Text = "Planes";

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
            "Administra los planes y sus precios.";

        panelTituloPlanes.Controls.Add(lblTitulo);

        panelTituloPlanes.Controls.Add(lblDescripcionSuperior);

        layoutSuperior.Controls.Add(panelTituloPlanes, 0, 0);

        layoutSuperior.SetRowSpan(panelTituloPlanes, 2);

        // Búsqueda

        lblBuscar.Dock = DockStyle.Fill;

        lblBuscar.Font = new Font(
            "Segoe UI",
            8.5F,
            FontStyle.Bold);

        lblBuscar.ForeColor = Color.FromArgb(71, 85, 105);

        lblBuscar.Margin = new Padding(10, 0, 5, 0);

        lblBuscar.Text = "BUSCAR PLAN";

        lblBuscar.TextAlign = ContentAlignment.BottomLeft;

        layoutSuperior.Controls.Add(lblBuscar, 1, 0);

        txtBuscar.Dock = DockStyle.Fill;

        txtBuscar.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Regular);

        txtBuscar.BackColor = Color.FromArgb(248, 250, 252);

        txtBuscar.ForeColor = Color.FromArgb(15, 23, 42);

        txtBuscar.BorderStyle = BorderStyle.FixedSingle;

        txtBuscar.Margin = new Padding(10, 4, 12, 5);

        txtBuscar.PlaceholderText = "Nombre del plan";

        layoutSuperior.Controls.Add(txtBuscar, 1, 1);

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

        layoutSuperior.Controls.Add(lblFiltro, 2, 0);

        chkInactivos.AutoSize = true;

        chkInactivos.BackColor = Color.White;

        chkInactivos.Cursor = Cursors.Hand;

        chkInactivos.Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Regular);

        chkInactivos.ForeColor = Color.FromArgb(51, 65, 85);

        chkInactivos.Margin = new Padding(6, 7, 0, 0);

        chkInactivos.Text = "Mostrar inactivos";

        chkInactivos.Checked = false;

        layoutSuperior.Controls.Add(chkInactivos, 2, 1);

        panelSuperior.Controls.Add(layoutSuperior);

        // =====================================================
        // FORMULARIO DE DATOS DEL PLAN
        // =====================================================

        panelFormulario.BackColor = Color.White;

        panelFormulario.Dock = DockStyle.Left;

        panelFormulario.Width = 365;

        panelFormulario.Padding = new Padding(18, 12, 18, 12);

        panelFormulario.AutoScroll = true;

        Label lblTituloFormulario = new Label();

        lblTituloFormulario.AutoSize = false;

        lblTituloFormulario.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Bold);

        lblTituloFormulario.ForeColor = Color.FromArgb(22, 163, 74);

        lblTituloFormulario.Location = new Point(18, 11);

        lblTituloFormulario.Size = new Size(320, 23);

        lblTituloFormulario.Text = "DATOS DEL PLAN";

        Label lblAyudaFormulario = new Label();

        lblAyudaFormulario.AutoSize = false;

        lblAyudaFormulario.Font = new Font(
            "Segoe UI",
            8F,
            FontStyle.Regular);

        lblAyudaFormulario.ForeColor = Color.FromArgb(100, 116, 139);

        lblAyudaFormulario.Location = new Point(18, 34);

        lblAyudaFormulario.Size = new Size(320, 19);

        lblAyudaFormulario.Text =
            "Define el nombre, duración y precio.";

        // Nombre

        ConfigurarEtiquetaPlan(
            lblNombre,
            "Nombre del plan",
            72);

        ConfigurarCampoPlan(
            txtNombre,
            95,
            324);

        txtNombre.MaxLength = 50;

        txtNombre.PlaceholderText = "Ej.: Plan mensual";

        // Duración

        ConfigurarEtiquetaPlan(
            lblDuracion,
            "Duración (días)",
            145);

        ConfigurarCampoPlan(
            txtDuracion,
            168,
            324);

        txtDuracion.MaxLength = 4;

        txtDuracion.PlaceholderText = "Ej.: 30";

        // Precio

        ConfigurarEtiquetaPlan(
            lblPrecio,
            "Precio del plan",
            218);

        ConfigurarCampoPlan(
            txtPrecio,
            241,
            324);

        txtPrecio.MaxLength = 10;

        txtPrecio.PlaceholderText = "Ej.: 500.00";

        // Nota informativa

        Label lblNotaPrecio = new Label();

        lblNotaPrecio.AutoSize = false;

        lblNotaPrecio.Font = new Font(
            "Segoe UI",
            8F,
            FontStyle.Regular);

        lblNotaPrecio.ForeColor = Color.FromArgb(100, 116, 139);

        lblNotaPrecio.Location = new Point(18, 273);

        lblNotaPrecio.Size = new Size(324, 30);

        lblNotaPrecio.Text =
            "Ingresa un precio mayor que cero.";

        // =====================================================
        // BOTONES
        // =====================================================

        ConfigurarBotonPlan(
            btnNuevo,
            "Nuevo",
            new Point(18, 330),
            new Size(157, 39),
            Color.White,
            Color.FromArgb(51, 65, 85),
            Color.FromArgb(203, 213, 225),
            Color.FromArgb(248, 250, 252),
            Color.FromArgb(226, 232, 240),
            true);

        btnNuevo.Click += BtnNuevo_Click;

        ConfigurarBotonPlan(
            btnGuardar,
            "Guardar",
            new Point(185, 330),
            new Size(157, 39),
            Color.FromArgb(22, 163, 74),
            Color.White,
            Color.FromArgb(22, 163, 74),
            Color.FromArgb(21, 128, 61),
            Color.FromArgb(22, 101, 52),
            false);

        btnGuardar.Click += BtnGuardar_Click;

        ConfigurarBotonPlan(
            btnEliminar,
            "Desactivar",
            new Point(18, 378),
            new Size(157, 39),
            Color.FromArgb(220, 38, 38),
            Color.White,
            Color.FromArgb(220, 38, 38),
            Color.FromArgb(185, 28, 28),
            Color.FromArgb(153, 27, 27),
            false);

        btnEliminar.Click += BtnEliminar_Click;

        ConfigurarBotonPlan(
            btnRestaurar,
            "Restaurar",
            new Point(185, 378),
            new Size(157, 39),
            Color.FromArgb(37, 99, 235),
            Color.White,
            Color.FromArgb(37, 99, 235),
            Color.FromArgb(29, 78, 216),
            Color.FromArgb(30, 64, 175),
            false);

        btnRestaurar.Click += BtnRestaurar_Click;

        // Agregar controles del formulario

        panelFormulario.Controls.Add(lblTituloFormulario);

        panelFormulario.Controls.Add(lblAyudaFormulario);

        panelFormulario.Controls.Add(lblNombre);
        panelFormulario.Controls.Add(txtNombre);

        panelFormulario.Controls.Add(lblDuracion);
        panelFormulario.Controls.Add(txtDuracion);

        panelFormulario.Controls.Add(lblPrecio);
        panelFormulario.Controls.Add(txtPrecio);

        panelFormulario.Controls.Add(lblNotaPrecio);

        panelFormulario.Controls.Add(btnNuevo);
        panelFormulario.Controls.Add(btnGuardar);
        panelFormulario.Controls.Add(btnEliminar);
        panelFormulario.Controls.Add(btnRestaurar);

        // =====================================================
        // LISTADO DE PLANES
        // =====================================================

        panelLista.BackColor = Color.FromArgb(246, 248, 252);

        panelLista.Dock = DockStyle.Fill;

        panelLista.Padding = new Padding(18);

        Panel panelEncabezadoLista = new Panel();

        panelEncabezadoLista.Dock = DockStyle.Top;

        panelEncabezadoLista.Height = 63;

        panelEncabezadoLista.BackColor = Color.FromArgb(246, 248, 252);

        Label lblTituloLista = new Label();

        lblTituloLista.AutoSize = false;

        lblTituloLista.Font = new Font(
            "Segoe UI",
            13F,
            FontStyle.Bold);

        lblTituloLista.ForeColor = Color.FromArgb(15, 23, 42);

        lblTituloLista.Location = new Point(1, 0);

        lblTituloLista.Size = new Size(450, 29);

        lblTituloLista.Text = "Listado de planes";

        Label lblDescripcionLista = new Label();

        lblDescripcionLista.AutoSize = false;

        lblDescripcionLista.Font = new Font(
            "Segoe UI",
            8.5F,
            FontStyle.Regular);

        lblDescripcionLista.ForeColor = Color.FromArgb(100, 116, 139);

        lblDescripcionLista.Location = new Point(2, 31);

        lblDescripcionLista.Size = new Size(520, 22);

        lblDescripcionLista.Text =
            "Selecciona un plan para consultar o editar sus datos.";

        panelEncabezadoLista.Controls.Add(lblTituloLista);

        panelEncabezadoLista.Controls.Add(lblDescripcionLista);

        // =====================================================
        // TABLA
        // =====================================================

        dgvPlanes.BackgroundColor = Color.White;

        dgvPlanes.BorderStyle = BorderStyle.None;

        dgvPlanes.GridColor = Color.FromArgb(226, 232, 240);

        dgvPlanes.RowHeadersVisible = false;

        dgvPlanes.AllowUserToAddRows = false;

        dgvPlanes.AllowUserToDeleteRows = false;

        dgvPlanes.AllowUserToResizeRows = false;

        dgvPlanes.MultiSelect = false;

        dgvPlanes.ReadOnly = true;

        dgvPlanes.Dock = DockStyle.Fill;

        dgvPlanes.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dgvPlanes.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        dgvPlanes.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.None;

        dgvPlanes.ColumnHeadersHeight = 44;

        dgvPlanes.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

        dgvPlanes.EnableHeadersVisualStyles = false;

        dgvPlanes.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;

        dgvPlanes.CellBorderStyle =
            DataGridViewCellBorderStyle.SingleHorizontal;

        dgvPlanes.DefaultCellStyle =
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

        dgvPlanes.ColumnHeadersDefaultCellStyle =
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

        dgvPlanes.AlternatingRowsDefaultCellStyle =
            new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 250, 252),
                ForeColor = Color.FromArgb(51, 65, 85),
                SelectionBackColor = Color.FromArgb(220, 252, 231),
                SelectionForeColor = Color.FromArgb(15, 23, 42)
            };

        dgvPlanes.RowTemplate.Height = 37;

        // Agregar tabla y encabezado

        panelLista.Controls.Add(dgvPlanes);

        panelLista.Controls.Add(panelEncabezadoLista);

        // =====================================================
        // AGREGAR PANELES PRINCIPALES
        // =====================================================

        Controls.Add(panelLista);

        Controls.Add(panelFormulario);

        Controls.Add(panelSuperior);

        ResumeLayout(false);
    }

    // =========================================================
    // ESTILO DE ETIQUETAS
    // =========================================================

    private void ConfigurarEtiquetaPlan(
        Label etiqueta,
        string texto,
        int posicionY)
    {
        etiqueta.AutoSize = false;

        etiqueta.Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Bold);

        etiqueta.ForeColor = Color.FromArgb(51, 65, 85);

        etiqueta.Location = new Point(18, posicionY);

        etiqueta.Size = new Size(324, 21);

        etiqueta.Text = texto;
    }

    // =========================================================
    // ESTILO DE CAMPOS
    // =========================================================

    private void ConfigurarCampoPlan(
        TextBox campo,
        int posicionY,
        int ancho)
    {
        campo.Font = new Font(
            "Segoe UI",
            9.5F,
            FontStyle.Regular);

        campo.Location = new Point(18, posicionY);

        campo.Size = new Size(ancho, 29);

        campo.BorderStyle = BorderStyle.FixedSingle;

        campo.BackColor = Color.FromArgb(248, 250, 252);

        campo.ForeColor = Color.FromArgb(15, 23, 42);
    }

    // =========================================================
    // ESTILO DE BOTONES
    // =========================================================

    private void ConfigurarBotonPlan(
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

        boton.FlatAppearance.BorderSize = tieneBorde ? 1 : 0;

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