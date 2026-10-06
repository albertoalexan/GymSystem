namespace GymSystem;

partial class FrmLogin
{
    private System.ComponentModel.IContainer components = null;

    private Panel panelPrincipal;
    private Panel panelEncabezado;
    private Label lblLogo;
    private Label lblSubtitulo;
    private Label lblUsuario;
    private Label lblClave;
    private TextBox txtUsuario;
    private TextBox txtClave;
    private Button btnIniciarSesion;
    private Label lblInfo;

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
        panelEncabezado = new Panel();

        lblLogo = new Label();
        lblSubtitulo = new Label();
        lblUsuario = new Label();
        lblClave = new Label();

        txtUsuario = new TextBox();
        txtClave = new TextBox();

        btnIniciarSesion = new Button();

        lblInfo = new Label();

        SuspendLayout();
        panelPrincipal.SuspendLayout();
        panelEncabezado.SuspendLayout();

        // =====================================================
        // FORMULARIO
        // =====================================================

        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(241, 245, 249);
        ClientSize = new Size(520, 620);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "GymSystem - Iniciar sesión";

        // =====================================================
        // PANEL PRINCIPAL
        // =====================================================

        panelPrincipal.BackColor = Color.White;
        panelPrincipal.BorderStyle = BorderStyle.None;
        panelPrincipal.Location = new Point(85, 40);
        panelPrincipal.Size = new Size(350, 540);

        // =====================================================
        // ENCABEZADO
        // =====================================================

        panelEncabezado.BackColor = Color.FromArgb(15, 55, 75);
        panelEncabezado.Location = new Point(0, 0);
        panelEncabezado.Size = new Size(350, 145);

        // Logo
        lblLogo.AutoSize = true;
        lblLogo.Font = new Font(
            "Segoe UI",
            24F,
            FontStyle.Bold);

        lblLogo.ForeColor = Color.White;
        lblLogo.Location = new Point(63, 28);
        lblLogo.Text = "GYMSYSTEM";

        // Subtítulo
        lblSubtitulo.AutoSize = true;
        lblSubtitulo.Font = new Font(
            "Segoe UI",
            9.5F,
            FontStyle.Regular);

        lblSubtitulo.ForeColor =
            Color.FromArgb(203, 213, 225);

        lblSubtitulo.Location =
            new Point(67, 78);

        lblSubtitulo.Text =
            "Sistema de gestión de gimnasio";

        panelEncabezado.Controls.Add(lblLogo);
        panelEncabezado.Controls.Add(lblSubtitulo);

        // =====================================================
        // USUARIO
        // =====================================================

        lblUsuario.AutoSize = true;
        lblUsuario.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Bold);

        lblUsuario.ForeColor =
            Color.FromArgb(51, 65, 85);

        lblUsuario.Location =
            new Point(40, 180);

        lblUsuario.Text = "Usuario";

        txtUsuario.Font =
            new Font("Segoe UI", 11F);

        txtUsuario.Location =
            new Point(40, 208);

        txtUsuario.Size =
            new Size(270, 32);

        txtUsuario.BorderStyle =
            BorderStyle.FixedSingle;

        // =====================================================
        // CONTRASEÑA
        // =====================================================

        lblClave.AutoSize = true;
        lblClave.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Bold);

        lblClave.ForeColor =
            Color.FromArgb(51, 65, 85);

        lblClave.Location =
            new Point(40, 270);

        lblClave.Text = "Contraseña";

        txtClave.Font =
            new Font("Segoe UI", 11F);

        txtClave.Location =
            new Point(40, 298);

        txtClave.Size =
            new Size(270, 32);

        txtClave.BorderStyle =
            BorderStyle.FixedSingle;

        txtClave.UseSystemPasswordChar =
            true;

        // =====================================================
        // BOTÓN INICIAR SESIÓN
        // =====================================================

        btnIniciarSesion.BackColor =
            Color.FromArgb(37, 99, 235);

        btnIniciarSesion.FlatAppearance.BorderSize =
            0;

        btnIniciarSesion.FlatAppearance.MouseOverBackColor =
            Color.FromArgb(29, 78, 216);

        btnIniciarSesion.FlatAppearance.MouseDownBackColor =
            Color.FromArgb(30, 64, 175);

        btnIniciarSesion.FlatStyle =
            FlatStyle.Flat;

        btnIniciarSesion.Font =
            new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold);

        btnIniciarSesion.ForeColor =
            Color.White;

        btnIniciarSesion.Location =
            new Point(40, 365);

        btnIniciarSesion.Size =
            new Size(270, 45);

        btnIniciarSesion.Text =
            "Iniciar sesión";

        btnIniciarSesion.UseVisualStyleBackColor =
            false;

        btnIniciarSesion.Cursor =
            Cursors.Hand;

        btnIniciarSesion.Click +=
            BtnIniciarSesion_Click;

        // =====================================================
        // INFORMACIÓN
        // =====================================================

        lblInfo.AutoSize = false;

        lblInfo.Font =
            new Font(
                "Segoe UI",
                8.5F,
                FontStyle.Regular);

        lblInfo.ForeColor =
            Color.FromArgb(100, 116, 139);

        lblInfo.TextAlign =
            ContentAlignment.MiddleCenter;

        lblInfo.Location =
            new Point(35, 445);

        lblInfo.Size =
            new Size(280, 55);

        lblInfo.Text =
            "Ingrese sus credenciales para acceder al sistema.";

        // =====================================================
        // AGREGAR CONTROLES
        // =====================================================

        panelPrincipal.Controls.Add(panelEncabezado);

        panelPrincipal.Controls.Add(lblUsuario);
        panelPrincipal.Controls.Add(txtUsuario);

        panelPrincipal.Controls.Add(lblClave);
        panelPrincipal.Controls.Add(txtClave);

        panelPrincipal.Controls.Add(btnIniciarSesion);
        panelPrincipal.Controls.Add(lblInfo);

        Controls.Add(panelPrincipal);

        panelEncabezado.ResumeLayout(false);
        panelEncabezado.PerformLayout();

        panelPrincipal.ResumeLayout(false);
        panelPrincipal.PerformLayout();

        ResumeLayout(false);
    }
}
