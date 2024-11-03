using Microsoft.EntityFrameworkCore;
using PicPayChallange.API.Data.Configurations;
using PicPayChallange.API.Models;

namespace PicPayChallange.API.Data {
    public class AppDbContext : DbContext{

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserModel> Users {  get; set; }
        public DbSet<TransactionModel> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new TransactionModelConfiguration());
            modelBuilder.ApplyConfiguration(new UserModelConfiguration());
        }
    }
}
