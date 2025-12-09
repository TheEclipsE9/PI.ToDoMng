using System;

namespace PI.ToDoMng.WebApi.Application.Helpers;

public static class HttpContextHelper
{
    public static bool TryExtractBearerToken(this IHeaderDictionary headers, out string token)
    {
        token = string.Empty;

        if (!headers.TryGetValue("Authorization", out var authHeader))
            return false;

        var value = authHeader.ToString();

        if (string.IsNullOrWhiteSpace(value) || !value.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            return false;

        var tokenValue = value.Split(' ', 2).Last();

        if (string.IsNullOrWhiteSpace(tokenValue))
            return false;

        token = tokenValue;
        return true;
    }
}
