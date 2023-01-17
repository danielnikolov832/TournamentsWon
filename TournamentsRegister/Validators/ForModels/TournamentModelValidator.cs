using FluentValidation;
using TournamentsRegister.Constants;
using TournamentsRegister.Models;

namespace TournamentsRegister.Validators.ForModels;

public class TournamentModelValidator : AbstractValidator<Tournament>
{
	public TournamentModelValidator()
	{
		RuleFor(tournament => tournament.Name).NotNull().NotEmpty().MaximumLength(ModelAttributesConstants.TournamentNameMaxLength);
		RuleFor(tournament => tournament.Description).NotNull().NotEmpty().MaximumLength(ModelAttributesConstants.TournamentDescriptionMaxLength);

        RuleFor(tournament => tournament.Teams).Must(teams => TeamsDoNotHaveDuplicateNames(teams));
    }

    private static bool TeamsDoNotHaveDuplicateNames(List<Team> teams)
    {
        List<string> names = new();

        IEnumerable<string> teamNames =
            from Team team in teams
            select team.Name;

        foreach (string name in teamNames)
        {
            if (names.Contains(name))
            {
                return false;
            }

            names.Add(name);
        }

        return true;
    }
}