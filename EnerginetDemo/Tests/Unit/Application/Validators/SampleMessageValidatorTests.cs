using AutoFixture;
using EnerginetDemo.Application.Validators;
using EnerginetDemo.Domain.Input;
using FluentAssertions;
using Xunit;

namespace EnerginetDemo.Tests.Unit.Application.Validators;

public class SampleMessageValidatorTests : TestBase<SampleMessageValidator>
{
    [Fact]
    public void Should_ReturnValidResultWithZeroErrors_When_ValidSampleMessageGiven()
    {
        // Arrange
        var sampleMessage = Fixture.Create<SampleMessage>();

        // Act
        var actual = Sut.Validate(sampleMessage);

        // Assert
        actual.IsValid.Should().BeTrue();
        actual.Errors.Should().BeEmpty();
    }

    [Fact]
    public void Should_ReturnInvalidResultWithOneError_When_InvalidSampleMessageGiven()
    {
        // Arrange
        var sampleMessage = Fixture.Build<SampleMessage>()
            .With(x => x.Text, string.Empty)
            .Create();

        // Act
        var actual = Sut.Validate(sampleMessage);

        // Assert
        actual.IsValid.Should().BeFalse();
        actual.Errors.Should().HaveCount(1);
    }
}
