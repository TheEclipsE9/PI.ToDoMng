using System;
using PI.ToDoMng.WebApi.Application.Services;
using PI.ToDoMng.WebApi.Domain.Entities;

namespace PI.ToDoMng.Tests.Application.Services;

public class SessionStoreTests
{
    [Fact]
    public void SessionStore_Creates_Session_No_Exception()
    {
        //Arrange
        var userId = 1;

        var sut = new SessionStore();

        //Act
        var createdSession = sut.CreateSession(userId);

        //Assert
        Assert.NotNull(createdSession);
        Assert.Equal(userId, createdSession.UserId);
    }

    [Fact]
    public void SessionStore_Creates_And_Return_Session_By_Token_No_Exception()
    {
        //Arrange
        var userId = 1;

        var sut = new SessionStore();

        //Act
        var createdSession = sut.CreateSession(userId);

        var isSuccess = sut.TryGetValidSession(createdSession.Token, out Session retrievedSession);

        //Assert
        Assert.NotNull(retrievedSession);
        Assert.True(isSuccess);
        Assert.Equal(createdSession.Token, retrievedSession.Token);
        Assert.Equal(createdSession.UserId, retrievedSession.UserId);
        Assert.Equal(createdSession.CreatedAt, retrievedSession.CreatedAt);
        Assert.Equal(createdSession.ExpiresAt, retrievedSession.ExpiresAt);
    }

    [Fact]
    public void SessionStore_Creates_And_Invalidates_Session_By_Token_No_Exception()
    {
        //Arrange
        var userId = 1;

        var sut = new SessionStore();

        //Act
        var createdSession = sut.CreateSession(userId);

        sut.InvalidateSession(createdSession.Token);

        var isSuccess = sut.TryGetValidSession(createdSession.Token, out Session retrievedSession);

        //Assert
        Assert.False(isSuccess);
        Assert.Null(retrievedSession);
    }
}
