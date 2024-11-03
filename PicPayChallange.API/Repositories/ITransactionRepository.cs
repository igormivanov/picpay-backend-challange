using PicPayChallange.API.Models;

namespace PicPayChallange.API.Repositories {
    public interface ITransactionRepository {

        Task create(TransactionModel transaction);
    }
}
