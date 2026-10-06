namespace GymSystem.Entidades;

public class Usuario
{
    public int IdUsuario { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string UsuarioNombre { get; set; } = string.Empty;
    public string ClaveHash { get; set; } = string.Empty;
    public string Rol { get; set; } = "Empleado";
    public bool Activo { get; set; }
}
