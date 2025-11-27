using System;
using PI.ToDoMng.WebApi.Application.Helpers;
using PI.ToDoMng.WebApi.Domain;
using PI.ToDoMng.WebApi.Domain.Entities;
using PI.ToDoMng.WebApi.Domain.Interfaces;

namespace PI.ToDoMng.WebApi.Api.Middleware;

public class TokenValidationMiddleware
{
    private static readonly string[] _publicPaths = ["/api/auth/login"];

    private readonly RequestDelegate _next;

    public TokenValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ISessionStore sessionStore)
    {
        if (CanSkip(context))
        {
            await _next(context);
            return;
        }

        string? token = HttpContextHelper.ExtractBearerToken(context);

        if (string.IsNullOrEmpty(token))
        {
            Write401ToResponse(context);
            return;
        }

        Session? session = sessionStore.GetSession(token);

        if (session is null)
        {
            Write401ToResponse(context);
            return;
        }

        if (session.IsValid() == false)
        {
            Write401ToResponse(context);
            return;
        }

        context.Items[Constants.Auth.SESSION_ITEM_KEY] = session;

        await _next(context);
    }

    private bool CanSkip(HttpContext context) => _publicPaths.Any(p => context.Request.Path.StartsWithSegments(p));

    private void Write401ToResponse(HttpContext context)
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return;
    }
}

public static class TokenValidationMiddlewareExtensions
{
    public static IApplicationBuilder UseTokenValidationMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TokenValidationMiddleware>();
    }
}