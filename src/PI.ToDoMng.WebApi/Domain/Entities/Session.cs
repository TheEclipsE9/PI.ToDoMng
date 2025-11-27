using PI.ToDoMng.WebApi.Application.Utilities;

namespace PI.ToDoMng.WebApi.Domain.Entities;

public class Session
{
    public string Token { get; init; }
    public int UserId { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime ExpiresAt { get; init; }

    public static Session NewSession(int userId)
    {
        var createdAt = DateTime.UtcNow;

        return new Session
        {
            Token = OpaqueToken.GenerateToken(),
            UserId = userId,
            CreatedAt = createdAt,
            ExpiresAt = createdAt.AddMinutes(5)
        };
    }

    public bool IsValid() => DateTime.UtcNow < ExpiresAt;
}
