using System;
using System.Collections.Concurrent;
using PI.ToDoMng.WebApi.Application.Utilities;
using PI.ToDoMng.WebApi.Domain.Entities;
using PI.ToDoMng.WebApi.Domain.Interfaces;

namespace PI.ToDoMng.WebApi.Application.Services;

public class SessionStore : ISessionStore
{
    private readonly ConcurrentDictionary<string, Session> _sessionsCache = new ConcurrentDictionary<string, Session>();

    public Session CreateSession(int userId)
    {
        var session = Session.NewSession(userId);

        if (_sessionsCache.TryAdd(session.Token, session) == false)
            throw new Exception("Failed to add session to cache.");

        return session;
    }

    public Session? GetSession(string token)
    {
        if (!_sessionsCache.TryGetValue(token, out Session session))
            return null;

        if (session.IsValid() == false)
        {
            InvalidateSession(token);
            return null;
        }

        return session;
    }

    public void InvalidateSession(string token)
    {
        _sessionsCache.TryRemove(token, out _);
    }
}
