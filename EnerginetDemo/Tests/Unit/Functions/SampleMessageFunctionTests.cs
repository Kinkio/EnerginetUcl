using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using EnerginetDemo.Application;
using EnerginetDemo.Functions;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace EnerginetDemo.Tests.Unit.Functions;

public class SampleMessageFunctionTests : TestBase<SampleMessageFunction>, IDisposable
{
    public SampleMessageFunctionTests()
    {
        SampleMessageServiceMock = Fixture.Freeze<Mock<ISampleMessageService>>();

        ExpectedStream = new MemoryStream(Encoding.UTF8.GetBytes("<SomeXmlContent></SomeXmlContent>"));
        ExpectedStream.Flush();
        ExpectedStream.Position = 0;
    }

    private Mock<ISampleMessageService> SampleMessageServiceMock { get; }

    private Stream ExpectedStream { get; }

    public void Dispose()
    {
        ExpectedStream.Dispose();
    }

    [Fact]
    public async Task Should_HandleIncomingSampleMessage_When_HttpRequestIsGiven()
    {
        // Arrange
        var httpRequestMock = new Mock<HttpRequest>();
        httpRequestMock.Setup(x => x.Body).Returns(ExpectedStream);

        // Act
        await Sut.Run(httpRequestMock.Object);

        // Assert
        SampleMessageServiceMock.Verify(x => x.HandleIncomingSampleMessage(ExpectedStream), Times.Once);
    }
}
