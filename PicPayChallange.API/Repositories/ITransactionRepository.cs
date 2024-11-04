using Microsoft.EntityFrameworkCore.Storage;
using PicPayChallange.API.Models;

namespace PicPayChallange.API.Repositories {
    public interface ITransactionRepository {

        Task create(TransactionModel transaction);
        Task CommitAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
