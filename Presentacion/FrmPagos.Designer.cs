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
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(1100, 650);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "GymSystem - Pagos";

        // =====================================================
        // PANEL SUPERIOR
        // =====================================================

        panelSuperior.BackColor = Color.White;
        panelSuperior.Dock = DockStyle.Top;
        panelSuperior.Height = 75;

        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(30, 41, 59);
        lblTitulo.Location = new Point(25, 20);
        lblTitulo.Text = "Pagos";

        lblBuscar.AutoSize = true;
        lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblBuscar.ForeColor = Color.FromArgb(71, 85, 105);
        lblBuscar.Location = new Point(430, 28);
        lblBuscar.Text = "Buscar";

        txtBuscar.Font = new Font("Segoe UI", 10F);
        txtBuscar.Location = new Point(485, 23);
        txtBuscar.Size = new Size(350, 30);

        panelSuperior.Controls.Add(lblTitulo);
        panelSuperior.Controls.Add(lblBuscar);
        panelSuperior.Controls.Add(txtBuscar);

        // =====================================================
        // PANEL FORMULARIO
        // =====================================================

        panelFormulario.BackColor = Color.White;
        panelFormulario.Dock = DockStyle.Left;
        panelFormulario.Padding = new Padding(20);
        panelFormulario.Size = new Size(340, 575);

        // CLIENTE
        lblCliente.AutoSize = true;
        lblCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblCliente.ForeColor = Color.FromArgb(30, 41, 59);
        lblCliente.Location = new Point(20, 25);
        lblCliente.Text = "Cliente";

        cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCliente.Font = new Font("Segoe UI", 10F);
        cmbCliente.Location = new Point(20, 50);
        cmbCliente.Size = new Size(280, 30);
        cmbCliente.SelectedIndexChanged += CmbCliente_SelectedIndexChanged;

        // INSCRIPCIÓN
        lblInscripcion.AutoSize = true;
        lblInscripcion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblInscripcion.ForeColor = Color.FromArgb(30, 41, 59);
        lblInscripcion.Location = new Point(20, 100);
        lblInscripcion.Text = "Inscripción";

        cmbInscripcion.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbInscripcion.Font = new Font("Segoe UI", 10F);
        cmbInscripcion.Location = new Point(20, 125);
        cmbInscripcion.Size = new Size(280, 30);

        // MONTO
        lblMonto.AutoSize = true;
        lblMonto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblMonto.ForeColor = Color.FromArgb(30, 41, 59);
        lblMonto.Location = new Point(20, 175);
        lblMonto.Text = "Monto";

        txtMonto.Font = new Font("Segoe UI", 10F);
        txtMonto.Location = new Point(20, 200);
        txtMonto.Size = new Size(280, 30);
        txtMonto.MaxLength = 10;

        // MÉTODO
        lblMetodo.AutoSize = true;
        lblMetodo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblMetodo.ForeColor = Color.FromArgb(30, 41, 59);
        lblMetodo.Location = new Point(20, 250);
        lblMetodo.Text = "Método de pago";

        cmbMetodo.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbMetodo.Font = new Font("Segoe UI", 10F);
        cmbMetodo.Location = new Point(20, 275);
        cmbMetodo.Size = new Size(280, 30);

        cmbMetodo.Items.AddRange(
        [
            "Efectivo",
            "Tarjeta",
            "Transferencia"
        ]);

        // =====================================================
        // BOTÓN NUEVO
        // =====================================================

        btnNuevo.BackColor = Color.White;
        btnNuevo.FlatStyle = FlatStyle.Flat;
        btnNuevo.FlatAppearance.BorderColor =
            Color.FromArgb(203, 213, 225);
        btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnNuevo.ForeColor = Color.FromArgb(30, 41, 59);
        btnNuevo.Location = new Point(20, 350);
        btnNuevo.Size = new Size(125, 40);
        btnNuevo.Text = "Nuevo";
        btnNuevo.Click += BtnNuevo_Click;

        // =====================================================
        // BOTÓN GUARDAR
        // =====================================================

        btnGuardar.BackColor = Color.FromArgb(37, 99, 235);
        btnGuardar.FlatStyle = FlatStyle.Flat;
        btnGuardar.FlatAppearance.BorderSize = 0;
        btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnGuardar.ForeColor = Color.White;
        btnGuardar.Location = new Point(175, 350);
        btnGuardar.Size = new Size(125, 40);
        btnGuardar.Text = "Guardar";
        btnGuardar.UseVisualStyleBackColor = false;
        btnGuardar.Click += BtnGuardar_Click;

        panelFormulario.Controls.Add(lblCliente);
        panelFormulario.Controls.Add(cmbCliente);
        panelFormulario.Controls.Add(lblInscripcion);
        panelFormulario.Controls.Add(cmbInscripcion);
        panelFormulario.Controls.Add(lblMonto);
        panelFormulario.Controls.Add(txtMonto);
        panelFormulario.Controls.Add(lblMetodo);
        panelFormulario.Controls.Add(cmbMetodo);
        panelFormulario.Controls.Add(btnNuevo);
        panelFormulario.Controls.Add(btnGuardar);

        // =====================================================
        // PANEL LISTA
        // =====================================================

        panelLista.BackColor = Color.FromArgb(245, 247, 250);
        panelLista.Dock = DockStyle.Fill;
        panelLista.Padding = new Padding(20);

        dgvPagos.BackgroundColor = Color.White;
        dgvPagos.BorderStyle = BorderStyle.None;
        dgvPagos.ColumnHeadersHeight = 40;
        dgvPagos.RowHeadersVisible = false;

        dgvPagos.AllowUserToAddRows = false;
        dgvPagos.AllowUserToDeleteRows = false;
        dgvPagos.AllowUserToResizeRows = false;

        dgvPagos.Dock = DockStyle.Fill;

        dgvPagos.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dgvPagos.MultiSelect = false;
        dgvPagos.ReadOnly = true;

        dgvPagos.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        panelLista.Controls.Add(dgvPagos);

        // =====================================================
        // AGREGAR PANELES
        // =====================================================

        Controls.Add(panelLista);
        Controls.Add(panelFormulario);
        Controls.Add(panelSuperior);

        ResumeLayout(false);
    }
}