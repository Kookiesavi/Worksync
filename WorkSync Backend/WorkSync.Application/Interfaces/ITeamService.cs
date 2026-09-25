using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSync.Application.DTOs;

namespace WorkSync.Application.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDto>> GetAllTeamsAsync();
        Task<TeamDto?> GetTeamByIdAsync(Guid id);
        Task<TeamDto> CreateTeamAsync(TeamDto teamDto);
        Task<TeamDto> UpdateTeamAsync(Guid id,TeamDto teamDto);
        Task<bool> DeleteTeamAsync(Guid id);

    }
}
