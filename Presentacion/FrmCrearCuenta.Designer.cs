namespace GymSystem;

partial class FrmCrearCuenta
{
    private System.ComponentModel.IContainer components = null!;

    private Panel panelPrincipal = null!;
    private Panel panelMarca = null!;
    private Panel panelAcceso = null!;

    private Label lblTitulo = null!;
    private Label lblSubtitulo = null!;

    private Label lblNombre = null!;
    private Label lblUsuario = null!;
    private Label lblClave = null!;
    private Label lblConfirmarClave = null!;
    private Label lblRol = null!;

    private ComboBox cmbRol = null!;

    private TextBox txtNombre = null!;
    private TextBox txtUsuario = null!;
    private TextBox txtClave = null!;
    private TextBox txtConfirmarClave = null!;

    private CheckBox chkMostrarClaves = null!;

    private Button btnCrear = null!;
    private Button btnCancelar = null!;

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

        chkMostrarClaves = new CheckBox();

        btnCrear = new Button();
        btnCancelar = new Button();

        SuspendLayout();

        // =====================================================
        // FORMULARIO PRINCIPAL
        // =====================================================

        AutoScaleMode = AutoScaleMode.Font;

        BackColor = Color.FromArgb(246, 248, 252);

        ClientSize = new Size(880, 760);

        FormBorderStyle = FormBorderStyle.FixedSingle;

        MaximizeBox = false;
        MinimizeBox = false;

        StartPosition = FormStartPosition.CenterScreen;

