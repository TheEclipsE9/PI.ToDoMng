namespace PI.ToDoMng.WebApi.Application.DTOs;

public record class LoginResultDto(bool IsSuccess, string? Token);
