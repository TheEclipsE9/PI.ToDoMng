namespace PI.ToDoMng.WebApi.Application.DTOs;

public record class LoginResultDto(bool IsSuccess, string? Token, DateTime? ExpiresAt)
{
    private static LoginResultDto _failed = new LoginResultDto(false, null, null);
    public static LoginResultDto Failed => _failed;
}
