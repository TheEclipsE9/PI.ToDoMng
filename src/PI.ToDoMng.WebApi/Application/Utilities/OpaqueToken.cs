using System.Security.Cryptography;
using System.Text;

namespace PI.ToDoMng.WebApi.Application.Utilities;

public class OpaqueToken
{
    /// <summary>
    /// Generates a secure random token of the specified length.
    /// </summary>
    /// <remarks>
    /// Not URL-safe.
    /// </remarks>
    /// <param name="length">The number of random bytes to generate before Base64 encoding. Default is 32.</param>
    /// <returns>Returns a Base64-encoded string suitable for use as an opaque session token.</returns>
    public static string GenerateToken(int length = 32)
    {
        using var generator = RandomNumberGenerator.Create();

        byte[] bytes = new byte[length];
        generator.GetBytes(bytes);

        return Convert.ToBase64String(bytes);
    }
}