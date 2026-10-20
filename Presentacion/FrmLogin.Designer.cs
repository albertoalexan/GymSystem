namespace GymSystem;

partial class FrmLogin
{
    private System.ComponentModel.IContainer components = null!;

    private Panel panelPrincipal = null!;
    private Panel panelMarca = null!;
    private Panel panelAcceso = null!;
    private Panel panelLogo = null!;
    private Panel panelAcento = null!;
    private Panel panelCampoUsuario = null!;
    private Panel panelCampoClave = null!;

    private Label lblLogoMonograma = null!;
    private Label lblLogo = null!;
    private Label lblSubtitulo = null!;
    private Label lblMensajeMarca = null!;
    private Label lblDescripcionMarca = null!;
    private Label lblPieMarca = null!;

    private Label lblEyebrow = null!;
    private Label lblTituloAcceso = null!;
    private Label lblDescripcionAcceso = null!;
    private Label lblUsuario = null!;
    private Label lblClave = null!;
    private Label lblInfo = null!;
    private Label lblPieAcceso = null!;

    private TextBox txtUsuario = null!;
    private TextBox txtClave = null!;

    private CheckBox chkMostrarClave = null!;

    private Button btnIniciarSesion = null!;

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
        panelMarca = new Panel();
        panelAcceso = new Panel();

        panelLogo = new Panel();
        panelAcento = new Panel();

        panelCampoUsuario = new Panel();
        panelCampoClave = new Panel();

        lblLogoMonograma = new Label();
        lblLogo = new Label();
        lblSubtitulo = new Label();
        lblMensajeMarca = new Label();
        lblDescripcionMarca = new Label();
        lblPieMarca = new Label();

        lblEyebrow = new Label();
        lblTituloAcceso = new Label();
        lblDescripcionAcceso = new Label();
        lblUsuario = new Label();
        lblClave = new Label();
        lblInfo = new Label();
        lblPieAcceso = new Label();

        txtUsuario = new TextBox();
        txtClave = new TextBox();

        chkMostrarClave = new CheckBox();

        btnIniciarSesion = new Button();

        SuspendLayout();

        // =====================================================
        // FORMULARIO PRINCIPAL
        // =====================================================

        AutoScaleMode = AutoScaleMode.Font;

        BackColor = Color.White;

        ClientSize = new Size(1020, 680);

        FormBorderStyle = FormBorderStyle.FixedSingle;

        MaximizeBox = false;
        MinimizeBox = true;

        StartPosition = FormStartPosition.CenterScreen;

