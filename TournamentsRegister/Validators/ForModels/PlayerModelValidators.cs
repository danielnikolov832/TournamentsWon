using FluentValidation;
using TournamentsRegister.Constants;
using TournamentsRegister.Models;

namespace TournamentsRegister.Validators.ForModels;

public class PlayerValidator : AbstractValidator<Player>
{
	public PlayerValidator()
	{
		RuleFor(player => player.Name).NotEmpty().MaximumLength(ModelAttributesConstants.PlayerNameMaxLength);
	}
}

public class PlayerValidatorForParentTeam : AbstractValidator<Player>
{
	public PlayerValidatorForParentTeam(Team parent)
	{
		RuleFor(player => player.Name).Must(name =>
		{
			foreach (Player player in parent.get_players)
			{
				if (name == player.Name) return false;
			}

			return true;
		});
    }
}
