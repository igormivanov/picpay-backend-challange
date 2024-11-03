using PicPayChallange.API.Data;
using PicPayChallange.API.Models;

namespace PicPayChallange.API.Repositories {
    public class TransactionRepository : ITransactionRepository {

        private readonly AppDbContext _appDbContext;

        public TransactionRepository(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        public async Task create(TransactionModel transaction) {
            _appDbContext.Add(transaction);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
