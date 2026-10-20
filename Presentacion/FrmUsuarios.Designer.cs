namespace GymSystem;

partial class FrmUsuarios
{
    private System.ComponentModel.IContainer components = null;

    private Panel panelSuperior;
    private Panel panelLista;

    private Label lblTitulo;
    private Label lblBuscar;
    private TextBox txtBuscar;
    private CheckBox chkInactivos;

    private Button btnCrearUsuario;
    private Button btnDesactivar;
    private Button btnRestaurar;

    private DataGridView dgvUsuarios;

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
        panelLista = new Panel();

        lblTitulo = new Label();
        lblBuscar = new Label();
        txtBuscar = new TextBox();
        chkInactivos = new CheckBox();

        btnCrearUsuario = new Button();
        btnDesactivar = new Button();
        btnRestaurar = new Button();

        dgvUsuarios = new DataGridView();

        SuspendLayout();

        // =====================================================
        // FORMULARIO PRINCIPAL
        // REDISENO_USUARIOS_2026
        // =====================================================

        AutoScaleMode = AutoScaleMode.Font;

        BackColor = Color.FromArgb(246, 248, 252);

        ClientSize = new Size(1150, 700);

        MinimumSize = new Size(900, 580);

        StartPosition = FormStartPosition.CenterScreen;

        Text = "GymSystem | Gestión de usuarios";

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

        Panel panelTituloUsuarios = new Panel();

        panelTituloUsuarios.Dock = DockStyle.Fill;

        panelTituloUsuarios.BackColor = Color.White;

        lblTitulo.AutoSize = false;

        lblTitulo.Font = new Font(
            "Segoe UI",
            21F,
            FontStyle.Bold);

        lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);

        lblTitulo.Location = new Point(0, 7);

        lblTitulo.Size = new Size(310, 38);

        lblTitulo.Text = "Usuarios";

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
            "Administra las cuentas de acceso al sistema.";

        panelTituloUsuarios.Controls.Add(lblTitulo);

        panelTituloUsuarios.Controls.Add(
            lblDescripcionSuperior);

        layoutSuperior.Controls.Add(
            panelTituloUsuarios,
            0,
            0);

        layoutSuperior.SetRowSpan(
            panelTituloUsuarios,
            2);

        // Etiqueta de búsqueda

        lblBuscar.Dock = DockStyle.Fill;

        lblBuscar.Font = new Font(
            "Segoe UI",
            8.5F,
            FontStyle.Bold);

        lblBuscar.ForeColor =
            Color.FromArgb(71, 85, 105);

        lblBuscar.Margin = new Padding(10, 0, 5, 0);

        lblBuscar.Text = "BUSCAR USUARIO";

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

        txtBuscar.BackColor =
            Color.FromArgb(248, 250, 252);

        txtBuscar.ForeColor =
            Color.FromArgb(15, 23, 42);

        txtBuscar.BorderStyle =
            BorderStyle.FixedSingle;

        txtBuscar.Margin =
            new Padding(10, 4, 12, 5);

        txtBuscar.PlaceholderText =
            "Nombre o nombre de usuario";

        layoutSuperior.Controls.Add(
            txtBuscar,
            1,
            1);

        // Filtro de usuarios inactivos

        Label lblFiltro = new Label();

        lblFiltro.Dock = DockStyle.Fill;

        lblFiltro.Font = new Font(
            "Segoe UI",
            8.5F,
            FontStyle.Bold);

        lblFiltro.ForeColor =
            Color.FromArgb(71, 85, 105);

        lblFiltro.Margin =
            new Padding(6, 0, 0, 0);

        lblFiltro.Text = "FILTROS";

        lblFiltro.TextAlign =
            ContentAlignment.BottomLeft;

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

        chkInactivos.Margin =
            new Padding(6, 7, 0, 0);

        chkInactivos.Text = "Mostrar inactivos";

        chkInactivos.Checked = false;

        layoutSuperior.Controls.Add(
            chkInactivos,
            2,
            1);

        panelSuperior.Controls.Add(layoutSuperior);

        // =====================================================
        // ÁREA PRINCIPAL DEL LISTADO
        // =====================================================

        panelLista.BackColor =
            Color.FromArgb(246, 248, 252);

        panelLista.Dock = DockStyle.Fill;

        panelLista.Padding =
            new Padding(18);

        // =====================================================
        // ENCABEZADO DEL LISTADO
        // =====================================================

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

        lblTituloLista.Location =
            new Point(1, 0);

        lblTituloLista.Size =
            new Size(450, 29);

        lblTituloLista.Text = "Listado de usuarios";

        Label lblDescripcionLista = new Label();

        lblDescripcionLista.AutoSize = false;

        lblDescripcionLista.Font = new Font(
            "Segoe UI",
            8.5F,
            FontStyle.Regular);

        lblDescripcionLista.ForeColor =
            Color.FromArgb(100, 116, 139);

        lblDescripcionLista.Location =
            new Point(2, 31);

        lblDescripcionLista.Size =
            new Size(520, 22);

        lblDescripcionLista.Text =
            "Selecciona un usuario para administrar su acceso.";

        panelEncabezadoLista.Controls.Add(
            lblTituloLista);

        panelEncabezadoLista.Controls.Add(
            lblDescripcionLista);

        // =====================================================
        // TABLA DE USUARIOS
        // =====================================================

        dgvUsuarios.BackgroundColor = Color.White;

        dgvUsuarios.BorderStyle = BorderStyle.None;

        dgvUsuarios.GridColor =
            Color.FromArgb(226, 232, 240);

        dgvUsuarios.RowHeadersVisible = false;

        dgvUsuarios.AllowUserToAddRows = false;

        dgvUsuarios.AllowUserToDeleteRows = false;

        dgvUsuarios.AllowUserToResizeRows = false;

        dgvUsuarios.MultiSelect = false;

        dgvUsuarios.ReadOnly = true;

        dgvUsuarios.Dock = DockStyle.Fill;

        dgvUsuarios.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dgvUsuarios.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        dgvUsuarios.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.None;

        dgvUsuarios.ColumnHeadersHeight = 44;

        dgvUsuarios.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

        dgvUsuarios.EnableHeadersVisualStyles = false;

        dgvUsuarios.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;

        dgvUsuarios.CellBorderStyle =
            DataGridViewCellBorderStyle.SingleHorizontal;

        dgvUsuarios.DefaultCellStyle =
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

        dgvUsuarios.ColumnHeadersDefaultCellStyle =
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
                Alignment =
                    DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(7, 0, 3, 0)
            };

        dgvUsuarios.AlternatingRowsDefaultCellStyle =
            new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 250, 252),
                ForeColor = Color.FromArgb(51, 65, 85),
                SelectionBackColor = Color.FromArgb(220, 252, 231),
                SelectionForeColor = Color.FromArgb(15, 23, 42)
            };

        dgvUsuarios.RowTemplate.Height = 39;

        // =====================================================
        // BARRA DE ACCIONES
        // =====================================================

        FlowLayoutPanel panelAccionesUsuarios =
            new FlowLayoutPanel();

        panelAccionesUsuarios.Name =
            "panelAccionesUsuarios";

        panelAccionesUsuarios.Dock =
            DockStyle.Bottom;

        panelAccionesUsuarios.Height = 66;

        panelAccionesUsuarios.BackColor =
            Color.FromArgb(246, 248, 252);

        panelAccionesUsuarios.Padding =
            new Padding(0, 12, 0, 0);

        panelAccionesUsuarios.Margin = Padding.Empty;

        panelAccionesUsuarios.FlowDirection =
            FlowDirection.LeftToRight;

        panelAccionesUsuarios.WrapContents = false;

        panelAccionesUsuarios.AutoScroll = true;

        // =====================================================
        // BOTÓN CREAR USUARIO
        // =====================================================

        ConfigurarBotonUsuario(
            btnCrearUsuario,
            "Crear usuario",
            new Size(160, 40),
            Color.FromArgb(22, 163, 74),
            Color.White,
            Color.FromArgb(21, 128, 61),
            Color.FromArgb(22, 101, 52));

        btnCrearUsuario.Click +=
            BtnCrearUsuario_Click;

        // =====================================================
        // BOTÓN DESACTIVAR
        // =====================================================

        ConfigurarBotonUsuario(
            btnDesactivar,
            "Desactivar usuario",
            new Size(175, 40),
            Color.FromArgb(220, 38, 38),
            Color.White,
            Color.FromArgb(185, 28, 28),
            Color.FromArgb(153, 27, 27));

        btnDesactivar.Click +=
            BtnDesactivar_Click;

        // =====================================================
        // BOTÓN RESTAURAR
        // =====================================================

        ConfigurarBotonUsuario(
            btnRestaurar,
            "Restaurar usuario",
            new Size(175, 40),
            Color.FromArgb(37, 99, 235),
            Color.White,
            Color.FromArgb(29, 78, 216),
            Color.FromArgb(30, 64, 175));

        btnRestaurar.Click +=
            BtnRestaurar_Click;

        // Agregar botones a la barra de acciones

        panelAccionesUsuarios.Controls.Add(btnCrearUsuario);

        panelAccionesUsuarios.Controls.Add(btnDesactivar);

        panelAccionesUsuarios.Controls.Add(btnRestaurar);

        // =====================================================
        // ARMAR EL PANEL DEL LISTADO
        // =====================================================

        panelLista.Controls.Add(dgvUsuarios);

        panelLista.Controls.Add(panelAccionesUsuarios);

        panelLista.Controls.Add(panelEncabezadoLista);

        // =====================================================
        // AGREGAR PANELES PRINCIPALES
        // =====================================================

        Controls.Add(panelLista);

        Controls.Add(panelSuperior);

        ResumeLayout(false);
    }

    // =========================================================
    // ESTILO DE LOS BOTONES
    // =========================================================

    private void ConfigurarBotonUsuario(
        Button boton,
        string texto,
        Size tamano,
        Color fondo,
        Color primerPlano,
        Color hover,
        Color presionado)
    {
        boton.BackColor = fondo;

        boton.ForeColor = primerPlano;

        boton.FlatStyle = FlatStyle.Flat;

        boton.FlatAppearance.BorderSize = 0;

        boton.FlatAppearance.MouseOverBackColor = hover;

        boton.FlatAppearance.MouseDownBackColor = presionado;

        boton.Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Bold);

        boton.Size = tamano;

        boton.Margin = new Padding(0, 0, 10, 0);

        boton.Text = texto;

        boton.TextAlign =
            ContentAlignment.MiddleCenter;

        boton.UseVisualStyleBackColor = false;

        boton.Cursor = Cursors.Hand;
    }
}