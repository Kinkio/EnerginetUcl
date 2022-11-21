using FluentValidation;

namespace EnerginetDemo.Validators;

public class SampleMessageValidator : AbstractValidator<SampleMessage>, ISampleMessageValidator
{
    public SampleMessageValidator()
    {
        RuleFor(sample => sample.Text).MinimumLength(10).WithMessage("Text should be 10 chars or longer");
    }
}
