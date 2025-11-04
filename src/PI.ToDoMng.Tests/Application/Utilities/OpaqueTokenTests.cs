using System;
using PI.ToDoMng.WebApi.Application.Utilities;

namespace PI.ToDoMng.Tests.Application.Utilities;

public class OpaqueTokenTests
{
    [Fact]
    public void GenerateToken_Generates_3_Random_And_Unique_Tokens()
    {
        //Arrange
        //Act
        var token1 = OpaqueToken.GenerateToken();
        var token2 = OpaqueToken.GenerateToken();
        var token3 = OpaqueToken.GenerateToken();

        var set = new HashSet<string>();
        set.Add(token1);
        set.Add(token2);
        set.Add(token3);

        //Assert
        Assert.True(set.Count == 3, "Expected 3 unique tokens, but duplicates were found.");
    }
}
