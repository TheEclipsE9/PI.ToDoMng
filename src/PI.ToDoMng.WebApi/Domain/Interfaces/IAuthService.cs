using System;
using PI.ToDoMng.WebApi.Application.DTOs;
using PI.ToDoMng.WebApi.Domain.Entities;

namespace PI.ToDoMng.WebApi.Domain.Interfaces;

public interface IAuthService
{
    LoginResultDto Login(string username, string password);
    void Logout(string token);
    Session? ValidateToken(string token);
}
