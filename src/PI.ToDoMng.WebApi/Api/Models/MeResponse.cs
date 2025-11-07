using System;

namespace PI.ToDoMng.WebApi.Api.Models;

public record MeResponse(string Token, int UserId, DateTime CreatedAt, DateTime ExpiresAt);
