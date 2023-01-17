using FluentValidation;
using TournamentsRegister.Constants;
using TournamentsRegister.Models;

namespace TournamentsRegister.Validators.ForModels;

public class TeamModelValidator : AbstractValidator<Team>
{
	public TeamModelValidator()
	{
        RuleFor(team => team.Name).NotNull().NotEmpty().MaximumLength(ModelAttributesConstants.TeamNameMaxLength);
    }
}
