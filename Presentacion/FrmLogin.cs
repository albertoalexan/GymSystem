using GymSystem.Entidades;
using GymSystem.Negocio;

namespace GymSystem;

public partial class FrmLogin : Form
{
    private readonly UsuarioService usuarioService;

    public FrmLogin()
    {
        InitializeComponent();

        usuarioService =
            new UsuarioService();

        AcceptButton =
            btnIniciarSesion;
    }

    private void BtnIniciarSesion_Click(
        object? sender,
        EventArgs e)
    {
        string usuario =
            txtUsuario.Text.Trim();

        string clave =
            txtClave.Text;

        if (string.IsNullOrWhiteSpace(usuario))
        {
            MessageBox.Show(
                "Ingrese su usuario.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtUsuario.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(clave))
        {
            MessageBox.Show(
                "Ingrese su contraseña.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtClave.Focus();
            return;
        }

        try
        {
            Usuario? usuarioAutenticado =
                usuarioService.Autenticar(
                    usuario,
                    clave);

            if (usuarioAutenticado == null)
            {
                MessageBox.Show(
                    "El usuario o la contraseña son incorrectos.",
                    "Inicio de sesión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtClave.Clear();
                txtClave.Focus();

                return;
            }

            Hide();

            using FrmPrincipal formularioPrincipal =
                new FrmPrincipal(
                    usuarioAutenticado.Nombre,
                    usuarioAutenticado.Rol);

            formularioPrincipal.ShowDialog(this);

            Show();

            txtClave.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No fue posible iniciar sesión:\n\n" +
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
