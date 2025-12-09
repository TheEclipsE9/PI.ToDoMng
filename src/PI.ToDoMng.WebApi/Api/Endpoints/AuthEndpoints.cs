using System;
using Microsoft.AspNetCore.Mvc;
using PI.ToDoMng.WebApi.Api.Models;
using PI.ToDoMng.WebApi.Application.Helpers;
using PI.ToDoMng.WebApi.Domain;
using PI.ToDoMng.WebApi.Domain.Entities;
using PI.ToDoMng.WebApi.Domain.Interfaces;

namespace PI.ToDoMng.WebApi.Api.Endpoints;

public static class AuthEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapPost("api/auth/login", ([FromBody] LoginRequest requestModel, [FromServices] IAuthService authService) =>
        {
            var result = authService.Login(requestModel.Username, requestModel.Password);

            if (result.IsSuccess)
                return Results.Ok(new LoginResponse(result.Token, result.ExpiresAt.Value));

            return Results.Unauthorized();
        }).AllowAnonymous();

        app.MapPost("api/auth/logout", (HttpContext context, [FromServices] IAuthService authService) =>
        {
            Session? session = context.Items[Constants.Auth.SESSION_ITEM_KEY] as Session;
            if (session is null)
                return Results.Unauthorized();

            authService.Logout(session.Token);

            return Results.NoContent();
        }).RequireAuthorization();

        app.MapGet("api/auth/me", (HttpContext context, [FromServices] IAuthService authService) =>
        {
            Session? session = context.Items[Constants.Auth.SESSION_ITEM_KEY] as Session;
            if (session is null)
                return Results.Unauthorized();

            return Results.Ok(new MeResponse(session.Token, session.UserId, session.CreatedAt, session.ExpiresAt));
        }).RequireAuthorization();
    }
}
