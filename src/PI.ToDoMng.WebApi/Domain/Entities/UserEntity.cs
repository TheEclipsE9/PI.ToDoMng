using System;

namespace PI.ToDoMng.WebApi.Domain.Entities;

public class UserEntity
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }
}
