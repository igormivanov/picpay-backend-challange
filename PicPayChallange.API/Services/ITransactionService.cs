using Microsoft.EntityFrameworkCore.Storage;
using PicPayChallange.API.Models.Dtos;
using System.Data;

namespace PicPayChallange.API.Services {
    public interface ITransactionService {

        Task<Result<TransactionDTO>> CreateTransaction(TransactionRequestDTO transaction);

    }
}
