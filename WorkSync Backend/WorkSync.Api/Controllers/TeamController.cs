using Microsoft.AspNetCore.Mvc;
using WorkSync.Application.DTOs;
using WorkSync.Application.Interfaces;

namespace WorkSync.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDto>>> GetAllTeamsAsync()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(teams);
        }

        [HttpGet("{id:guid}", Name = "GetTeamById")]
        public async Task<ActionResult<TeamDto>> GetTeamByIdAsync(Guid id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            if (team == null) return NotFound();
            return Ok(team);
        }

        [HttpPost]
        public async Task<ActionResult<TeamDto>> CreateTeamAsync(TeamDto teamDto)
        {
            var createdTeam = await _teamService.CreateTeamAsync(teamDto);
            return CreatedAtRoute(
    "GetTeamById",
    new { id = createdTeam.Id },
    createdTeam);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TeamDto>> UpdateTeamAsync(Guid id, TeamDto teamDto)
        {
            var updatedTeam = await _teamService.UpdateTeamAsync(id, teamDto);
            if (updatedTeam == null) return NotFound();
            return Ok(updatedTeam);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeamAsync(Guid id)
        {
            var deleted = await _teamService.DeleteTeamAsync(id);
            if (!deleted) return NotFound();
            return Ok();
        }
    }
}
