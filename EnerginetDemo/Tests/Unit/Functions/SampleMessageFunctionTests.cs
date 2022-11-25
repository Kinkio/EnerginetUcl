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

public class SampleMessageFunctionTests : TestBase<SampleMessageFunction>
{
    public SampleMessageFunctionTests()
    {
        SampleMessageServiceMock = Fixture.Freeze<Mock<ISampleMessageService>>();
    }

    private Mock<ISampleMessageService> SampleMessageServiceMock { get; }

    [Fact]
    public async Task Should_HandleIncomingSampleMessage_When_HttpRequestIsGiven()
    {
        // Arrange
        var byteArray = Encoding.UTF8.GetBytes("<SomeXmlContent></SomeXmlContent>");

        var expectedStream = new MemoryStream(byteArray);
        expectedStream.Flush();
        expectedStream.Position = 0;

        var httpRequestMock = new Mock<HttpRequest>();
        httpRequestMock.Setup(x => x.Body).Returns(expectedStream);

        // Act
        await Sut.Run(httpRequestMock.Object);

        // Assert
        SampleMessageServiceMock.Verify(x => x.HandleIncomingSampleMessage(expectedStream), Times.Once);
    }
}
