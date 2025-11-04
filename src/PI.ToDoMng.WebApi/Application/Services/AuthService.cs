using System;
using System.Security.Cryptography;
using PI.ToDoMng.WebApi.Application.DTOs;
using PI.ToDoMng.WebApi.Application.Utilities;

namespace PI.ToDoMng.WebApi.Application.Services;

public class AuthService
{
    public LoginResultDto TryLogin(LoginRequestDto loginRequestDto)
    {
        if (loginRequestDto.Password == "123")
        {
            var token = OpaqueToken.GenerateToken();

            return new LoginResultDto(true, token);
        }

        return new LoginResultDto(false, null);
    }
}
