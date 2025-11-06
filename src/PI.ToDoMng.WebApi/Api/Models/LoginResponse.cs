using System;

namespace PI.ToDoMng.WebApi.Api.Models;

public record LoginResponse(string AccessToken, DateTime ExpiresIn);