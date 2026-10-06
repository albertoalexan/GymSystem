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

        // FORMULARIO
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(1100, 650);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "GymSystem - Planes";

        // PANEL SUPERIOR
        panelSuperior.BackColor = Color.White;
        panelSuperior.Dock = DockStyle.Top;
        panelSuperior.Height = 80;

        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(30, 41, 59);
        lblTitulo.Location = new Point(25, 20);
        lblTitulo.Text = "Planes";

        lblBuscar.AutoSize = true;
        lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblBuscar.ForeColor = Color.FromArgb(71, 85, 105);
        lblBuscar.Location = new Point(400, 18);
        lblBuscar.Text = "Buscar plan";

        txtBuscar.Font = new Font("Segoe UI", 10F);
        txtBuscar.Location = new Point(475, 13);
        txtBuscar.Size = new Size(300, 30);

        chkInactivos.AutoSize = true;
        chkInactivos.Font = new Font("Segoe UI", 9F);
        chkInactivos.ForeColor = Color.FromArgb(71, 85, 105);
        chkInactivos.Location = new Point(475, 48);
        chkInactivos.Text = "Mostrar inactivos";

        panelSuperior.Controls.Add(lblTitulo);
        panelSuperior.Controls.Add(lblBuscar);
        panelSuperior.Controls.Add(txtBuscar);
        panelSuperior.Controls.Add(chkInactivos);

        // PANEL FORMULARIO
        panelFormulario.BackColor = Color.White;
        panelFormulario.Dock = DockStyle.Left;
        panelFormulario.Padding = new Padding(20);
        panelFormulario.Size = new Size(330, 570);

        // NOMBRE
        lblNombre.AutoSize = true;
        lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblNombre.ForeColor = Color.FromArgb(30, 41, 59);
        lblNombre.Location = new Point(20, 25);
        lblNombre.Text = "Nombre del plan";

        txtNombre.Font = new Font("Segoe UI", 10F);
        txtNombre.Location = new Point(20, 50);
        txtNombre.Size = new Size(270, 30);
        txtNombre.MaxLength = 50;

        // DURACIÓN
        lblDuracion.AutoSize = true;
        lblDuracion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblDuracion.ForeColor = Color.FromArgb(30, 41, 59);
        lblDuracion.Location = new Point(20, 100);
        lblDuracion.Text = "Duración (días)";

        txtDuracion.Font = new Font("Segoe UI", 10F);
        txtDuracion.Location = new Point(20, 125);
        txtDuracion.Size = new Size(270, 30);
        txtDuracion.MaxLength = 4;

        // PRECIO
        lblPrecio.AutoSize = true;
        lblPrecio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblPrecio.ForeColor = Color.FromArgb(30, 41, 59);
        lblPrecio.Location = new Point(20, 175);
        lblPrecio.Text = "Precio";

        txtPrecio.Font = new Font("Segoe UI", 10F);
        txtPrecio.Location = new Point(20, 200);
        txtPrecio.Size = new Size(270, 30);
        txtPrecio.MaxLength = 10;

        // NUEVO
        btnNuevo.BackColor = Color.White;
        btnNuevo.FlatStyle = FlatStyle.Flat;
        btnNuevo.FlatAppearance.BorderColor =
            Color.FromArgb(203, 213, 225);
        btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnNuevo.ForeColor = Color.FromArgb(30, 41, 59);
        btnNuevo.Location = new Point(20, 275);
        btnNuevo.Size = new Size(125, 40);
        btnNuevo.Text = "Nuevo";
        btnNuevo.Click += BtnNuevo_Click;

        // GUARDAR
        btnGuardar.BackColor = Color.FromArgb(37, 99, 235);
        btnGuardar.FlatStyle = FlatStyle.Flat;
        btnGuardar.FlatAppearance.BorderSize = 0;
        btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnGuardar.ForeColor = Color.White;
        btnGuardar.Location = new Point(165, 275);
        btnGuardar.Size = new Size(125, 40);
        btnGuardar.Text = "Guardar";
        btnGuardar.Click += BtnGuardar_Click;

        // DESACTIVAR
        btnEliminar.BackColor = Color.FromArgb(220, 38, 38);
        btnEliminar.FlatStyle = FlatStyle.Flat;
        btnEliminar.FlatAppearance.BorderSize = 0;
        btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnEliminar.ForeColor = Color.White;
        btnEliminar.Location = new Point(20, 330);
        btnEliminar.Size = new Size(125, 40);
        btnEliminar.Text = "Desactivar";
        btnEliminar.Click += BtnEliminar_Click;

        // RESTAURAR
        btnRestaurar.BackColor = Color.FromArgb(22, 163, 74);
        btnRestaurar.FlatStyle = FlatStyle.Flat;
        btnRestaurar.FlatAppearance.BorderSize = 0;
        btnRestaurar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnRestaurar.ForeColor = Color.White;
        btnRestaurar.Location = new Point(165, 330);
        btnRestaurar.Size = new Size(125, 40);
        btnRestaurar.Text = "Restaurar";
        btnRestaurar.Click += BtnRestaurar_Click;

        panelFormulario.Controls.Add(lblNombre);
        panelFormulario.Controls.Add(txtNombre);

        panelFormulario.Controls.Add(lblDuracion);
        panelFormulario.Controls.Add(txtDuracion);

        panelFormulario.Controls.Add(lblPrecio);
        panelFormulario.Controls.Add(txtPrecio);

        panelFormulario.Controls.Add(btnNuevo);
        panelFormulario.Controls.Add(btnGuardar);
        panelFormulario.Controls.Add(btnEliminar);
        panelFormulario.Controls.Add(btnRestaurar);

        // PANEL LISTA
        panelLista.BackColor = Color.FromArgb(245, 247, 250);
        panelLista.Dock = DockStyle.Fill;
        panelLista.Padding = new Padding(20);

        // TABLA
        dgvPlanes.BackgroundColor = Color.White;
        dgvPlanes.BorderStyle = BorderStyle.None;
        dgvPlanes.ColumnHeadersHeight = 40;
        dgvPlanes.RowHeadersVisible = false;

        dgvPlanes.AllowUserToAddRows = false;
        dgvPlanes.AllowUserToDeleteRows = false;
        dgvPlanes.AllowUserToResizeRows = false;

        dgvPlanes.Dock = DockStyle.Fill;

        dgvPlanes.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dgvPlanes.MultiSelect = false;
        dgvPlanes.ReadOnly = true;

        dgvPlanes.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        panelLista.Controls.Add(dgvPlanes);

        Controls.Add(panelLista);
        Controls.Add(panelFormulario);
        Controls.Add(panelSuperior);

        ResumeLayout(false);
    }
}