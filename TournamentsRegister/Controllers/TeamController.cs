using Microsoft.AspNetCore.Mvc;
using TournamentsRegister.Models.Requests;
using TournamentsRegister.Models;
using TournamentsRegister.Services;
using Mapster;
using TournamentsRegister.Models.MiddleModelsForDAL;

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

    // POST api/<TeamController>
    [HttpPost("{tournamentID}")]
    public void Post([FromRoute] int tournamentID, [FromBody] TeamInsert insert)
    {
        TeamMiddleModelInsert teamInsert = insert.Adapt<TeamMiddleModelInsert>();

        teamInsert.TournamentID = tournamentID;

        _teamService.Insert(teamInsert);
    }

    // PUT api/<TeamController>
    [HttpPut]
    public void Put([FromBody] TeamUpdate update)
    {
        _teamService.Update(update);
    }

    // DELETE api/<TeamController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _teamService.Remove(id);
    }
}