namespace PI.ToDoMng.WebApi.Domain.Entities;

public class Session
{
    public string Token { get; init; }
    public int UserId { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime ExpiresAt { get; init; }
}
