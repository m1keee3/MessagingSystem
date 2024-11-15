using Itmo.ObjectOrientedProgramming.Lab3.Decorators;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Adressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Models.ResultTypes;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class AllTests
{
    [Fact]
    public void SendingMessageToUser_ShouldMarkItAsNotRead()
    {
        var mockLogger = new MockLogger();
        var user = new LoggingUserDecorator(mockLogger, new User());
        var message = new Message("Tittle", "Some text", 3);

        user.AddMessage(message);

        Assert.Contains("User received message", mockLogger.Logs);
        Assert.False(user.CheckIfMessageRead(0));
    }

    [Fact]
    public void UserReadsMessage_ShouldMarkItAsRead()
    {
        var mockLogger = new MockLogger();
        var user = new LoggingUserDecorator(mockLogger, new User());
        var message = new Message("Tittle", "Some text", 3);

        user.AddMessage(message);
        user.ReadMessages();

        Assert.Contains("User received message", mockLogger.Logs);
        Assert.True(user.CheckIfMessageRead(0));
    }

    [Fact]
    public void UserReadsAlreadyReadMessage_ShouldReturnFault()
    {
        var mockLogger = new MockLogger();
        var user = new LoggingUserDecorator(mockLogger, new User());
        var message = new Message("Tittle", "Some text", 3);

        user.AddMessage(message);
        user.ReadMessages();
        OperationResult result = user.ReadMessages();

        Assert.Contains("User received message", mockLogger.Logs);
        Assert.Contains("Message already read", mockLogger.Logs);
        Assert.IsType<OperationResult.MessageAlreadyReadFault>(result);
    }

    [Fact]
    public void SendLowPriorityMessageToAdressee_UserShouldNotReceiveIt()
    {
        var mockLogger = new MockLogger();
        var userMock = new Mock<IUser>();
        var userAdressee = new UserAdressee(3, userMock.Object, mockLogger);
        var message = new Message("Tittle", "Some text", 2);

        OperationResult result = userAdressee.ReceiveMessege(message);

        Assert.Contains("Message have low priority", mockLogger.Logs);
        Assert.DoesNotContain("Adressee received message", mockLogger.Logs);
        Assert.IsType<OperationResult.LowPriorityLvlFault>(result);
    }

    [Fact]
    public void SendMessageToAdressee_ShouldWriteLog()
    {
        var mockLogger = new MockLogger();
        var userMock = new Mock<IUser>();
        var userAdressee = new UserAdressee(3, userMock.Object, mockLogger);
        var message = new Message("Tittle", "Some text", 3);

        OperationResult result = userAdressee.ReceiveMessege(message);

        Assert.Contains("Adressee received message", mockLogger.Logs);
        Assert.IsType<OperationResult.Success>(result);
    }

    [Fact]
    public void SendMessageToMessengerAdressee_ShouldWriteLog()
    {
        var mockLogger = new MockLogger();
        var messengerMock = new Mock<IMessenger>();
        var messengerAdressee = new MessengerAdressee(3, messengerMock.Object, mockLogger);
        var message = new Message("Tittle", "Some text", 3);

        messengerAdressee.ReceiveMessege(message);

        Assert.Contains("Adressee received message", mockLogger.Logs);
    }

    [Fact]
    public void SendMessageToAdresseesWithDifferentPriorityLvl_UserShouldReceiveMessageOnce()
    {
        var mockLogger = new MockLogger();
        var user = new LoggingUserDecorator(mockLogger, new User());
        var userAdressee1 = new UserAdressee(3, user, mockLogger);
        var userAdressee2 = new UserAdressee(2, user, mockLogger);
        var message = new Message("Tittle", "Some text", 2);

        OperationResult result1 = userAdressee1.ReceiveMessege(message);
        OperationResult result2 = userAdressee2.ReceiveMessege(message);

        Assert.Contains("Message have low priority", mockLogger.Logs);
        Assert.Contains("Adressee received message", mockLogger.Logs);
        Assert.Contains("User received message", mockLogger.Logs);

        Assert.IsType<OperationResult.LowPriorityLvlFault>(result1);
        Assert.IsType<OperationResult.Success>(result2);
    }
}