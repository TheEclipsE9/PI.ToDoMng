using System;

namespace PI.ToDoMng.WebApi.Domain.Entities;

public class SessionEntity
{
    public string Token { get; set; }
    public int UserId { get; set; }
    public DateTime ExpiresAt { get; set; }
}
