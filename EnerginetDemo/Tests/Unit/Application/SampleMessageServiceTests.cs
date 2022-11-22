using System.IO;
using System.Threading.Tasks;
using AutoFixture;
using EnerginetDemo.Application;
using EnerginetDemo.Application.Converters;
using EnerginetDemo.Application.Validators;
using EnerginetDemo.Domain.Database;
using EnerginetDemo.Domain.Input;
using EnerginetDemo.Infrastructure;
using FluentValidation.Results;
using Moq;
using Xunit;

namespace EnerginetDemo.Tests.Unit.Application;

public class SampleMessageServiceTests : TestBase<SampleMessageService>
{
    public SampleMessageServiceTests()
    {
        SampleMessageConverterMock = Fixture.Freeze<Mock<ISampleMessageConverter>>();
        SampleMessageDeserializerMock = Fixture.Freeze<Mock<ISampleMessageDeserializer>>();
        SampleMessageRepositoryMock = Fixture.Freeze<Mock<ISampleMessageRepository>>();
    }

    private Mock<ISampleMessageConverter> SampleMessageConverterMock { get; }
    private Mock<ISampleMessageDeserializer> SampleMessageDeserializerMock { get; }
    private Mock<ISampleMessageRepository> SampleMessageRepositoryMock { get; }

    [Fact]
    public async Task Should_HandleMessage_When_MessageIsValid()
    {
        // Arrange
        var stream = Fixture.Create<Stream>();

        // Act
        await Sut.HandleIncomingSampleMessage(stream);

        // Assert
        SampleMessageConverterMock.Verify(x => x.Convert(It.IsAny<SampleMessage>()), Times.Once);
        SampleMessageDeserializerMock.Verify(x => x.DeserializeMessageAsync(It.IsAny<Stream>()), Times.Once);
        SampleMessageRepositoryMock.Verify(x => x.Add(It.IsAny<SampleMessageDb>()), Times.Once);
    }
}
