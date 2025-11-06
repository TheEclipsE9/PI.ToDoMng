using System;
using PI.ToDoMng.WebApi.Application.Services;

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

        var retrievedSession = sut.GetSession(createdSession.Token);

        //Assert
        Assert.NotNull(retrievedSession);
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

        var retrievedSession = sut.GetSession(createdSession.Token);

        //Assert
        Assert.Null(retrievedSession);
    }
}