        Text = "GymSystem | Iniciar sesión";

        Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Regular);

        // =====================================================
        // CONTENEDOR PRINCIPAL
        // =====================================================

        panelPrincipal.Dock = DockStyle.Fill;

        panelPrincipal.BackColor = Color.White;

        panelPrincipal.Location = new Point(0, 0);

        panelPrincipal.Size = new Size(1020, 680);

        // =====================================================
        // PANEL DE IDENTIDAD VISUAL
        // =====================================================

        panelMarca.BackColor = Color.FromArgb(15, 23, 42);

        panelMarca.Location = new Point(0, 0);

        panelMarca.Size = new Size(390, 680);

        // Marca gráfica

        panelLogo.BackColor = Color.FromArgb(22, 163, 74);

        panelLogo.Location = new Point(48, 55);

        panelLogo.Size = new Size(72, 72);

        lblLogoMonograma.Dock = DockStyle.Fill;

        lblLogoMonograma.Font = new Font(
            "Segoe UI",
            21F,
            FontStyle.Bold);

        lblLogoMonograma.ForeColor = Color.White;

        lblLogoMonograma.Text = "GS";

        lblLogoMonograma.TextAlign =
            ContentAlignment.MiddleCenter;

        panelLogo.Controls.Add(lblLogoMonograma);

        // Nombre del sistema

        lblLogo.AutoSize = false;

        lblLogo.Font = new Font(
            "Segoe UI",
            27F,
            FontStyle.Bold);

        lblLogo.ForeColor = Color.White;

        lblLogo.Location = new Point(48, 156);

        lblLogo.Size = new Size(300, 48);

        lblLogo.Text = "GYMSYSTEM";

        lblLogo.TextAlign = ContentAlignment.MiddleLeft;

        // Subtítulo

        lblSubtitulo.AutoSize = false;

        lblSubtitulo.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Bold);

        lblSubtitulo.ForeColor = Color.FromArgb(74, 222, 128);

        lblSubtitulo.Location = new Point(50, 211);

        lblSubtitulo.Size = new Size(300, 30);

        lblSubtitulo.Text = "GESTIÓN INTELIGENTE DE GIMNASIO";

        // Línea decorativa

        panelAcento.BackColor = Color.FromArgb(34, 197, 94);

        panelAcento.Location = new Point(50, 280);

        panelAcento.Size = new Size(65, 4);

        // Mensaje principal

        lblMensajeMarca.AutoSize = false;

        lblMensajeMarca.Font = new Font(
            "Segoe UI",
            24F,
            FontStyle.Bold);

        lblMensajeMarca.ForeColor = Color.White;

        lblMensajeMarca.Location = new Point(48, 316);

        lblMensajeMarca.Size = new Size(315, 100);

        lblMensajeMarca.Text = "Todo tu gimnasio,`n en un solo lugar.".Replace("`n", Environment.NewLine);

        // Descripción

        lblDescripcionMarca.AutoSize = false;

        lblDescripcionMarca.Font = new Font(
            "Segoe UI",
            11F,
            FontStyle.Regular);

        lblDescripcionMarca.ForeColor =
            Color.FromArgb(203, 213, 225);

        lblDescripcionMarca.Location = new Point(50, 432);

        lblDescripcionMarca.Size = new Size(295, 85);

        lblDescripcionMarca.Text =
            "Administra clientes, planes, inscripciones y pagos desde una sola aplicación.";

        // Pie del panel izquierdo

        lblPieMarca.AutoSize = false;

        lblPieMarca.Font = new Font(
            "Segoe UI",
            8F,
            FontStyle.Bold);

        lblPieMarca.ForeColor =
            Color.FromArgb(148, 163, 184);

        lblPieMarca.Location = new Point(48, 625);

        lblPieMarca.Size = new Size(320, 24);

        lblPieMarca.Text = "CONTROL  |  ORGANIZACIÓN  |  RESULTADOS";

        // Agregar componentes al panel izquierdo

        panelMarca.Controls.Add(panelLogo);
        panelMarca.Controls.Add(lblLogo);
        panelMarca.Controls.Add(lblSubtitulo);
        panelMarca.Controls.Add(panelAcento);
        panelMarca.Controls.Add(lblMensajeMarca);
        panelMarca.Controls.Add(lblDescripcionMarca);
        panelMarca.Controls.Add(lblPieMarca);

        // =====================================================
        // PANEL DE ACCESO
        // =====================================================

        panelAcceso.BackColor = Color.White;

        panelAcceso.Location = new Point(390, 0);

        panelAcceso.Size = new Size(630, 680);

        // Texto superior

        lblEyebrow.AutoSize = false;

        lblEyebrow.Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Bold);

        lblEyebrow.ForeColor = Color.FromArgb(22, 163, 74);

        lblEyebrow.Location = new Point(72, 76);

        lblEyebrow.Size = new Size(455, 23);

        lblEyebrow.Text = "BIENVENIDO DE NUEVO";

        // Título

        lblTituloAcceso.AutoSize = false;

        lblTituloAcceso.Font = new Font(
            "Segoe UI",
            28F,
            FontStyle.Bold);

        lblTituloAcceso.ForeColor = Color.FromArgb(15, 23, 42);

        lblTituloAcceso.Location = new Point(69, 111);

        lblTituloAcceso.Size = new Size(465, 49);

        lblTituloAcceso.Text = "Iniciar sesión";

        // Descripción

        lblDescripcionAcceso.AutoSize = false;

        lblDescripcionAcceso.Font = new Font(
            "Segoe UI",
            11F,
            FontStyle.Regular);

        lblDescripcionAcceso.ForeColor =
            Color.FromArgb(100, 116, 139);

        lblDescripcionAcceso.Location = new Point(72, 169);

        lblDescripcionAcceso.Size = new Size(455, 35);

        lblDescripcionAcceso.Text =
            "Ingresa tus credenciales para continuar.";

        // =====================================================
        // CAMPO USUARIO
        // =====================================================

        lblUsuario.AutoSize = false;

        lblUsuario.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Bold);

        lblUsuario.ForeColor = Color.FromArgb(51, 65, 85);

        lblUsuario.Location = new Point(72, 226);

        lblUsuario.Size = new Size(455, 24);

        lblUsuario.Text = "Usuario";

        panelCampoUsuario.BackColor =
            Color.FromArgb(248, 250, 252);

        panelCampoUsuario.BorderStyle =
            BorderStyle.FixedSingle;

        panelCampoUsuario.Location = new Point(72, 254);

        panelCampoUsuario.Size = new Size(455, 45);

        txtUsuario.BorderStyle = BorderStyle.None;

        txtUsuario.Font = new Font(
            "Segoe UI",
            11F,
            FontStyle.Regular);

        txtUsuario.BackColor =
            Color.FromArgb(248, 250, 252);

        txtUsuario.ForeColor = Color.FromArgb(15, 23, 42);

        txtUsuario.Location = new Point(11, 10);

        txtUsuario.Size = new Size(429, 25);

        txtUsuario.PlaceholderText = "Escribe tu usuario";

        txtUsuario.TabIndex = 0;

        panelCampoUsuario.Controls.Add(txtUsuario);

        // =====================================================
        // CAMPO CONTRASEÑA
        // =====================================================

        lblClave.AutoSize = false;

        lblClave.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Bold);

        lblClave.ForeColor = Color.FromArgb(51, 65, 85);

        lblClave.Location = new Point(72, 319);

        lblClave.Size = new Size(455, 24);

        lblClave.Text = "Contraseña";

        panelCampoClave.BackColor =
            Color.FromArgb(248, 250, 252);

        panelCampoClave.BorderStyle =
            BorderStyle.FixedSingle;

        panelCampoClave.Location = new Point(72, 347);

        panelCampoClave.Size = new Size(455, 45);

        txtClave.BorderStyle = BorderStyle.None;

        txtClave.Font = new Font(
            "Segoe UI",
            11F,
            FontStyle.Regular);

        txtClave.BackColor =
            Color.FromArgb(248, 250, 252);

        txtClave.ForeColor = Color.FromArgb(15, 23, 42);

        txtClave.Location = new Point(11, 10);

        txtClave.Size = new Size(429, 25);

        txtClave.PlaceholderText = "Escribe tu contraseña";

        txtClave.UseSystemPasswordChar = true;

        txtClave.TabIndex = 1;

        panelCampoClave.Controls.Add(txtClave);

        // =====================================================
        // MOSTRAR / OCULTAR CONTRASEÑA
        // =====================================================

        chkMostrarClave.AutoSize = true;

        chkMostrarClave.BackColor = Color.White;

        chkMostrarClave.Cursor = Cursors.Hand;

        chkMostrarClave.Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Regular);

        chkMostrarClave.ForeColor =
            Color.FromArgb(71, 85, 105);

        chkMostrarClave.Location = new Point(72, 407);

        chkMostrarClave.Size = new Size(180, 24);

        chkMostrarClave.Text = "Mostrar contraseña";

        chkMostrarClave.UseVisualStyleBackColor = false;

        chkMostrarClave.CheckedChanged +=
            ChkMostrarClave_CheckedChanged;

        chkMostrarClave.TabIndex = 2;

        // =====================================================
        // BOTÓN PRINCIPAL
        // =====================================================

        btnIniciarSesion.BackColor =
            Color.FromArgb(22, 163, 74);

        btnIniciarSesion.Cursor = Cursors.Hand;

        btnIniciarSesion.FlatAppearance.BorderSize = 0;

        btnIniciarSesion.FlatAppearance.MouseOverBackColor =
            Color.FromArgb(21, 128, 61);

        btnIniciarSesion.FlatAppearance.MouseDownBackColor =
            Color.FromArgb(22, 101, 52);

        btnIniciarSesion.FlatStyle = FlatStyle.Flat;

        btnIniciarSesion.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Bold);

        btnIniciarSesion.ForeColor = Color.White;

        btnIniciarSesion.Location = new Point(72, 451);

        btnIniciarSesion.Size = new Size(455, 50);

        btnIniciarSesion.Text = "Iniciar sesión";

        btnIniciarSesion.UseVisualStyleBackColor = false;

        btnIniciarSesion.Click += BtnIniciarSesion_Click;

        btnIniciarSesion.TabIndex = 3;

        // =====================================================
        // INFORMACIÓN
        // =====================================================

        lblInfo.AutoSize = false;

        lblInfo.Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Regular);

        lblInfo.ForeColor = Color.FromArgb(100, 116, 139);

        lblInfo.Location = new Point(72, 522);

        lblInfo.Size = new Size(455, 44);

        lblInfo.Text =
            "Utiliza tus credenciales registradas para acceder al sistema.";

        lblInfo.TextAlign = ContentAlignment.MiddleCenter;

        // Pie inferior

        lblPieAcceso.AutoSize = false;

        lblPieAcceso.Font = new Font(
            "Segoe UI",
            8F,
            FontStyle.Regular);

        lblPieAcceso.ForeColor =
            Color.FromArgb(148, 163, 184);

        lblPieAcceso.Location = new Point(72, 624);

        lblPieAcceso.Size = new Size(455, 23);

        lblPieAcceso.Text = "GYMSYSTEM  |  SISTEMA DE GESTIÓN";

        lblPieAcceso.TextAlign = ContentAlignment.MiddleCenter;

        // =====================================================
        // AGREGAR CONTROLES AL PANEL DE ACCESO
        // =====================================================

        panelAcceso.Controls.Add(lblEyebrow);
        panelAcceso.Controls.Add(lblTituloAcceso);
        panelAcceso.Controls.Add(lblDescripcionAcceso);

        panelAcceso.Controls.Add(lblUsuario);
        panelAcceso.Controls.Add(panelCampoUsuario);

        panelAcceso.Controls.Add(lblClave);
        panelAcceso.Controls.Add(panelCampoClave);

        panelAcceso.Controls.Add(chkMostrarClave);
        panelAcceso.Controls.Add(btnIniciarSesion);

        panelAcceso.Controls.Add(lblInfo);
        panelAcceso.Controls.Add(lblPieAcceso);

        // =====================================================
        // ARMAR FORMULARIO
        // =====================================================

        panelPrincipal.Controls.Add(panelAcceso);
        panelPrincipal.Controls.Add(panelMarca);

        Controls.Add(panelPrincipal);

        panelLogo.ResumeLayout(false);

        panelCampoUsuario.ResumeLayout(false);
        panelCampoUsuario.PerformLayout();

        panelCampoClave.ResumeLayout(false);
        panelCampoClave.PerformLayout();

        panelMarca.ResumeLayout(false);
        panelAcceso.ResumeLayout(false);

        panelPrincipal.ResumeLayout(false);

        ResumeLayout(false);
    }
}