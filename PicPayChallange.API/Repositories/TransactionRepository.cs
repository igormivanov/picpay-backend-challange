using Microsoft.EntityFrameworkCore.Storage;
using PicPayChallange.API.Data;
using PicPayChallange.API.Models;

namespace PicPayChallange.API.Repositories {
    public class TransactionRepository : ITransactionRepository {

        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync() {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync() {
            await _context.SaveChangesAsync();
        }

        public async Task create(TransactionModel transaction) {
            await _context.Transactions.AddAsync(transaction);
        }
    }
}
