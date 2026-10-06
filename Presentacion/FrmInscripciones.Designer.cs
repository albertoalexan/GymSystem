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
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(1150, 650);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "GymSystem - Inscripciones";

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
        lblTitulo.Text = "Inscripciones";

        lblBuscar.AutoSize = true;
        lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblBuscar.ForeColor = Color.FromArgb(71, 85, 105);
        lblBuscar.Location = new Point(600, 28);
        lblBuscar.Text = "Buscar";

        txtBuscar.Font = new Font("Segoe UI", 10F);
        txtBuscar.Location = new Point(655, 23);
        txtBuscar.Size = new Size(350, 30);
        txtBuscar.TextChanged += TxtBuscar_TextChanged;

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

        // PLAN
        lblPlan.AutoSize = true;
        lblPlan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblPlan.ForeColor = Color.FromArgb(30, 41, 59);
        lblPlan.Location = new Point(20, 100);
        lblPlan.Text = "Plan";

        cmbPlan.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbPlan.Font = new Font("Segoe UI", 10F);
        cmbPlan.Location = new Point(20, 125);
        cmbPlan.Size = new Size(280, 30);
        cmbPlan.SelectedIndexChanged += CmbPlan_SelectedIndexChanged;

        // FECHA INICIO
        lblFechaInicio.AutoSize = true;
        lblFechaInicio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblFechaInicio.ForeColor = Color.FromArgb(30, 41, 59);
        lblFechaInicio.Location = new Point(20, 175);
        lblFechaInicio.Text = "Fecha de inicio";

        dtpFechaInicio.Font = new Font("Segoe UI", 10F);
        dtpFechaInicio.Format = DateTimePickerFormat.Short;
        dtpFechaInicio.Location = new Point(20, 200);
        dtpFechaInicio.Size = new Size(280, 30);
        dtpFechaInicio.ValueChanged += DtpFechaInicio_ValueChanged;

        // FECHA FIN
        lblFechaFin.AutoSize = true;
        lblFechaFin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblFechaFin.ForeColor = Color.FromArgb(30, 41, 59);
        lblFechaFin.Location = new Point(20, 250);
        lblFechaFin.Text = "Fecha de vencimiento";

        dtpFechaFin.Font = new Font("Segoe UI", 10F);
        dtpFechaFin.Format = DateTimePickerFormat.Short;
        dtpFechaFin.Location = new Point(20, 275);
        dtpFechaFin.Size = new Size(280, 30);
        dtpFechaFin.Enabled = false;

        // =====================================================
        // BOTÓN NUEVO
        // =====================================================

        btnNuevo.BackColor = Color.White;
        btnNuevo.FlatStyle = FlatStyle.Flat;
        btnNuevo.FlatAppearance.BorderColor =
            Color.FromArgb(203, 213, 225);
        btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnNuevo.Location = new Point(20, 335);
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
        btnGuardar.Location = new Point(175, 335);
        btnGuardar.Size = new Size(125, 40);
        btnGuardar.Text = "Guardar";
        btnGuardar.Click += BtnGuardar_Click;

        // =====================================================
        // BOTÓN ELIMINAR
        // =====================================================

        btnEliminar.BackColor = Color.FromArgb(220, 38, 38);
        btnEliminar.FlatStyle = FlatStyle.Flat;
        btnEliminar.FlatAppearance.BorderSize = 0;
        btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnEliminar.ForeColor = Color.White;
        btnEliminar.Location = new Point(20, 390);
        btnEliminar.Size = new Size(280, 40);
        btnEliminar.Text = "Desactivar inscripción";
        btnEliminar.Click += BtnEliminar_Click;

        panelFormulario.Controls.Add(lblCliente);
        panelFormulario.Controls.Add(cmbCliente);
        panelFormulario.Controls.Add(lblPlan);
        panelFormulario.Controls.Add(cmbPlan);
        panelFormulario.Controls.Add(lblFechaInicio);
        panelFormulario.Controls.Add(dtpFechaInicio);
        panelFormulario.Controls.Add(lblFechaFin);
        panelFormulario.Controls.Add(dtpFechaFin);
        panelFormulario.Controls.Add(btnNuevo);
        panelFormulario.Controls.Add(btnGuardar);
        panelFormulario.Controls.Add(btnEliminar);

        // =====================================================
        // PANEL LISTA
        // =====================================================

        panelLista.BackColor = Color.FromArgb(245, 247, 250);
        panelLista.Dock = DockStyle.Fill;
        panelLista.Padding = new Padding(20);

        dgvInscripciones.BackgroundColor = Color.White;
        dgvInscripciones.BorderStyle = BorderStyle.None;
        dgvInscripciones.ColumnHeadersHeight = 40;
        dgvInscripciones.RowHeadersVisible = false;
        dgvInscripciones.AllowUserToAddRows = false;
        dgvInscripciones.AllowUserToDeleteRows = false;
        dgvInscripciones.Dock = DockStyle.Fill;
        dgvInscripciones.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
        dgvInscripciones.MultiSelect = false;
        dgvInscripciones.ReadOnly = true;
        dgvInscripciones.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        panelLista.Controls.Add(dgvInscripciones);

        // =====================================================
        // AGREGAR PANELES
        // =====================================================

        Controls.Add(panelLista);
        Controls.Add(panelFormulario);
        Controls.Add(panelSuperior);

        ResumeLayout(false);
    }
}