using EnerginetDemo.Domain.Input;
using FluentValidation;

namespace EnerginetDemo.Application.Validators
{
    public interface ISampleMessageValidator : IValidator<SampleMessage>
    {

    }
}
