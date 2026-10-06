using System.Security.Cryptography;

namespace GymSystem.Negocio;

public static class Seguridad
{
    public static string GenerarHash(
        string clave)
    {
        byte[] salt =
            RandomNumberGenerator.GetBytes(16);

        byte[] hash =
            Rfc2898DeriveBytes.Pbkdf2(
                clave,
                salt,
                100000,
                HashAlgorithmName.SHA256,
                32);

        return
            $"{Convert.ToBase64String(salt)}." +
            $"{Convert.ToBase64String(hash)}";
    }

    public static bool VerificarClave(
        string clave,
        string hashGuardado)
    {
        string[] partes =
            hashGuardado.Split('.');

        if (partes.Length != 2)
            return false;

        byte[] salt =
            Convert.FromBase64String(
                partes[0]);

        byte[] hashOriginal =
            Convert.FromBase64String(
                partes[1]);

        byte[] hashCalculado =
            Rfc2898DeriveBytes.Pbkdf2(
                clave,
                salt,
                100000,
                HashAlgorithmName.SHA256,
                32);

        return CryptographicOperations.FixedTimeEquals(
            hashOriginal,
            hashCalculado);
    }
}
