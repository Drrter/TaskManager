using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    public interface ITeamMembersRepository
    {
        Task<IEnumerable<TeamMembers>> GetAllTeamMembers();
        Task<TeamMembers> GetTeamMemberByIdTeam(int idTeam);
        Task<TeamMembers> GetTeamMemberByIdUser(int idUser);
        Task DeleteTeamMember(int idTeam, int idUser);
        Task AddMember(TeamMembers newMember);
    }
    public class TeamMembersRepository : ITeamMembersRepository
    {
        private readonly TaskContext _context;

        public TeamMembersRepository(TaskContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeamMembers>> GetAllTeamMembers()
        {
            return await _context.TeamMembers.ToListAsync();
        }

        public async Task<TeamMembers> GetTeamMemberByIdTeam(int idTeam)
        {
            return await _context.TeamMembers.FirstOrDefaultAsync(tm => tm.IdTeam == idTeam);
        }

        public async Task<TeamMembers> GetTeamMemberByIdUser(int idUser)
        {
            return await _context.TeamMembers.FirstOrDefaultAsync(tm => tm.IdUser == idUser);
        }


        public async Task DeleteTeamMember(int idTeam, int idUser)
        {
            var teamMember = await _context.TeamMembers.FirstOrDefaultAsync(tm => tm.IdTeam == idTeam && tm.IdUser == idUser);
            if (teamMember != null)
            {
                _context.TeamMembers.Remove(teamMember);
                await _context.SaveChangesAsync();
            }
        }
    
         public async Task AddMember(TeamMembers newMember)
        {
            _context.TeamMembers.Add(newMember);
            await _context.SaveChangesAsync();
        }

    }
    public class TeamMembersService
    {
        private readonly ITeamMembersRepository _teamMembersRepository;
        public TeamMembersService(ITeamMembersRepository teamMembersRepository)
        {
            _teamMembersRepository = teamMembersRepository;
        }
        public async Task<IEnumerable<TeamMembers>> GetAllTeamMembers()
        {
            return await _teamMembersRepository.GetAllTeamMembers();
        }

        public async Task<TeamMembers> GetTeamMemberByIdTeam(int idTeam)
        {
            return await _teamMembersRepository.GetTeamMemberByIdTeam(idTeam);
        }

        public async Task<TeamMembers> GetTeamMemberByIdUser(int idUser)
        {
            return await _teamMembersRepository.GetTeamMemberByIdUser(idUser);
        }

        public async Task DeleteTeamMember(int idTeam, int idUser)
        {
            await _teamMembersRepository.DeleteTeamMember(idTeam, idUser);
        }
        public async Task AddMember(TeamMembers newMember)
        {
            await _teamMembersRepository.AddMember(newMember);
        }

    }
}
