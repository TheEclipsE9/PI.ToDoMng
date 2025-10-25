using System;

namespace PI.ToDoMng.WebApi.Database;

public record ToDoItem(int Id, string Title, string Description, bool IsCompleted, DateTime CreatedAt);