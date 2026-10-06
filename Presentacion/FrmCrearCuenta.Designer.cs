namespace GymSystem;

partial class FrmCrearCuenta
{
    private System.ComponentModel.IContainer components = null;

    private Panel panelPrincipal;
    private Label lblTitulo;
    private Label lblSubtitulo;
    private Label lblNombre;
    private Label lblUsuario;
    private Label lblClave;
    private Label lblConfirmarClave;
    private Label lblRol;
    private ComboBox cmbRol;
    private TextBox txtNombre;
    private TextBox txtUsuario;
    private TextBox txtClave;
    private TextBox txtConfirmarClave;
    private Button btnCrear;
    private Button btnCancelar;

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

        panelPrincipal = new Panel();
        lblTitulo = new Label();
        lblSubtitulo = new Label();
        lblNombre = new Label();
        lblUsuario = new Label();
        lblClave = new Label();
        lblConfirmarClave = new Label();
        lblRol = new Label();
        cmbRol = new ComboBox();
        txtNombre = new TextBox();
        txtUsuario = new TextBox();
        txtClave = new TextBox();
        txtConfirmarClave = new TextBox();
        btnCrear = new Button();
        btnCancelar = new Button();

        SuspendLayout();
        panelPrincipal.SuspendLayout();

        // Formulario
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(520, 780);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "GymSystem - Crear cuenta";

        // Panel principal
        panelPrincipal.BackColor = Color.White;
        panelPrincipal.BorderStyle = BorderStyle.FixedSingle;
        panelPrincipal.Location = new Point(75, 35);
        panelPrincipal.Size = new Size(370, 700);

        // Título
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(30, 41, 59);
        lblTitulo.Location = new Point(95, 30);
        lblTitulo.Text = "CREAR CUENTA";

        // Subtítulo
        lblSubtitulo.AutoSize = true;
        lblSubtitulo.Font = new Font("Segoe UI", 9F);
        lblSubtitulo.ForeColor = Color.FromArgb(100, 116, 139);
        lblSubtitulo.Location = new Point(65, 72);
        lblSubtitulo.Text = "Registra un usuario para acceder al sistema";

        // Nombre
        lblNombre.AutoSize = true;
        lblNombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblNombre.ForeColor = Color.FromArgb(51, 65, 85);
        lblNombre.Location = new Point(40, 120);
        lblNombre.Text = "Nombre completo";

        txtNombre.Font = new Font("Segoe UI", 11F);
        txtNombre.Location = new Point(40, 147);
        txtNombre.Size = new Size(288, 32);
        txtNombre.BorderStyle = BorderStyle.FixedSingle;

        // Usuario
        lblUsuario.AutoSize = true;
        lblUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblUsuario.ForeColor = Color.FromArgb(51, 65, 85);
        lblUsuario.Location = new Point(40, 195);
        lblUsuario.Text = "Usuario";

        txtUsuario.Font = new Font("Segoe UI", 11F);
        txtUsuario.Location = new Point(40, 222);
        txtUsuario.Size = new Size(288, 32);
        txtUsuario.BorderStyle = BorderStyle.FixedSingle;

        // Contraseña
        lblClave.AutoSize = true;
        lblClave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblClave.ForeColor = Color.FromArgb(51, 65, 85);
        lblClave.Location = new Point(40, 270);
        lblClave.Text = "Contraseña";

        txtClave.Font = new Font("Segoe UI", 11F);
        txtClave.Location = new Point(40, 297);
        txtClave.Size = new Size(288, 32);
        txtClave.BorderStyle = BorderStyle.FixedSingle;
        txtClave.UseSystemPasswordChar = true;

        // Confirmar contraseña
        lblConfirmarClave.AutoSize = true;
        lblConfirmarClave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblConfirmarClave.ForeColor = Color.FromArgb(51, 65, 85);
        lblConfirmarClave.Location = new Point(40, 345);
        lblConfirmarClave.Text = "Confirmar contraseña";

        txtConfirmarClave.Font = new Font("Segoe UI", 11F);
        txtConfirmarClave.Location = new Point(40, 372);
        txtConfirmarClave.Size = new Size(288, 32);
        txtConfirmarClave.BorderStyle = BorderStyle.FixedSingle;
        txtConfirmarClave.UseSystemPasswordChar = true;
        
        // Rol
        lblRol.AutoSize = true;
        lblRol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblRol.ForeColor = Color.FromArgb(51, 65, 85);
        lblRol.Location = new Point(40, 420);
        lblRol.Text = "Rol";

        cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbRol.Font = new Font("Segoe UI", 11F);
        cmbRol.Location = new Point(40, 447);
        cmbRol.Size = new Size(288, 32);

        cmbRol.Items.Add("Empleado");
        cmbRol.Items.Add("Administrador");

        cmbRol.SelectedIndex = 0; 

        // Crear
        btnCrear.BackColor = Color.FromArgb(37, 99, 235);
        btnCrear.FlatAppearance.BorderSize = 0;
        btnCrear.FlatStyle = FlatStyle.Flat;
        btnCrear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnCrear.ForeColor = Color.White;
        btnCrear.Location = new Point(40, 500);
        btnCrear.Size = new Size(288, 42);
        btnCrear.Text = "Crear cuenta";
        btnCrear.UseVisualStyleBackColor = false;
        btnCrear.Click += BtnCrear_Click;

        // Cancelar
        btnCancelar.BackColor = Color.White;
        btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
        btnCancelar.FlatStyle = FlatStyle.Flat;
        btnCancelar.Font = new Font("Segoe UI", 10F);
        btnCancelar.ForeColor = Color.FromArgb(71, 85, 105);
        btnCancelar.Location = new Point(40, 555);
        btnCancelar.Size = new Size(288, 40);
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = true;
        btnCancelar.Click += BtnCancelar_Click;

        panelPrincipal.Controls.Add(lblTitulo);
        panelPrincipal.Controls.Add(lblSubtitulo);
        panelPrincipal.Controls.Add(lblNombre);
        panelPrincipal.Controls.Add(txtNombre);
        panelPrincipal.Controls.Add(lblUsuario);
        panelPrincipal.Controls.Add(txtUsuario);
        panelPrincipal.Controls.Add(lblClave);
        panelPrincipal.Controls.Add(txtClave);
        panelPrincipal.Controls.Add(lblConfirmarClave);
        panelPrincipal.Controls.Add(txtConfirmarClave);
        panelPrincipal.Controls.Add(lblRol);
        panelPrincipal.Controls.Add(cmbRol);
        panelPrincipal.Controls.Add(btnCrear);
        panelPrincipal.Controls.Add(btnCancelar);

        Controls.Add(panelPrincipal);

        panelPrincipal.ResumeLayout(false);
        panelPrincipal.PerformLayout();
        ResumeLayout(false);
    }
}