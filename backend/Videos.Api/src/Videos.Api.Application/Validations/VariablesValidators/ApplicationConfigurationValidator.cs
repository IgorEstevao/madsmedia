using Videos.Api.Infra.CrossCutting.Environments.Configurations;
using FluentValidation;

namespace Videos.Api.Application.Validations.VariablesValidators;

public class ApplicationConfigurationValidator : Validator<ApplicationConfiguration>
{
    public ApplicationConfigurationValidator()
    {
        RuleFor(c => c.Environment)
            .Must(x => x.Equals("Development") || x.Equals("Homolog") || x.Equals("Production"))
            .WithMessage("must be 'Development', 'Homolog' or 'Production");

        RuleFor(c => c.ConnectionString)
            .NotNull()
            .NotEmpty();

        RuleFor(c => c.GlobalErrorCode)
            .NotNull()
            .NotEmpty();

        RuleFor(c => c.GlobalErrorMessage)
            .NotNull()
            .NotEmpty();
    }
}
