using Microsoft.AspNetCore.Mvc;
using TournamentsRegister.Models.Requests;
using TournamentsRegister.Models.MiddleModelsForDAL;
using TournamentsRegister.Models;
using TournamentsRegister.Services;
using Mapster;
using FluentValidation;
using TournamentsRegister.Models.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TournamentsRegister.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamController : ControllerBase
{
    public TeamController(TeamService teamService)
    {
        _teamService = teamService;
    }

    private readonly TeamService _teamService;

    // GET: api/<TeamController>/tournament/5
    [HttpGet("tournament/{tournamentID}")]
    public IEnumerable<TeamResponse> Get([FromRoute] int tournamentID)
    {
        return _teamService.GetAllFromTournament(tournamentID).Adapt<List<TeamResponse>>();
    }

    // GET api/<TeamController>/5
    [HttpGet("{id}")]
    public ActionResult<TeamResponse> GetById(int id)
    {
        Team? output = _teamService.GetById(id);

        if (output is null)
        {
            return NotFound();
        }

        return Ok(output.Adapt<TeamResponse>());
    }

    // POST api/<TeamController>/tournament/5
    [HttpPost("tournament/{tournamentID}")]
    public void Post([FromRoute] int tournamentID, [FromBody] TeamInsert insert,
        [FromServices] IValidator<TeamMiddleModelInsert>? insertValidator = null, [FromServices] IValidator<Team>? modelValidator = null)
    {
        TeamMiddleModelInsert teamInsert = insert.Adapt<TeamMiddleModelInsert>();

        teamInsert.TournamentID = tournamentID;

        _teamService.Insert(teamInsert, insertValidator, modelValidator);
    }

    // PUT api/<TeamController>
    [HttpPut]
    public void Put([FromBody] TeamUpdate update, [FromServices] IValidator<TeamUpdate>? updateValidator = null, [FromServices] IValidator<Team>? modelValidator = null)
    {
        _teamService.Update(update, updateValidator, modelValidator);
    }

    // DELETE api/<TeamController>
    [HttpDelete]
    public void Delete([FromBody] TeamDelete delete)
    {
        _teamService.RemoveFromRequest(delete);
    }
}