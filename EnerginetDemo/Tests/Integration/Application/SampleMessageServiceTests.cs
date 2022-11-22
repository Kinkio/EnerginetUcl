using System.IO;
using System.Threading.Tasks;
using EnerginetDemo.Application;
using EnerginetDemo.Application.Converters;
using EnerginetDemo.Application.Validators;
using EnerginetDemo.Tests.Doubles;
using FluentAssertions;
using Xunit;

namespace EnerginetDemo.Tests.Integration.Application;

public class SampleMessageServiceTests
{
    public SampleMessageServiceTests()
    {
        TestDataFolder = Path.Combine(Directory.GetCurrentDirectory(), "Tests/TestData");

        Sut = new SampleMessageService(
            new SampleMessageConverter(),
            new SampleMessageDeserializer(),
            new SampleMessageValidator(),
            Repository);
    }

    private string TestDataFolder { get; }

    private SampleMessageService Sut { get; }

    private FakeSampleMessageRepository Repository { get; } = new();

    [Fact]
    public async Task Should_PersistSampleMessage_When_ValidXmlGiven()
    {
        // Arrange
        var testDataFile = Path.Combine(TestDataFolder, "SampleMessage.xml");
        await using var fileStream = File.OpenRead(testDataFile);

        // Act
        await Sut.HandleIncomingSampleMessage(fileStream);

        // Assert
        Repository.Count().Should().Be(1);
    }
}
