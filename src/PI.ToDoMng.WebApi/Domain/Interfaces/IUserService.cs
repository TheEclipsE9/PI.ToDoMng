using System;

namespace PI.ToDoMng.WebApi.Domain.Interfaces;

public interface IUserService
{
    bool ValidateCredentials(string username, string password, out int userId);
}
