using Microsoft.AspNetCore.Mvc;
using TournamentsRegister.Models;
using TournamentsRegister.Models.Requests;
using TournamentsRegister.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TournamentsRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        public PlayerController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        private readonly PlayerService _playerService;

        // GET: api/<PlayerController>
        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return _playerService.GetAll();
        }

        // GET api/<PlayerController>/team/5
        [HttpGet("team/{teamID}")]
        public IEnumerable<Player> Get(int teamID)
        {
            return _playerService.GetAllFromTeam(teamID);
        }

        // POST api/<PlayerController>
        [HttpPost]
        public void Post([FromBody] PlayerInsert insert)
        {
            _playerService.Insert(insert);
        }

        // PUT api/<PlayerController>/5
        [HttpPut]
        public void Put([FromBody] PlayerUpdate update)
        {
            _playerService.Update(update);
        }

        // DELETE api/<PlayerController>/5
        [HttpDelete]
        public void Delete([FromBody] PlayerDelete delete)
        {
            _playerService.RemoveFromRequest(delete);
        }
    }
}
