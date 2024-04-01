namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnFalseWhenFirstNameIsEmpty()
    {
        // Arrange
        var userService = new UserService();
        
        // Act
        var result = userService.AddUser(
            null,
            "Smith",
            "smith@gmail.com",
            DateTime.Parse("2000-01-01"),
            1
            );

        // Assert
        Assert.False(result);
        
    }
    
    [Fact]
    public void AddUser_ThrowAnExceptionWhenClientDoesntExist()
    {
        // Arrange
        var userService = new UserService();
        
        // Act
        Action result = () => userService.AddUser(
            "Joe",
            "Smith1",
            "smith@gmail.com",
            DateTime.Parse("2000-01-01"),
            5
        );
        // Assert
        Assert.Throws<ArgumentException>(result);


    }

    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        var service = new UserService();
        var result = service.AddUser(
            "Joe",
            "Smith",
            "smithgmailcom",
            DateTime.Parse("2000-01-01"),
            1
        );
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        var service = new UserService();
        var result = service.AddUser(
            "Joe",
            "Smith",
            "smith@gmail.com",
            DateTime.Parse("2004-01-01"),
            1
        );
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        var service = new UserService();
        var result = service.AddUser(
            "Joe",
            "Smith",
            "smith@gmail.com",
            DateTime.Parse("2000-01-01"),
            2
        );
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        var service = new UserService();
        var result = service.AddUser(
            "Joe",
            "Smith",
            "smith@gmail.com",
            DateTime.Parse("2000-01-01"),
            3
        );
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        var service = new UserService();
        var result = service.AddUser(
            "Joe",
            "Smith",
            "smith@gmail.com",
            DateTime.Parse("2000-01-01"),
            5
        );
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        var service = new UserService();
        var result = service.AddUser(
            "Joe",
            "Kowalski",
            "kowalski@gmail.com",
            DateTime.Parse("2000-01-01"),
            1
        );
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ThrowsExceptionWhenUserDoesNotExist()
    {
        var userService = new UserService();
        
        Action result = () => userService.AddUser(
            "Joe",
            "Smith",
            "smith@gmail.com",
            DateTime.Parse("2000-01-01"),
            7
        );
        
        Assert.Throws<ArgumentException>(result);
    }

    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        var userService = new UserService();
        
        Action result = () => userService.AddUser(
            "Joe",
            "Smith1",
            "smith@gmail.com",
            DateTime.Parse("2000-01-01"),
            1
        );

        Assert.Throws<ArgumentException>(result);

    }
}