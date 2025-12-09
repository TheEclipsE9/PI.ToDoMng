using System.Collections.Concurrent;
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

    public bool TryGetValidSession(string token, out Session session)
    {
        if (!_sessionsCache.TryGetValue(token, out session!))
            return false;

        if (session.IsValid() == false)
        {
            InvalidateSession(token);
            return false;
        }

        return true;
    }

    public void InvalidateSession(string token)
    {
        _sessionsCache.TryRemove(token, out _);
    }
}
