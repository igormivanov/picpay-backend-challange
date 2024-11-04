using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PicPayChallange.API.Data;
using PicPayChallange.API.Models;
using System.Data;

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

        public async Task<UserModel> FindById(Guid id) {
            var user = await _context.Users.FindAsync(id);
            return user;

        }

        public async Task Update(UserModel user) {
            _context.Update(user);
        }
    }
}
