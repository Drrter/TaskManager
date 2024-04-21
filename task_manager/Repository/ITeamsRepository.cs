using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    public interface ITeamsRepository
    {
        Task<List<Teams>> GetAllTeams();
        Task<Teams> GetTeamById(int id);
        Task AddTeam(Teams newTeam);
        Task UpdateTeam(int id, Teams updatedTeam);
        Task DeleteTeam(int id);
    }
    public class TeamsRepository:ITeamsRepository
    {
        private readonly TaskContext _context;

        public TeamsRepository(TaskContext context)
        {
            _context = context;
        }

        public async Task<List<Teams>> GetAllTeams()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Teams> GetTeamById(int id)
        {
            return await _context.Teams.FindAsync(id);
        }

        public async Task AddTeam(Teams newTeam)
        {
            _context.Teams.Add(newTeam);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTeam(int id, Teams updatedTeam)
        {
            _context.Entry(updatedTeam).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeam(int id)
        {
            var teamToDelete = await _context.Teams.FindAsync(id);
            if (teamToDelete != null)
            {
                _context.Teams.Remove(teamToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
    public class TeamsService
    {
        private readonly ITeamsRepository _teamsRepository;
        public TeamsService(ITeamsRepository teamRepository)
        {
            _teamsRepository = teamRepository;
        }

        public async Task<List<Teams>> GetAllTeams()
        {
            return await _teamsRepository.GetAllTeams();
        }

        public async Task<Teams> GetTeamById(int id)
        {
            return await _teamsRepository.GetTeamById(id);
        }
        public async Task AddTeam(Teams newTeam)
        {
            await _teamsRepository.AddTeam(newTeam);
        }

        public async Task UpdateTeam(Teams updatedTeam)
        {
            await _teamsRepository.UpdateTeam(updatedTeam.IdTeam, updatedTeam);
        }
        public async Task DeleteTeam(int id)
        {
            await _teamsRepository.DeleteTeam(id);
        }
    }
}
