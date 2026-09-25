using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSync.Application.Interfaces;
using WorkSync.Domain.Entities;
using WorkSync.Infrastructure.Data;

namespace WorkSync.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly WorkSyncDbContext _context;
        public TeamRepository(WorkSyncDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Team?> GetTeamByIdAsync(Guid id)
        {
            return await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Team> CreateTeamAsync(Team team)
        {
           await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<Team> UpdateTeamAsync(Team team)
        {
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<bool> DeleteTeamAsync(Team team)
        {
            _context.Teams.Remove(team);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
