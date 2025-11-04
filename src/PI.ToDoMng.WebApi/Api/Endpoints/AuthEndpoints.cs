using System;
using Microsoft.AspNetCore.Mvc;
using PI.ToDoMng.WebApi.Api.Models;
using PI.ToDoMng.WebApi.Application.DTOs;
using PI.ToDoMng.WebApi.Application.Services;

namespace PI.ToDoMng.WebApi.Api.Endpoints;

public static class AuthEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapGet(
            "api/auth/login",
            ([FromBody] LoginRequest requestModel,
             [FromServices] AuthService authService) =>
            {
                var result = authService.TryLogin(new LoginRequestDto(requestModel.Username, requestModel.Password));

                if (result.IsSuccess)
                    return Results.Ok(new LoginResponse(result.Token, 0));

                return Results.Unauthorized();
            }
        );
    }
}
