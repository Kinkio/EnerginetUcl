using System.IO;
using System.Threading.Tasks;
using EnerginetDemo.Application;
using FluentAssertions;
using Xunit;

namespace EnerginetDemo.Tests.Unit.Application;

public class SampleMessageDeserializerTests : TestBase<SampleMessageDeserializer>
{
    public SampleMessageDeserializerTests()
    {
        TestDataFolder = Path.Combine(Directory.GetCurrentDirectory(), "Tests/TestData");
    }

    private string TestDataFolder { get; }

    [Fact]
    public async Task Should_DeserializeToSampleMessage_When_ValidXmlGiven()
    {
        // Arrange
        var testDataFile = Path.Combine(TestDataFolder, "SampleMessage.xml");
        await using var fileStream = File.OpenRead(testDataFile);

        // Act
        var actual = await Sut.DeserializeMessageAsync(fileStream);

        // Assert
        actual.Text.Should().Be("A sample message.");
    }
}
