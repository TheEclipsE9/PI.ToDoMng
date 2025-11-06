using System;
using PI.ToDoMng.WebApi.Domain.Entities;

namespace PI.ToDoMng.WebApi.Domain.Interfaces;

public interface ISessionStore
{
    Session CreateSession(int userId);

    Session? GetSession(string token);

    void InvalidateSession(string token);
}
