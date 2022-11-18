using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace EnerginetDemo.Validators;

public class SampleMessageValidator : AbstractValidator<SampleMessage>
{
    public SampleMessageValidator()
    {
        RuleFor(sample => sample.Text).MinimumLength(10).WithMessage("Text should be 10 chars or longer");
    }
}
