using GymSystem.Negocio;

namespace GymSystem;

public partial class FrmCrearCuenta : Form
{
    private readonly UsuarioService usuarioService;

    public FrmCrearCuenta()
    {
        InitializeComponent();

        usuarioService = new UsuarioService();

        AcceptButton = btnCrear;
        CancelButton = btnCancelar;
    }

    private void ChkMostrarClaves_CheckedChanged(
        object? sender,
        EventArgs e)
    {
        bool mostrar = chkMostrarClaves.Checked;

        txtClave.UseSystemPasswordChar = !mostrar;

        txtConfirmarClave.UseSystemPasswordChar = !mostrar;
    }
    private async void BtnCrear_Click(
        object? sender,
        EventArgs e)
    {
        string nombre =
            txtNombre.Text.Trim();

        string usuario =
            txtUsuario.Text.Trim();

        string clave =
            txtClave.Text;

        string confirmarClave =
            txtConfirmarClave.Text;

        string rol =
            cmbRol.SelectedItem?.ToString() ??
            "Empleado";

        if (string.IsNullOrWhiteSpace(nombre))
        {
            MostrarValidacion(
                "Ingrese el nombre completo.",
                txtNombre);

            return;
        }

        if (nombre.Length < 3)
        {
            MostrarValidacion(
                "El nombre debe tener al menos 3 caracteres.",
                txtNombre);

            return;
        }

        if (nombre.Length > 100)
        {
            MostrarValidacion(
                "El nombre no puede superar los 100 caracteres.",
                txtNombre);

            return;
        }

        foreach (char caracter in nombre)
        {
            if (!char.IsLetter(caracter) &&
                caracter != ' ')
            {
                MostrarValidacion(
                    "El nombre solo puede contener letras y espacios.",
                    txtNombre);

                return;
            }
        }

        if (string.IsNullOrWhiteSpace(usuario))
        {
            MostrarValidacion(
                "Ingrese un nombre de usuario.",
                txtUsuario);

            return;
        }

        if (usuario.Length < 3)
        {
            MostrarValidacion(
                "El usuario debe tener al menos 3 caracteres.",
                txtUsuario);

            return;
        }

        if (usuario.Length > 50)
        {
            MostrarValidacion(
                "El usuario no puede superar los 50 caracteres.",
                txtUsuario);

            return;
        }

        if (usuario.Contains(' '))
        {
            MostrarValidacion(
                "El usuario no puede contener espacios.",
                txtUsuario);

            return;
        }

        if (string.IsNullOrWhiteSpace(clave))
        {
            MostrarValidacion(
                "Ingrese una contraseña.",
                txtClave);

            return;
        }

        if (clave.Length < 6)
        {
            MostrarValidacion(
                "La contraseña debe tener al menos 6 caracteres.",
                txtClave);

            return;
        }

        if (clave.Length > 50)
        {
            MostrarValidacion(
                "La contraseña no puede superar los 50 caracteres.",
                txtClave);

            return;
        }

        if (string.IsNullOrWhiteSpace(
            confirmarClave))
        {
            MostrarValidacion(
                "Confirme la contraseña.",
                txtConfirmarClave);

            return;
        }

        if (clave != confirmarClave)
        {
            MostrarValidacion(
                "Las contraseñas no coinciden.",
                txtConfirmarClave);

            txtConfirmarClave.Clear();

            return;
        }

        try
        {
            await usuarioService.CrearCuentaAsync(
                nombre,
                usuario,
                clave,
                rol);

            MessageBox.Show(
                "La cuenta se creó correctamente.",
                "GymSystem",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            txtNombre.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
            txtConfirmarClave.Clear();

            cmbRol.SelectedIndex = 0;

            Close();
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Usuario existente",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtUsuario.Focus();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Ocurrió un error al guardar la cuenta:\n\n" +
                ex.Message,
                "Error de base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void MostrarValidacion(
        string mensaje,
        Control control)
    {
        MessageBox.Show(
            mensaje,
            "Validación",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        control.Focus();
    }

    private void BtnCancelar_Click(
        object? sender,
        EventArgs e)
    {
        Close();
    }
}
