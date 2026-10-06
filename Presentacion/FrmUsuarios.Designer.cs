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
        // FORMULARIO
        // =====================================================

        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(1000, 600);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "GymSystem - Usuarios";

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
        lblTitulo.Text = "Usuarios";

        lblBuscar.AutoSize = true;
        lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblBuscar.ForeColor = Color.FromArgb(71, 85, 105);
        lblBuscar.Location = new Point(350, 18);
        lblBuscar.Text = "Buscar";

        txtBuscar.Font = new Font("Segoe UI", 10F);
        txtBuscar.Location = new Point(405, 13);
        txtBuscar.Size = new Size(300, 30);

        chkInactivos.AutoSize = true;
        chkInactivos.Font = new Font("Segoe UI", 9F);
        chkInactivos.ForeColor = Color.FromArgb(71, 85, 105);
        chkInactivos.Location = new Point(405, 47);
        chkInactivos.Text = "Mostrar inactivos";

        panelSuperior.Controls.Add(lblTitulo);
        panelSuperior.Controls.Add(lblBuscar);
        panelSuperior.Controls.Add(txtBuscar);
        panelSuperior.Controls.Add(chkInactivos);

        // =====================================================
        // PANEL LISTA
        // =====================================================

        panelLista.BackColor = Color.FromArgb(245, 247, 250);
        panelLista.Dock = DockStyle.Fill;
        panelLista.Padding = new Padding(20);

        // =====================================================
        // TABLA
        // =====================================================

        dgvUsuarios.BackgroundColor = Color.White;
        dgvUsuarios.BorderStyle = BorderStyle.None;
        dgvUsuarios.ColumnHeadersHeight = 40;
        dgvUsuarios.RowHeadersVisible = false;

        dgvUsuarios.AllowUserToAddRows = false;
        dgvUsuarios.AllowUserToDeleteRows = false;
        dgvUsuarios.AllowUserToResizeRows = false;

        dgvUsuarios.Dock = DockStyle.Fill;

        dgvUsuarios.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dgvUsuarios.MultiSelect = false;
        dgvUsuarios.ReadOnly = true;

        dgvUsuarios.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        panelLista.Controls.Add(dgvUsuarios);

        // =====================================================
        // BOTONES
        // =====================================================
        // Crear usuario
        btnCrearUsuario.BackColor = Color.FromArgb(37, 99, 235);
        btnCrearUsuario.FlatStyle = FlatStyle.Flat;
        btnCrearUsuario.FlatAppearance.BorderSize = 0;
        btnCrearUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCrearUsuario.ForeColor = Color.White;
        btnCrearUsuario.Location = new Point(20, 500);
        btnCrearUsuario.Size = new Size(150, 40);
        btnCrearUsuario.Text = "Crear usuario";
        btnCrearUsuario.Anchor =
            AnchorStyles.Left | AnchorStyles.Bottom;
        btnCrearUsuario.Click += BtnCrearUsuario_Click;

        // Desactivar
        btnDesactivar.BackColor = Color.FromArgb(220, 38, 38);
        btnDesactivar.FlatStyle = FlatStyle.Flat;
        btnDesactivar.FlatAppearance.BorderSize = 0;
        btnDesactivar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnDesactivar.ForeColor = Color.White;
        btnDesactivar.Location = new Point(185, 500);
        btnDesactivar.Size = new Size(150, 40);
        btnDesactivar.Text = "Desactivar";
        btnDesactivar.Anchor =
            AnchorStyles.Left | AnchorStyles.Bottom;
        btnDesactivar.Click += BtnDesactivar_Click;

        // Restaurar 
        btnRestaurar.BackColor = Color.FromArgb(22, 163, 74);
        btnRestaurar.FlatStyle = FlatStyle.Flat;
        btnRestaurar.FlatAppearance.BorderSize = 0;
        btnRestaurar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnRestaurar.ForeColor = Color.White;
        btnRestaurar.Location = new Point(350, 500);
        btnRestaurar.Size = new Size(150, 40);
        btnRestaurar.Anchor =
            AnchorStyles.Left | AnchorStyles.Bottom;
        btnRestaurar.Text = "Restaurar";
        btnRestaurar.Click += BtnRestaurar_Click;

        Controls.Add(btnCrearUsuario);
        Controls.Add(btnDesactivar);
        Controls.Add(btnRestaurar);


        // =====================================================
        // AGREGAR PANEL
        // =====================================================

        Controls.Add(panelLista);
        Controls.Add(panelSuperior);

        ResumeLayout(false);
    }
}