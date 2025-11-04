using System;

namespace PI.ToDoMng.WebApi.Domain.Entities;

public record ToDoItem(int Id, string Title, string Description, bool IsCompleted, DateTime CreatedAt);