using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSync.Application.DTOs;
using WorkSync.Application.Interfaces;
using WorkSync.Domain.Entities;

namespace WorkSync.Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<TeamDto>> GetAllTeamsAsync()
        {
            var teams = await _teamRepository.GetAllTeamsAsync();
            return teams.Select(t => new TeamDto
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description
            });
        }

        public async Task<TeamDto?> GetTeamByIdAsync(Guid id)
        {
            var team = await _teamRepository.GetTeamByIdAsync(id);
            if (team == null) return null;
            return new TeamDto
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description
            };
        }

        public async Task<TeamDto> CreateTeamAsync(TeamDto teamDto)
        {
            var team = new Team
            {
                Id = Guid.NewGuid(),
                Name = teamDto.Name,
                Description = teamDto.Description
            };
            var createdTeam = await _teamRepository.CreateTeamAsync(team);
            return new TeamDto
            {
                Id = createdTeam.Id,
                Name = createdTeam.Name,
                Description = createdTeam.Description
            };
        }

        public async Task<TeamDto> UpdateTeamAsync(Guid id, TeamDto teamDto)
        {
            var existingTeam = await _teamRepository.GetTeamByIdAsync(id);
            if (existingTeam == null) throw new Exception("Team not found");
            existingTeam.Name = teamDto.Name;
            existingTeam.Description = teamDto.Description;
            var updatedTeam = await _teamRepository.UpdateTeamAsync(existingTeam);
            return new TeamDto
            {
                Id = updatedTeam.Id,
                Name = updatedTeam.Name,
                Description = updatedTeam.Description
            };
        }

        public async Task<bool> DeleteTeamAsync(Guid id)
        {
            var existingTeam = await _teamRepository.GetTeamByIdAsync(id);
            if (existingTeam == null) throw new Exception("Team not found");
            return await _teamRepository.DeleteTeamAsync(existingTeam);
        }
    }
}
