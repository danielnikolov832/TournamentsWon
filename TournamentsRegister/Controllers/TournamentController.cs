using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using TournamentsRegister.Models;
using TournamentsRegister.Models.Requests;
using TournamentsRegister.Models.Responses;
using TournamentsRegister.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TournamentsRegister.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TournamentController : ControllerBase
{
    public TournamentController(TournamentService tournamentService)
    {
        _tournamentService = tournamentService;
    }

    private readonly TournamentService _tournamentService;

    // GET: api/<TournamentController>
    [HttpGet]
    public IEnumerable<TournamentResponse> Get()
    {
        return _tournamentService.GetAll().Adapt<List<TournamentResponse>>();
    }

    // GET api/<TournamentController>/5
    [HttpGet("{id}")]
    public ActionResult<Tournament> GetById(int id)
    {
        Tournament? output = _tournamentService.GetById(id);

        if (output is null)
        {
            return NotFound();
        }

        return Ok(output.Adapt<TournamentResponse>());
    }

    // POST api/<TournamentController>
    [HttpPost]
    public void Post([FromBody] TournamentInsert insert, [FromServices] IValidator<TournamentInsert>? insertValidator = null, [FromServices] IValidator<Tournament>? tournamentValidator = null)
    {
        _tournamentService.Insert(insert, insertValidator, tournamentValidator);
    }

    // PUT api/<TournamentController>
    [HttpPut]
    public void Put([FromBody] TournamentUpdate update, [FromServices] IValidator<TournamentUpdate>? insertValidator = null, [FromServices] IValidator<Tournament>? tournamentValidator = null)
    {
        _tournamentService.Update(update, insertValidator, tournamentValidator);
    }

    // DELETE api/<TournamentController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _tournamentService.Remove(id);
    }
}