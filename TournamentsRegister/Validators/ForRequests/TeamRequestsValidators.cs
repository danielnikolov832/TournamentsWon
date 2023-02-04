using FluentValidation;
using TournamentsRegister.Constants;
using TournamentsRegister.Models;
using TournamentsRegister.Models.MiddleModelsForDAL;
using TournamentsRegister.Models.Requests;

namespace TournamentsRegister.Validators.ForRequests;

public class TeamInsertValidator : AbstractValidator<TeamMiddleModelInsert>
{
    public TeamInsertValidator()
    {
        RuleFor(insert => insert.TournamentID).NotEqual(0);

        RuleFor(insert => insert.Name).NotNull().NotEmpty().MaximumLength(ModelAttributesConstants.TeamNameMaxLength);
    }
}

public class TeamInsertValidatorForParentTournament : AbstractValidator<TeamMiddleModelInsert>
{
    public TeamInsertValidatorForParentTournament(Tournament parentTournament)
    {
        RuleFor(insert => insert.Name)
            .Must(name =>
            {
                IEnumerable<string> teamNamesInParent =
                    from Team childTeam in parentTournament.get_teams
                    select childTeam.Name;

                foreach (string childName in teamNamesInParent)
                {
                    if (childName == name) return false;
                }

                return true;
            }).WithMessage("Item must not contain a team with the same name");

        RuleForEach(insert => insert.PlayerNames).NotEmpty().MaximumLength(ModelAttributesConstants.PlayerNameMaxLength);
    }
}

public class TeamUpdateValidator : AbstractValidator<TeamUpdate>
{
    public TeamUpdateValidator()
    {
        RuleFor(insert => insert.ID).NotEqual(0);

        RuleFor(update => update.Name).NotNull().NotEmpty().MaximumLength(ModelAttributesConstants.TeamNameMaxLength);

        RuleForEach(update => update.NewPlayersNames).MaximumLength(ModelAttributesConstants.PlayerNameMaxLength);
        RuleForEach(update => update.RemovedPlayersNames).MaximumLength(ModelAttributesConstants.PlayerNameMaxLength);
    }
}