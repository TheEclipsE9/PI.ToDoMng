using System;

namespace PI.ToDoMng.WebApi.Application.Helpers;

public static class HttpContextHelper
{
    public static string? ExtractBearerToken(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("Authorization", out var authHeader))
            return null;

        var value = authHeader.ToString();

        if (string.IsNullOrWhiteSpace(value) || !value.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            return null;

        return value.Split(' ', 2).Last();
    }
}
