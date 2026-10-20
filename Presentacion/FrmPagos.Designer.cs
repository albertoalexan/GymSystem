namespace GymSystem;

partial class FrmPagos
{
    private System.ComponentModel.IContainer components = null;

    private Panel panelSuperior;
    private Panel panelFormulario;
    private Panel panelLista;

    private Label lblTitulo;
    private Label lblBuscar;
    private TextBox txtBuscar;

    private Label lblCliente;
    private Label lblInscripcion;
    private Label lblMonto;
    private Label lblMetodo;

    private ComboBox cmbCliente;
    private ComboBox cmbInscripcion;
    private TextBox txtMonto;
    private ComboBox cmbMetodo;

    private Button btnNuevo;
    private Button btnGuardar;

    private DataGridView dgvPagos;

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
        lblInscripcion = new Label();
        lblMonto = new Label();
        lblMetodo = new Label();

        cmbCliente = new ComboBox();
        cmbInscripcion = new ComboBox();
        txtMonto = new TextBox();
        cmbMetodo = new ComboBox();

        btnNuevo = new Button();
        btnGuardar = new Button();

        dgvPagos = new DataGridView();

        SuspendLayout();

        // =====================================================
        // FORMULARIO
        // =====================================================

        AutoScaleMode = AutoScaleMode.Font;

        BackColor = Color.FromArgb(246, 248, 252);

        ClientSize = new Size(1150, 700);

        MinimumSize = new Size(900, 580);

        StartPosition = FormStartPosition.CenterScreen;

        Text = "GymSystem | Gestión de pagos";

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

        Panel panelTituloPagos = new Panel();

        panelTituloPagos.Dock = DockStyle.Fill;

        panelTituloPagos.BackColor = Color.White;

        lblTitulo.AutoSize = false;

        lblTitulo.Font = new Font(
            "Segoe UI",
            21F,
            FontStyle.Bold);

        lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);

        lblTitulo.Location = new Point(0, 7);

        lblTitulo.Size = new Size(310, 38);

        lblTitulo.Text = "Pagos";

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
            "Registra y consulta los pagos del gimnasio.";

        panelTituloPagos.Controls.Add(lblTitulo);

        panelTituloPagos.Controls.Add(lblDescripcionSuperior);

        layoutSuperior.Controls.Add(
            panelTituloPagos,
            0,
            0);

        layoutSuperior.SetRowSpan(
            panelTituloPagos,
            2);

        // Búsqueda

        lblBuscar.Dock = DockStyle.Fill;

        lblBuscar.Font = new Font(
            "Segoe UI",
            8.5F,
            FontStyle.Bold);

        lblBuscar.ForeColor = Color.FromArgb(71, 85, 105);

        lblBuscar.Margin = new Padding(10, 0, 5, 0);

        lblBuscar.Text = "BUSCAR PAGO";

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

        // El evento TextChanged se conserva en FrmPagos.cs.
        // No se agrega aquí para evitar duplicarlo.

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

        lblInfoBusqueda.Text = "Historial de pagos";

        lblInfoBusqueda.TextAlign = ContentAlignment.TopLeft;

        layoutSuperior.Controls.Add(
            lblInfoBusqueda,
            2,
            1);

        panelSuperior.Controls.Add(layoutSuperior);

        // =====================================================
        // FORMULARIO DE DATOS DEL PAGO
        // =====================================================

        panelFormulario.BackColor = Color.White;

        panelFormulario.Dock = DockStyle.Left;

        panelFormulario.Width = 370;

        panelFormulario.Padding = new Padding(18, 12, 18, 12);

        panelFormulario.AutoScroll = true;

        // Encabezado

        Label lblTituloFormulario = new Label();

        lblTituloFormulario.AutoSize = false;

        lblTituloFormulario.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Bold);

        lblTituloFormulario.ForeColor = Color.FromArgb(22, 163, 74);

        lblTituloFormulario.Location = new Point(18, 11);

        lblTituloFormulario.Size = new Size(324, 23);

        lblTituloFormulario.Text = "DATOS DEL PAGO";

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
            "Completa los datos para registrar un pago.";

        // =====================================================
        // CLIENTE
        // =====================================================

        ConfigurarEtiquetaPago(
            lblCliente,
            "Cliente",
            70);

        ConfigurarSelectorPago(
            cmbCliente,
            93,
            324);

        cmbCliente.SelectedIndexChanged +=
            CmbCliente_SelectedIndexChanged;

        // =====================================================
        // INSCRIPCIÓN
        // =====================================================

        ConfigurarEtiquetaPago(
            lblInscripcion,
            "Inscripción activa",
            139);

        ConfigurarSelectorPago(
            cmbInscripcion,
            162,
            324);

        // =====================================================
        // MONTO
        // =====================================================

        ConfigurarEtiquetaPago(
            lblMonto,
            "Monto del pago",
            208);

        txtMonto.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Regular);

        txtMonto.Location = new Point(18, 231);

        txtMonto.Size = new Size(324, 29);

        txtMonto.MaxLength = 10;

        txtMonto.BorderStyle = BorderStyle.FixedSingle;

        txtMonto.BackColor = Color.FromArgb(248, 250, 252);

        txtMonto.ForeColor = Color.FromArgb(15, 23, 42);

        txtMonto.PlaceholderText = "Ej.: 500.00";

        // Nota de moneda

        Label lblNotaMonto = new Label();

        lblNotaMonto.AutoSize = false;

        lblNotaMonto.Font = new Font(
            "Segoe UI",
            8F,
            FontStyle.Regular);

        lblNotaMonto.ForeColor = Color.FromArgb(100, 116, 139);

        lblNotaMonto.Location = new Point(18, 263);

        lblNotaMonto.Size = new Size(324, 19);

        lblNotaMonto.Text = "Monto expresado en córdobas (C$).";

        // =====================================================
        // MÉTODO DE PAGO
        // =====================================================

        ConfigurarEtiquetaPago(
            lblMetodo,
            "Método de pago",
            292);

        ConfigurarSelectorPago(
            cmbMetodo,
            315,
            324);

        cmbMetodo.Items.AddRange(
            new object[]
            {
                "Efectivo",
                "Tarjeta",
                "Transferencia"
            });

        // =====================================================
        // BOTONES
        // =====================================================

        ConfigurarBotonPago(
            btnNuevo,
            "Nuevo",
            new Point(18, 370),
            new Size(157, 40),
            Color.White,
            Color.FromArgb(51, 65, 85),
            Color.FromArgb(203, 213, 225),
            Color.FromArgb(248, 250, 252),
            Color.FromArgb(226, 232, 240),
            true);

        btnNuevo.Click += BtnNuevo_Click;

        ConfigurarBotonPago(
            btnGuardar,
            "Registrar pago",
            new Point(185, 370),
            new Size(157, 40),
            Color.FromArgb(22, 163, 74),
            Color.White,
            Color.FromArgb(22, 163, 74),
            Color.FromArgb(21, 128, 61),
            Color.FromArgb(22, 101, 52),
            false);

        btnGuardar.Click += BtnGuardar_Click;

        // Agregar controles del formulario

        panelFormulario.Controls.Add(
            lblTituloFormulario);

        panelFormulario.Controls.Add(
            lblAyudaFormulario);

        panelFormulario.Controls.Add(lblCliente);
        panelFormulario.Controls.Add(cmbCliente);

        panelFormulario.Controls.Add(lblInscripcion);
        panelFormulario.Controls.Add(cmbInscripcion);

        panelFormulario.Controls.Add(lblMonto);
        panelFormulario.Controls.Add(txtMonto);
        panelFormulario.Controls.Add(lblNotaMonto);

        panelFormulario.Controls.Add(lblMetodo);
        panelFormulario.Controls.Add(cmbMetodo);

        panelFormulario.Controls.Add(btnNuevo);
        panelFormulario.Controls.Add(btnGuardar);

        // =====================================================
        // LISTADO DE PAGOS
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

        lblTituloLista.Size = new Size(450, 29);

        lblTituloLista.Text = "Historial de pagos";

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
            "Consulta los pagos registrados y sus métodos.";

        panelEncabezadoLista.Controls.Add(lblTituloLista);

        panelEncabezadoLista.Controls.Add(lblDescripcionLista);

        // =====================================================
        // TABLA DE PAGOS
        // =====================================================

        dgvPagos.BackgroundColor = Color.White;

        dgvPagos.BorderStyle = BorderStyle.None;

        dgvPagos.GridColor = Color.FromArgb(226, 232, 240);

        dgvPagos.RowHeadersVisible = false;

        dgvPagos.AllowUserToAddRows = false;

        dgvPagos.AllowUserToDeleteRows = false;

        dgvPagos.AllowUserToResizeRows = false;

        dgvPagos.MultiSelect = false;

        dgvPagos.ReadOnly = true;

        dgvPagos.Dock = DockStyle.Fill;

        dgvPagos.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dgvPagos.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        dgvPagos.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.None;

        dgvPagos.ColumnHeadersHeight = 44;

        dgvPagos.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

        dgvPagos.EnableHeadersVisualStyles = false;

        dgvPagos.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;

        dgvPagos.CellBorderStyle =
            DataGridViewCellBorderStyle.SingleHorizontal;

        dgvPagos.DefaultCellStyle =
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

        dgvPagos.ColumnHeadersDefaultCellStyle =
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

        dgvPagos.AlternatingRowsDefaultCellStyle =
            new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 250, 252),
                ForeColor = Color.FromArgb(51, 65, 85),
                SelectionBackColor = Color.FromArgb(220, 252, 231),
                SelectionForeColor = Color.FromArgb(15, 23, 42)
            };

        dgvPagos.RowTemplate.Height = 37;

        // Agregar tabla y encabezado al panel.

        panelLista.Controls.Add(dgvPagos);

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

    private void ConfigurarEtiquetaPago(
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
    // ESTILO DE SELECTORES
    // =========================================================

    private void ConfigurarSelectorPago(
        ComboBox selector,
        int posicionY,
        int ancho)
    {
        selector.DropDownStyle = ComboBoxStyle.DropDownList;

        selector.Font = new Font(
            "Segoe UI",
            9.5F,
            FontStyle.Regular);

        selector.BackColor = Color.FromArgb(248, 250, 252);

        selector.ForeColor = Color.FromArgb(15, 23, 42);

        selector.FlatStyle = FlatStyle.Flat;

        selector.Location = new Point(18, posicionY);

        selector.Size = new Size(ancho, 28);

        selector.IntegralHeight = false;

        selector.DropDownHeight = 220;
    }

    // =========================================================
    // ESTILO DE BOTONES
    // =========================================================

    private void ConfigurarBotonPago(
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