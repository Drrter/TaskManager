using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    public interface IUserRepository
    {
        Task<List<Users>> GetAllUsers();
        Task<Users> GetUserById(int id);
        Task AddUser(Users newUser);
        Task UpdateUser(int id, Users updatedUser);
        Task DeleteUser(int id);
    }
    public class UserRepository:IUserRepository
    {
        private readonly TaskContext _context;

        public UserRepository(TaskContext context)
        {
            _context = context;
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddUser(Users newUser)
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(int id, Users updatedUser)
        {
            _context.Entry(updatedUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var userToDelete = await _context.Users.FindAsync(id);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
    public class UsersService
    {
        private readonly IUserRepository _userRepository;
        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<Users> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }
        public async Task AddUser(Users newUser)
        {
            await _userRepository.AddUser(newUser);
        }

        public async Task UpdateUser(Users updatedUser)
        {
            await _userRepository.UpdateUser(updatedUser.IdUser, updatedUser);
        }
        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
        }
    }
}
