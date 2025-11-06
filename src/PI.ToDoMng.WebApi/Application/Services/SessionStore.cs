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
        string token = OpaqueToken.GenerateToken();
        DateTime createdAt = DateTime.UtcNow;
        var session = new Session
        {
            Token = token,
            UserId = userId,
            CreatedAt = createdAt,
            ExpiresAt = createdAt.AddMinutes(5)
        };

        if (_sessionsCache.TryAdd(token, session) == false)
            throw new Exception("Failed to add session to cache.");

        return session;
    }

    public Session? GetSession(string token)
    {
        var isSuccess = _sessionsCache.TryGetValue(token, out Session session);

        if (isSuccess == false)
            return null;

        if (session.ExpiresAt <= DateTime.UtcNow)
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