        Text = "GymSystem | Crear cuenta";

        Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Regular);

        // =====================================================
        // CONTENEDOR
        // =====================================================

        panelPrincipal.Dock = DockStyle.Fill;

        panelPrincipal.BackColor = Color.White;

        panelPrincipal.Controls.Clear();

        // =====================================================
        // PANEL DE IDENTIDAD VISUAL
        // =====================================================

        panelMarca.BackColor = Color.FromArgb(15, 23, 42);

        panelMarca.Location = new Point(0, 0);

        panelMarca.Size = new Size(295, 760);

        // Insignia GS

        Panel panelLogo = new Panel();

        panelLogo.BackColor = Color.FromArgb(22, 163, 74);

        panelLogo.Location = new Point(32, 42);

        panelLogo.Size = new Size(62, 62);

        Label lblSigla = new Label();

        lblSigla.Dock = DockStyle.Fill;

        lblSigla.Font = new Font(
            "Segoe UI",
            18F,
            FontStyle.Bold);

        lblSigla.ForeColor = Color.White;

        lblSigla.Text = "GS";

        lblSigla.TextAlign = ContentAlignment.MiddleCenter;

        panelLogo.Controls.Add(lblSigla);

        // Nombre del sistema

        Label lblMarca = new Label();

        lblMarca.AutoSize = false;

        lblMarca.Font = new Font(
            "Segoe UI",
            22F,
            FontStyle.Bold);

        lblMarca.ForeColor = Color.White;

        lblMarca.Location = new Point(31, 132);

        lblMarca.Size = new Size(245, 40);

        lblMarca.Text = "GYMSYSTEM";

        // Descripción de la marca

        Label lblMarcaSubtitulo = new Label();

        lblMarcaSubtitulo.AutoSize = false;

        lblMarcaSubtitulo.Font = new Font(
            "Segoe UI",
            8.5F,
            FontStyle.Bold);

        lblMarcaSubtitulo.ForeColor = Color.FromArgb(74, 222, 128);

        lblMarcaSubtitulo.Location = new Point(33, 174);

        lblMarcaSubtitulo.Size = new Size(245, 24);

        lblMarcaSubtitulo.Text = "ADMINISTRACIÓN DE ACCESO";

        // Línea de acento

        Panel panelAcento = new Panel();

        panelAcento.BackColor = Color.FromArgb(34, 197, 94);

        panelAcento.Location = new Point(33, 224);

        panelAcento.Size = new Size(60, 4);

        // Mensaje principal

        Label lblMensajeMarca = new Label();

        lblMensajeMarca.AutoSize = false;

        lblMensajeMarca.Font = new Font(
            "Segoe UI",
            22F,
            FontStyle.Bold);

        lblMensajeMarca.ForeColor = Color.White;

        lblMensajeMarca.Location = new Point(31, 270);

        lblMensajeMarca.Size = new Size(245, 110);

        lblMensajeMarca.Text =
            "Control seguro para tu gimnasio.";

        // Descripción

        Label lblDescripcionMarca = new Label();

        lblDescripcionMarca.AutoSize = false;

        lblDescripcionMarca.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Regular);

        lblDescripcionMarca.ForeColor = Color.FromArgb(203, 213, 225);

        lblDescripcionMarca.Location = new Point(33, 395);

        lblDescripcionMarca.Size = new Size(230, 110);

        lblDescripcionMarca.Text =
            "Crea cuentas para que el personal autorizado pueda acceder al sistema y gestionar sus funciones.";

        // Pie del panel

        Label lblPieMarca = new Label();

        lblPieMarca.AutoSize = false;

        lblPieMarca.Font = new Font(
            "Segoe UI",
            8F,
            FontStyle.Bold);

        lblPieMarca.ForeColor = Color.FromArgb(148, 163, 184);

        lblPieMarca.Location = new Point(30, 700);

        lblPieMarca.Size = new Size(245, 24);

        lblPieMarca.Text = "GYMSYSTEM  |  ACCESO SEGURO";

        panelMarca.Controls.Add(panelLogo);
        panelMarca.Controls.Add(lblMarca);
        panelMarca.Controls.Add(lblMarcaSubtitulo);
        panelMarca.Controls.Add(panelAcento);
        panelMarca.Controls.Add(lblMensajeMarca);
        panelMarca.Controls.Add(lblDescripcionMarca);
        panelMarca.Controls.Add(lblPieMarca);

        // =====================================================
        // PANEL DEL FORMULARIO
        // =====================================================

        panelAcceso.BackColor = Color.White;

        panelAcceso.Location = new Point(295, 0);

        panelAcceso.Size = new Size(585, 760);

        // Etiqueta superior

        Label lblEyebrow = new Label();

        lblEyebrow.AutoSize = false;

        lblEyebrow.Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Bold);

        lblEyebrow.ForeColor = Color.FromArgb(22, 163, 74);

        lblEyebrow.Location = new Point(42, 29);

        lblEyebrow.Size = new Size(490, 23);

        lblEyebrow.Text = "ADMINISTRACIÓN DE USUARIOS";

        // Título

        lblTitulo.AutoSize = false;

        lblTitulo.Font = new Font(
            "Segoe UI",
            25F,
            FontStyle.Bold);

        lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);

        lblTitulo.Location = new Point(40, 55);

        lblTitulo.Size = new Size(495, 45);

        lblTitulo.Text = "Crear cuenta";

        // Subtítulo

        lblSubtitulo.AutoSize = false;

        lblSubtitulo.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Regular);

        lblSubtitulo.ForeColor = Color.FromArgb(100, 116, 139);

        lblSubtitulo.Location = new Point(43, 101);

        lblSubtitulo.Size = new Size(495, 29);

        lblSubtitulo.Text =
            "Completa los datos para registrar un nuevo usuario.";

        // =====================================================
        // NOMBRE COMPLETO
        // =====================================================

        ConfigurarEtiquetaCuenta(
            lblNombre,
            "Nombre completo",
            140);

        ConfigurarCampoCuenta(
            txtNombre,
            163,
            495);

        txtNombre.MaxLength = 100;

        txtNombre.PlaceholderText = "Nombre y apellidos";

        // =====================================================
        // NOMBRE DE USUARIO
        // =====================================================

        ConfigurarEtiquetaCuenta(
            lblUsuario,
            "Nombre de usuario",
            211);

        ConfigurarCampoCuenta(
            txtUsuario,
            234,
            495);

        txtUsuario.MaxLength = 50;

        txtUsuario.PlaceholderText = "Crea un nombre de usuario";

        // =====================================================
        // CONTRASEÑA
        // =====================================================

        ConfigurarEtiquetaCuenta(
            lblClave,
            "Contraseña",
            282);

        ConfigurarCampoCuenta(
            txtClave,
            305,
            495);

        txtClave.MaxLength = 50;

        txtClave.UseSystemPasswordChar = true;

        txtClave.PlaceholderText = "Mínimo 6 caracteres";

        // =====================================================
        // CONFIRMAR CONTRASEÑA
        // =====================================================

        ConfigurarEtiquetaCuenta(
            lblConfirmarClave,
            "Confirmar contraseña",
            353);

        ConfigurarCampoCuenta(
            txtConfirmarClave,
            376,
            495);

        txtConfirmarClave.MaxLength = 50;

        txtConfirmarClave.UseSystemPasswordChar = true;

        txtConfirmarClave.PlaceholderText = "Escribe nuevamente la contraseña";

        // =====================================================
        // MOSTRAR CONTRASEÑAS
        // =====================================================

        chkMostrarClaves.AutoSize = true;

        chkMostrarClaves.BackColor = Color.White;

        chkMostrarClaves.Cursor = Cursors.Hand;

        chkMostrarClaves.Font = new Font(
            "Segoe UI",
            9F,
            FontStyle.Regular);

        chkMostrarClaves.ForeColor = Color.FromArgb(71, 85, 105);

        chkMostrarClaves.Location = new Point(43, 415);

        chkMostrarClaves.Size = new Size(185, 24);

        chkMostrarClaves.Text = "Mostrar contraseñas";

        chkMostrarClaves.Checked = false;

        chkMostrarClaves.CheckedChanged +=
            ChkMostrarClaves_CheckedChanged;

        // =====================================================
        // ROL
        // =====================================================

        ConfigurarEtiquetaCuenta(
            lblRol,
            "Rol del usuario",
            450);

        cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;

        cmbRol.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Regular);

        cmbRol.BackColor = Color.FromArgb(248, 250, 252);

        cmbRol.ForeColor = Color.FromArgb(15, 23, 42);

        cmbRol.FlatStyle = FlatStyle.Flat;

        cmbRol.Location = new Point(43, 473);

        cmbRol.Size = new Size(495, 30);

        cmbRol.Items.Add("Empleado");

        cmbRol.Items.Add("Administrador");

        cmbRol.SelectedIndex = 0;

        // =====================================================
        // BOTONES
        // =====================================================

        btnCrear.BackColor = Color.FromArgb(22, 163, 74);

        btnCrear.FlatAppearance.BorderSize = 0;

        btnCrear.FlatAppearance.MouseOverBackColor =
            Color.FromArgb(21, 128, 61);

        btnCrear.FlatAppearance.MouseDownBackColor =
            Color.FromArgb(22, 101, 52);

        btnCrear.FlatStyle = FlatStyle.Flat;

        btnCrear.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Bold);

        btnCrear.ForeColor = Color.White;

        btnCrear.Location = new Point(43, 535);

        btnCrear.Size = new Size(238, 44);

        btnCrear.Text = "Crear cuenta";

        btnCrear.UseVisualStyleBackColor = false;

        btnCrear.Cursor = Cursors.Hand;

        btnCrear.Click += BtnCrear_Click;

        btnCancelar.BackColor = Color.White;

        btnCancelar.FlatAppearance.BorderSize = 1;

        btnCancelar.FlatAppearance.BorderColor =
            Color.FromArgb(203, 213, 225);

        btnCancelar.FlatAppearance.MouseOverBackColor =
            Color.FromArgb(248, 250, 252);

        btnCancelar.FlatStyle = FlatStyle.Flat;

        btnCancelar.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Bold);

        btnCancelar.ForeColor = Color.FromArgb(51, 65, 85);

        btnCancelar.Location = new Point(298, 535);

        btnCancelar.Size = new Size(240, 44);

        btnCancelar.Text = "Cancelar";

        btnCancelar.UseVisualStyleBackColor = false;

        btnCancelar.Cursor = Cursors.Hand;

        btnCancelar.Click += BtnCancelar_Click;

        // =====================================================
        // PIE DEL FORMULARIO
        // =====================================================

        Label lblPieFormulario = new Label();

        lblPieFormulario.AutoSize = false;

        lblPieFormulario.Font = new Font(
            "Segoe UI",
            8F,
            FontStyle.Regular);

        lblPieFormulario.ForeColor = Color.FromArgb(148, 163, 184);

        lblPieFormulario.Location = new Point(43, 605);

        lblPieFormulario.Size = new Size(495, 35);

        lblPieFormulario.Text =
            "La contraseña se almacenará mediante el mecanismo de seguridad del sistema.";

        // =====================================================
        // AGREGAR CONTROLES AL PANEL
        // =====================================================

        panelAcceso.Controls.Add(lblEyebrow);

        panelAcceso.Controls.Add(lblTitulo);

        panelAcceso.Controls.Add(lblSubtitulo);

        panelAcceso.Controls.Add(lblNombre);

        panelAcceso.Controls.Add(txtNombre);

        panelAcceso.Controls.Add(lblUsuario);

        panelAcceso.Controls.Add(txtUsuario);

        panelAcceso.Controls.Add(lblClave);

        panelAcceso.Controls.Add(txtClave);

        panelAcceso.Controls.Add(lblConfirmarClave);

        panelAcceso.Controls.Add(txtConfirmarClave);

        panelAcceso.Controls.Add(chkMostrarClaves);

        panelAcceso.Controls.Add(lblRol);

        panelAcceso.Controls.Add(cmbRol);

        panelAcceso.Controls.Add(btnCrear);

        panelAcceso.Controls.Add(btnCancelar);

        panelAcceso.Controls.Add(lblPieFormulario);

        // =====================================================
        // ARMAR FORMULARIO PRINCIPAL
        // =====================================================

        panelPrincipal.Controls.Add(panelAcceso);

        panelPrincipal.Controls.Add(panelMarca);

        Controls.Add(panelPrincipal);

        AcceptButton = btnCrear;

        CancelButton = btnCancelar;

        panelMarca.ResumeLayout(false);

        panelAcceso.ResumeLayout(false);

        panelPrincipal.ResumeLayout(false);

        ResumeLayout(false);
    }

    // =========================================================
    // ESTILO DE ETIQUETAS
    // =========================================================

    private void ConfigurarEtiquetaCuenta(
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

        etiqueta.Location = new Point(43, posicionY);

        etiqueta.Size = new Size(495, 21);

        etiqueta.Text = texto;
    }

    // =========================================================
    // ESTILO DE CAMPOS
    // =========================================================

    private void ConfigurarCampoCuenta(
        TextBox campo,
        int posicionY,
        int ancho)
    {
        campo.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Regular);

        campo.Location = new Point(43, posicionY);

        campo.Size = new Size(ancho, 31);

        campo.BorderStyle = BorderStyle.FixedSingle;

        campo.BackColor = Color.FromArgb(248, 250, 252);

        campo.ForeColor = Color.FromArgb(15, 23, 42);
    }
}