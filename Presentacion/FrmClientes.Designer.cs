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
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(1150, 680);
        MinimumSize = new Size(1000, 600);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "GymSystem - Clientes";

        // =====================================================
        // PANEL SUPERIOR
        // =====================================================

        panelSuperior.BackColor = Color.White;
        panelSuperior.Dock = DockStyle.Top;
        panelSuperior.Height = 80;

        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(30, 41, 59);
        lblTitulo.Location = new Point(25, 20);
        lblTitulo.Text = "Clientes";

        lblBuscar.AutoSize = true;
        lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblBuscar.ForeColor = Color.FromArgb(71, 85, 105);
        lblBuscar.Location = new Point(400, 17);
        lblBuscar.Text = "Buscar cliente";

        txtBuscar.Font = new Font("Segoe UI", 10F);
        txtBuscar.Location = new Point(400, 40);
        txtBuscar.Size = new Size(350, 30);

        chkInactivos.AutoSize = true;
        chkInactivos.Font = new Font("Segoe UI", 9F);
        chkInactivos.ForeColor = Color.FromArgb(71, 85, 105);
        chkInactivos.Location = new Point(775, 43);
        chkInactivos.Text = "Mostrar inactivos";
        chkInactivos.Checked = false;

        panelSuperior.Controls.Add(lblTitulo);
        panelSuperior.Controls.Add(lblBuscar);
        panelSuperior.Controls.Add(txtBuscar);
        panelSuperior.Controls.Add(chkInactivos);

        // =====================================================
        // PANEL FORMULARIO
        // =====================================================

        panelFormulario.BackColor = Color.White;
        panelFormulario.Dock = DockStyle.Left;
        panelFormulario.Padding = new Padding(20);
        panelFormulario.Size = new Size(350, 600);

        // Nombre
        lblNombre.AutoSize = true;
        lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblNombre.ForeColor = Color.FromArgb(51, 65, 85);
        lblNombre.Location = new Point(20, 20);
        lblNombre.Text = "Nombre completo";

        txtNombre.Font = new Font("Segoe UI", 10F);
        txtNombre.Location = new Point(20, 45);
        txtNombre.Size = new Size(290, 30);

        // Cédula
        lblCedula.AutoSize = true;
        lblCedula.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblCedula.ForeColor = Color.FromArgb(51, 65, 85);
        lblCedula.Location = new Point(20, 85);
        lblCedula.Text = "Número de cédula";

        txtCedula.Font = new Font("Segoe UI", 10F);
        txtCedula.Location = new Point(20, 110);
        txtCedula.Size = new Size(290, 30);

        // Correo
        lblCorreo.AutoSize = true;
        lblCorreo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblCorreo.ForeColor = Color.FromArgb(51, 65, 85);
        lblCorreo.Location = new Point(20, 150);
        lblCorreo.Text = "Correo electrónico";

        txtCorreo.Font = new Font("Segoe UI", 10F);
        txtCorreo.Location = new Point(20, 175);
        txtCorreo.Size = new Size(290, 30);

        // Teléfono
        lblTelefono.AutoSize = true;
        lblTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblTelefono.ForeColor = Color.FromArgb(51, 65, 85);
        lblTelefono.Location = new Point(20, 215);
        lblTelefono.Text = "Teléfono";

        txtTelefono.Font = new Font("Segoe UI", 10F);
        txtTelefono.Location = new Point(20, 240);
        txtTelefono.Size = new Size(290, 30);

        // Dirección
        lblDireccion.AutoSize = true;
        lblDireccion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblDireccion.ForeColor = Color.FromArgb(51, 65, 85);
        lblDireccion.Location = new Point(20, 280);
        lblDireccion.Text = "Dirección";

        txtDireccion.Font = new Font("Segoe UI", 10F);
        txtDireccion.Location = new Point(20, 305);
        txtDireccion.Multiline = true;
        txtDireccion.Size = new Size(290, 55);

        // Fecha de nacimiento
        lblFechaNacimiento.AutoSize = true;
        lblFechaNacimiento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblFechaNacimiento.ForeColor = Color.FromArgb(51, 65, 85);
        lblFechaNacimiento.Location = new Point(20, 375);
        lblFechaNacimiento.Text = "Fecha de nacimiento";

        dtpFechaNacimiento.Font = new Font("Segoe UI", 10F);
        dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
        dtpFechaNacimiento.Location = new Point(20, 400);
        dtpFechaNacimiento.Size = new Size(170, 30);
        dtpFechaNacimiento.MaxDate = DateTime.Today;
        dtpFechaNacimiento.Value = DateTime.Today;

        // =====================================================
        // BOTONES
        // =====================================================

        btnNuevo.BackColor = Color.White;
        btnNuevo.FlatStyle = FlatStyle.Flat;
        btnNuevo.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnNuevo.ForeColor = Color.FromArgb(51, 65, 85);
        btnNuevo.Location = new Point(20, 465);
        btnNuevo.Size = new Size(135, 40);
        btnNuevo.Text = "Nuevo";
        btnNuevo.UseVisualStyleBackColor = true;
        btnNuevo.Click += BtnNuevo_Click;

        btnGuardar.BackColor = Color.FromArgb(37, 99, 235);
        btnGuardar.FlatStyle = FlatStyle.Flat;
        btnGuardar.FlatAppearance.BorderSize = 0;
        btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnGuardar.ForeColor = Color.White;
        btnGuardar.Location = new Point(175, 465);
        btnGuardar.Size = new Size(135, 40);
        btnGuardar.Text = "Guardar";
        btnGuardar.UseVisualStyleBackColor = false;
        btnGuardar.Click += BtnGuardar_Click;

        btnEliminar.BackColor = Color.FromArgb(220, 38, 38);
        btnEliminar.FlatStyle = FlatStyle.Flat;
        btnEliminar.FlatAppearance.BorderSize = 0;
        btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnEliminar.ForeColor = Color.White;
        btnEliminar.Location = new Point(20, 520);
        btnEliminar.Size = new Size(135, 40);
        btnEliminar.Text = "Desactivar";
        btnEliminar.UseVisualStyleBackColor = false;
        btnEliminar.Click += BtnEliminar_Click;

        btnRestaurar.BackColor = Color.FromArgb(22, 163, 74);
        btnRestaurar.FlatStyle = FlatStyle.Flat;
        btnRestaurar.FlatAppearance.BorderSize = 0;
        btnRestaurar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnRestaurar.ForeColor = Color.White;
        btnRestaurar.Location = new Point(175, 520);
        btnRestaurar.Size = new Size(135, 40);
        btnRestaurar.Text = "Restaurar";
        btnRestaurar.UseVisualStyleBackColor = false;
        btnRestaurar.Click += BtnRestaurar_Click;

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
        // PANEL LISTA
        // =====================================================

        panelLista.BackColor = Color.FromArgb(245, 247, 250);
        panelLista.Dock = DockStyle.Fill;
        panelLista.Padding = new Padding(20);

        dgvClientes.BackgroundColor = Color.White;
        dgvClientes.BorderStyle = BorderStyle.None;
        dgvClientes.ColumnHeadersHeight = 40;
        dgvClientes.RowHeadersVisible = false;

        dgvClientes.AllowUserToAddRows = false;
        dgvClientes.AllowUserToDeleteRows = false;
        dgvClientes.AllowUserToResizeRows = false;

        dgvClientes.Dock = DockStyle.Fill;

        dgvClientes.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dgvClientes.MultiSelect = false;
        dgvClientes.ReadOnly = true;
        dgvClientes.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        panelLista.Controls.Add(dgvClientes);

        // =====================================================
        // AGREGAR PANELES
        // =====================================================

        Controls.Add(panelLista);
        Controls.Add(panelFormulario);
        Controls.Add(panelSuperior);

        ResumeLayout(false);
    }
}