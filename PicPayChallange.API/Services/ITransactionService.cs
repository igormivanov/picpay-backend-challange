using PicPayChallange.API.Models.Dtos;

namespace PicPayChallange.API.Services {
    public interface ITransactionService {

        Task createTransaction(TransactionRequestDTO transaction);
    }
}
