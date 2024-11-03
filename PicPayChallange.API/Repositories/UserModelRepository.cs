using PicPayChallange.API.Data;
using PicPayChallange.API.Models;

namespace PicPayChallange.API.Repositories {
    public class UserModelRepository : IUserModelRepository {

        private readonly AppDbContext _context;
        public UserModelRepository(AppDbContext context) {
            _context = context;
        }
        public async Task Create(UserModel user) {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<UserModel> findById(Guid id) {
            var user = await _context.Users.FindAsync(id);
            return user;

        }
    }
}
