using System;
using PI.ToDoMng.WebApi.Domain.Interfaces;

namespace PI.ToDoMng.WebApi.Application.Services;

public class UserService : IUserService
{
    private readonly Dictionary<string, UserCredential> _users = new Dictionary<string, UserCredential>
    {
        {"admin", new UserCredential { UserId = 1, Username ="admin", Password = "admin" }},
        {"support", new UserCredential { UserId = 2, Username ="support", Password = "support" }},
        {"default", new UserCredential { UserId = 3, Username ="default", Password = "default" }},
    };

    private class UserCredential
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public bool ValidateCredentials(string username, string password, out int userId)
    {
        userId = -1;

        if (_users.TryGetValue(username, out UserCredential userCredential) &&
            string.Equals(password, userCredential.Password))
        {
            userId = userCredential.UserId;
            return true;
        }
        else
        {
            return false;
        }
    }
}
