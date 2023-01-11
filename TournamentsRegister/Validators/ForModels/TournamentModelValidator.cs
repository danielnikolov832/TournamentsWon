using FluentValidation;
using TournamentsRegister.Models;

namespace TournamentsRegister.Validators.ForModels;

public class TournamentModelValidator : AbstractValidator<Tournament>
{
	public TournamentModelValidator()
	{
		RuleFor(tournament => tournament.Name).NotNull().NotEmpty().MaximumLength(300);
		RuleFor(tournament => tournament.Name).NotNull().NotEmpty().MaximumLength(1000);

		RuleFor(tournament => tournament.Teams).Must((teams) =>
		{
			List<string> names = new();

			foreach (Team team in teams)
			{
				if (names.Contains(team.Name))
				{
					return false;
				}

				names.Add(team.Name);
			}

			return true;
		});
    }
}
