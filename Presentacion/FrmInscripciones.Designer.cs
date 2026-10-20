namespace GymSystem;

partial class FrmInscripciones
{
    private System.ComponentModel.IContainer components = null;

    private Panel panelSuperior;
    private Panel panelFormulario;
    private Panel panelLista;

    private Label lblTitulo;
    private Label lblBuscar;
    private TextBox txtBuscar;

    private Label lblCliente;
    private Label lblPlan;
    private Label lblFechaInicio;
    private Label lblFechaFin;

    private ComboBox cmbCliente;
    private ComboBox cmbPlan;

    private DateTimePicker dtpFechaInicio;
    private DateTimePicker dtpFechaFin;

    private Button btnNuevo;
    private Button btnGuardar;
    private Button btnEliminar;

    private DataGridView dgvInscripciones;

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

        lblCliente = new Label();
        lblPlan = new Label();
        lblFechaInicio = new Label();
        lblFechaFin = new Label();

        cmbCliente = new ComboBox();
        cmbPlan = new ComboBox();

        dtpFechaInicio = new DateTimePicker();
        dtpFechaFin = new DateTimePicker();

        btnNuevo = new Button();
        btnGuardar = new Button();
        btnEliminar = new Button();

        dgvInscripciones = new DataGridView();

        SuspendLayout();

        // =====================================================
        // FORMULARIO
        // =====================================================

        AutoScaleMode = AutoScaleMode.Font;

        BackColor = Color.FromArgb(246, 248, 252);

        ClientSize = new Size(1150, 700);

        MinimumSize = new Size(900, 580);

        StartPosition = FormStartPosition.CenterScreen;

        Text = "GymSystem | Gestión de inscripciones";

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

        Panel panelTituloInscripciones = new Panel();

        panelTituloInscripciones.Dock = DockStyle.Fill;

        panelTituloInscripciones.BackColor = Color.White;

        lblTitulo.AutoSize = false;

        lblTitulo.Font = new Font(
            "Segoe UI",
            21F,
            FontStyle.Bold);

        lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);

        lblTitulo.Location = new Point(0, 7);

        lblTitulo.Size = new Size(320, 38);

        lblTitulo.Text = "Inscripciones";

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
            "Gestiona las membresías de tus clientes.";

        panelTituloInscripciones.Controls.Add(lblTitulo);

        panelTituloInscripciones.Controls.Add(
            lblDescripcionSuperior);

        layoutSuperior.Controls.Add(
            panelTituloInscripciones,
            0,
            0);

        layoutSuperior.SetRowSpan(
            panelTituloInscripciones,
            2);

        // Búsqueda

        lblBuscar.Dock = DockStyle.Fill;

        lblBuscar.Font = new Font(
            "Segoe UI",
            8.5F,
            FontStyle.Bold);

        lblBuscar.ForeColor = Color.FromArgb(71, 85, 105);

        lblBuscar.Margin = new Padding(10, 0, 5, 0);

        lblBuscar.Text = "BUSCAR INSCRIPCIÓN";

        lblBuscar.TextAlign = ContentAlignment.BottomLeft;

        layoutSuperior.Controls.Add(
            lblBuscar,
            1,
            0);

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
            "Buscar por cliente o plan";

        txtBuscar.TextChanged += TxtBuscar_TextChanged;

        layoutSuperior.Controls.Add(
            txtBuscar,
            1,
            1);

        // Información del filtro

        Label lblFiltro = new Label();

        lblFiltro.Dock = DockStyle.Fill;

        lblFiltro.Font = new Font(
            "Segoe UI",
            8.5F,
            FontStyle.Bold);

        lblFiltro.ForeColor = Color.FromArgb(71, 85, 105);

        lblFiltro.Margin = new Padding(6, 0, 0, 0);

        lblFiltro.Text = "CONSULTA";

        lblFiltro.TextAlign = ContentAlignment.BottomLeft;

        layoutSuperior.Controls.Add(
            lblFiltro,
            2,
            0);

        Label lblInfoBusqueda = new Label();

        lblInfoBusqueda.Dock = DockStyle.Fill;

        lblInfoBusqueda.Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Regular);

        lblInfoBusqueda.ForeColor = Color.FromArgb(100, 116, 139);

        lblInfoBusqueda.Margin = new Padding(6, 5, 0, 0);

        lblInfoBusqueda.Text = "Buscar registros";

        lblInfoBusqueda.TextAlign = ContentAlignment.TopLeft;

        layoutSuperior.Controls.Add(
            lblInfoBusqueda,
            2,
            1);

        panelSuperior.Controls.Add(layoutSuperior);

        // =====================================================
        // PANEL DE DATOS DE LA INSCRIPCIÓN
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

        lblTituloFormulario.ForeColor = Color.FromArgb(22, 163, 74);

        lblTituloFormulario.Location = new Point(18, 11);

        lblTituloFormulario.Size = new Size(324, 23);

        lblTituloFormulario.Text = "DATOS DE LA INSCRIPCION";

        Label lblAyudaFormulario = new Label();

        lblAyudaFormulario.AutoSize = false;

        lblAyudaFormulario.Font = new Font(
            "Segoe UI",
            8F,
            FontStyle.Regular);

        lblAyudaFormulario.ForeColor = Color.FromArgb(100, 116, 139);

        lblAyudaFormulario.Location = new Point(18, 34);

        lblAyudaFormulario.Size = new Size(324, 19);

        lblAyudaFormulario.Text =
            "Selecciona el cliente, el plan y las fechas.";

        // =====================================================
        // CLIENTE
        // =====================================================

        ConfigurarEtiquetaInscripcion(
            lblCliente,
            "Cliente",
            70);

        cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;

        cmbCliente.Font = new Font(
            "Segoe UI",
            9.5F,
            FontStyle.Regular);

        cmbCliente.BackColor = Color.FromArgb(248, 250, 252);

        cmbCliente.ForeColor = Color.FromArgb(15, 23, 42);

        cmbCliente.FlatStyle = FlatStyle.Flat;

        cmbCliente.Location = new Point(18, 93);

        cmbCliente.Size = new Size(324, 28);

        cmbCliente.IntegralHeight = false;

        cmbCliente.DropDownHeight = 220;

        // =====================================================
        // PLAN
        // =====================================================

        ConfigurarEtiquetaInscripcion(
            lblPlan,
            "Plan de membresía",
            139);

        cmbPlan.DropDownStyle = ComboBoxStyle.DropDownList;

        cmbPlan.Font = new Font(
            "Segoe UI",
            9.5F,
            FontStyle.Regular);

        cmbPlan.BackColor = Color.FromArgb(248, 250, 252);

        cmbPlan.ForeColor = Color.FromArgb(15, 23, 42);

        cmbPlan.FlatStyle = FlatStyle.Flat;

        cmbPlan.Location = new Point(18, 162);

        cmbPlan.Size = new Size(324, 28);

        cmbPlan.IntegralHeight = false;

        cmbPlan.DropDownHeight = 220;

        // Conservar el evento del cálculo de vencimiento.

        cmbPlan.SelectedIndexChanged +=
            CmbPlan_SelectedIndexChanged;

        // =====================================================
        // FECHA DE INICIO
        // =====================================================

        ConfigurarEtiquetaInscripcion(
            lblFechaInicio,
            "Fecha de inicio",
            208);

        dtpFechaInicio.Font = new Font(
            "Segoe UI",
            9.5F,
            FontStyle.Regular);

        dtpFechaInicio.Format = DateTimePickerFormat.Short;

        dtpFechaInicio.Location = new Point(18, 231);

        dtpFechaInicio.Size = new Size(324, 29);

        dtpFechaInicio.MaxDate = DateTimePicker.MaximumDateTime;

        dtpFechaInicio.Value = DateTime.Today;

        // Conservar el evento del cálculo de vencimiento.

        dtpFechaInicio.ValueChanged +=
            DtpFechaInicio_ValueChanged;

        // =====================================================
        // FECHA DE VENCIMIENTO
        // =====================================================

        ConfigurarEtiquetaInscripcion(
            lblFechaFin,
            "Fecha de vencimiento",
            277);

        dtpFechaFin.Font = new Font(
            "Segoe UI",
            9.5F,
            FontStyle.Regular);

        dtpFechaFin.Format = DateTimePickerFormat.Short;

        dtpFechaFin.Location = new Point(18, 300);

        dtpFechaFin.Size = new Size(324, 29);

        dtpFechaFin.Enabled = false;

        dtpFechaFin.Value = DateTime.Today;

        // =====================================================
        // INFORMACIÓN DE VENCIMIENTO
        // =====================================================

        Label lblNotaFecha = new Label();

        lblNotaFecha.AutoSize = false;

        lblNotaFecha.Font = new Font(
            "Segoe UI",
            8F,
            FontStyle.Regular);

        lblNotaFecha.ForeColor = Color.FromArgb(100, 116, 139);

        lblNotaFecha.Location = new Point(18, 336);

        lblNotaFecha.Size = new Size(324, 31);

        lblNotaFecha.Text =
            "La fecha de vencimiento se calcula según la duración del plan.";

        // =====================================================
        // BOTONES
        // =====================================================

        ConfigurarBotonInscripcion(
            btnNuevo,
            "Nuevo",
            new Point(18, 390),
            new Size(157, 39),
            Color.White,
            Color.FromArgb(51, 65, 85),
            Color.FromArgb(203, 213, 225),
            Color.FromArgb(248, 250, 252),
            Color.FromArgb(226, 232, 240),
            true);

        btnNuevo.Click += BtnNuevo_Click;

        ConfigurarBotonInscripcion(
            btnGuardar,
            "Registrar",
            new Point(185, 390),
            new Size(157, 39),
            Color.FromArgb(22, 163, 74),
            Color.White,
            Color.FromArgb(22, 163, 74),
            Color.FromArgb(21, 128, 61),
            Color.FromArgb(22, 101, 52),
            false);

        btnGuardar.Click += BtnGuardar_Click;

        ConfigurarBotonInscripcion(
            btnEliminar,
            "Cancelar inscripción",
            new Point(18, 438),
            new Size(324, 39),
            Color.FromArgb(220, 38, 38),
            Color.White,
            Color.FromArgb(220, 38, 38),
            Color.FromArgb(185, 28, 28),
            Color.FromArgb(153, 27, 27),
            false);

        btnEliminar.Click += BtnEliminar_Click;

        // Agregar controles al formulario lateral

        panelFormulario.Controls.Add(
            lblTituloFormulario);

        panelFormulario.Controls.Add(
            lblAyudaFormulario);

        panelFormulario.Controls.Add(
            lblCliente);

        panelFormulario.Controls.Add(
            cmbCliente);

        panelFormulario.Controls.Add(
            lblPlan);

        panelFormulario.Controls.Add(
            cmbPlan);

        panelFormulario.Controls.Add(
            lblFechaInicio);

        panelFormulario.Controls.Add(
            dtpFechaInicio);

        panelFormulario.Controls.Add(
            lblFechaFin);

        panelFormulario.Controls.Add(
            dtpFechaFin);

        panelFormulario.Controls.Add(
            lblNotaFecha);

        panelFormulario.Controls.Add(
            btnNuevo);

        panelFormulario.Controls.Add(
            btnGuardar);

        panelFormulario.Controls.Add(
            btnEliminar);

        // =====================================================
        // LISTADO DE INSCRIPCIONES
        // =====================================================

        panelLista.BackColor = Color.FromArgb(246, 248, 252);

        panelLista.Dock = DockStyle.Fill;

        panelLista.Padding = new Padding(18);

        // Encabezado del listado

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

        lblTituloLista.Size = new Size(500, 29);

        lblTituloLista.Text = "Listado de inscripciones";

        Label lblDescripcionLista = new Label();

        lblDescripcionLista.AutoSize = false;

        lblDescripcionLista.Font = new Font(
            "Segoe UI",
            8.5F,
            FontStyle.Regular);

        lblDescripcionLista.ForeColor = Color.FromArgb(100, 116, 139);

        lblDescripcionLista.Location = new Point(2, 31);

        lblDescripcionLista.Size = new Size(540, 22);

        lblDescripcionLista.Text =
            "Selecciona una fila para consultar una inscripción.";

        panelEncabezadoLista.Controls.Add(
            lblTituloLista);

        panelEncabezadoLista.Controls.Add(
            lblDescripcionLista);

        // =====================================================
        // TABLA
        // =====================================================

        dgvInscripciones.BackgroundColor = Color.White;

        dgvInscripciones.BorderStyle = BorderStyle.None;

        dgvInscripciones.GridColor = Color.FromArgb(226, 232, 240);

        dgvInscripciones.RowHeadersVisible = false;

        dgvInscripciones.AllowUserToAddRows = false;

        dgvInscripciones.AllowUserToDeleteRows = false;

        dgvInscripciones.AllowUserToResizeRows = false;

        dgvInscripciones.MultiSelect = false;

        dgvInscripciones.ReadOnly = true;

        dgvInscripciones.Dock = DockStyle.Fill;

        dgvInscripciones.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dgvInscripciones.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        dgvInscripciones.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.None;

        dgvInscripciones.ColumnHeadersHeight = 44;

        dgvInscripciones.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

        dgvInscripciones.EnableHeadersVisualStyles = false;

        dgvInscripciones.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;

        dgvInscripciones.CellBorderStyle =
            DataGridViewCellBorderStyle.SingleHorizontal;

        dgvInscripciones.DefaultCellStyle =
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

        dgvInscripciones.ColumnHeadersDefaultCellStyle =
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

        dgvInscripciones.AlternatingRowsDefaultCellStyle =
            new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 250, 252),
                ForeColor = Color.FromArgb(51, 65, 85),
                SelectionBackColor = Color.FromArgb(220, 252, 231),
                SelectionForeColor = Color.FromArgb(15, 23, 42)
            };

        dgvInscripciones.RowTemplate.Height = 37;


        // Agregar tabla y encabezado al panel

        panelLista.Controls.Add(dgvInscripciones);

        panelLista.Controls.Add(panelEncabezadoLista);

        // =====================================================
        // AGREGAR PANELES
        // =====================================================

        Controls.Add(panelLista);

        Controls.Add(panelFormulario);

        Controls.Add(panelSuperior);

        ResumeLayout(false);
    }

    // =========================================================
    // ESTILO DE ETIQUETAS
    // =========================================================

    private void ConfigurarEtiquetaInscripcion(
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
    // ESTILO DE BOTONES
    // =========================================================

    private void ConfigurarBotonInscripcion(
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