using Microsoft.AspNetCore.Mvc;
using TournamentsRegister.Models.Requests;
using TournamentsRegister.Models.MiddleModelsForDAL;
using TournamentsRegister.Models;
using TournamentsRegister.Services;
using Mapster;
using FluentValidation;

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

    // GET: api/<TeamController>
    [HttpGet]
    public IEnumerable<Team> Get()
    {
        return _teamService.GetAll();
    }

    // GET: api/<TeamController>/tournament/5
    [HttpGet("tournament/{tournamentID}")]
    public IEnumerable<Team> Get([FromRoute] int tournamentID)
    {
        return _teamService.GetAllFromTournament(tournamentID);
    }

    // GET api/<TeamController>/5
    [HttpGet("{id}")]
    public ActionResult<Team> GetById(int id)
    {
        Team? output = _teamService.GetById(id);

        if (output is null)
        {
            return NotFound();
        }

        return Ok(output);
    }

    // POST api/<TeamController>/5
    [HttpPost("{tournamentID}")]
    public void Post([FromRoute] int tournamentID, [FromBody] TeamInsert insert, [FromServices] IValidator<TeamMiddleModelInsert>? insertValidator = null, [FromServices] IValidator<Team>? modelValidator = null)
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

    // DELETE api/<TeamController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _teamService.Remove(id);
    }
}