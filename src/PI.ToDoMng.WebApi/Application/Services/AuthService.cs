using System;
using System.Security.Cryptography;
using PI.ToDoMng.WebApi.Application.DTOs;
using PI.ToDoMng.WebApi.Application.Utilities;
using PI.ToDoMng.WebApi.Domain.Entities;
using PI.ToDoMng.WebApi.Domain.Interfaces;

namespace PI.ToDoMng.WebApi.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly ISessionStore _sessionStore;

    public AuthService(
        IUserService userService,
        ISessionStore sessionStore
    )
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _sessionStore = sessionStore ?? throw new ArgumentNullException(nameof(sessionStore));
    }

    public LoginResultDto Login(string username, string password)
    {
        var isValid = _userService.ValidateCredentials(username, password, out int userId);
        if (isValid == false)
            return LoginResultDto.Failed;

        var session = _sessionStore.CreateSession(userId);

        return new LoginResultDto(true, session.Token, session.ExpiresAt);
    }

    public void Logout(string token)
    {
        _sessionStore.InvalidateSession(token);
    }

    public Session? ValidateToken(string token)
    {
        return _sessionStore.GetSession(token);
    }
}
