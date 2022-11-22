using AutoFixture;
using EnerginetDemo.Application.Converters;
using EnerginetDemo.Domain.Database;
using EnerginetDemo.Domain.Input;
using FluentAssertions;
using Xunit;

namespace EnerginetDemo.Tests.Unit.Application.Converters;

public class SampleMessageConverterTests : TestBase<SampleMessageConverter>
{
    [Fact]
    public void Should_ReturnSampleMessageDb_When_SampleMessageGiven()
    {
        // Arrange
        var sampleMessage = Fixture.Create<SampleMessage>();

        // Act
        var actual = Sut.Convert(sampleMessage);

        // Assert
        actual.Id.Should().Be(0);
        actual.Text.Should().Be(sampleMessage.Text);
    }
}
