using System;
using PI.ToDoMng.WebApi.Domain.Entities;

namespace PI.ToDoMng.WebApi.Domain.Interfaces;

public interface ISessionStore
{
    Session CreateSession(int userId);

    bool TryGetValidSession(string token, out Session session);

    void InvalidateSession(string token);
}
