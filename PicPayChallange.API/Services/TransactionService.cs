using Microsoft.EntityFrameworkCore.Storage;
using PicPayChallange.API.Mappers;
using PicPayChallange.API.Models;
using PicPayChallange.API.Models.Dtos;
using PicPayChallange.API.Models.Enums;
using PicPayChallange.API.Repositories;
using PicPayChallange.API.Services.Autorization;
using PicPayChallange.API.Services.Notify;

namespace PicPayChallange.API.Services {
    public class TransactionService : ITransactionService {

        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserModelRepository _userModelRepository;
        private readonly IAuthorizationApiService _authorizationService;
        private readonly INotifyApiService _notifyApiService;

        public TransactionService(ITransactionRepository transactionRepository, IUserModelRepository userModelRepository, IAuthorizationApiService authorizationService, INotifyApiService notifyApiService) {
            _transactionRepository = transactionRepository;
            _userModelRepository = userModelRepository;
            _authorizationService = authorizationService;
            _notifyApiService = notifyApiService;
        }

        public async Task<Result<TransactionDTO>> CreateTransaction(TransactionRequestDTO transaction) {

            if (!await _authorizationService.AuthorizationAsync()) {
                return Result<TransactionDTO>.Failure("Transação não autorizada");
            }

            var payer = await _userModelRepository.FindById(transaction.PayerId);
            var payee = await _userModelRepository.FindById(transaction.PayeeId);

            if (payer is null || payee is null) {
                return Result<TransactionDTO>.Failure("Nenhum usuário encontrado");
            }

            if (payer.UserType == UserType.LOJISTA) {
                return Result<TransactionDTO>.Failure("Lojista não pode realizar transferências");
            }

            if (payer.Balance < transaction.Amount && transaction.Amount != 0) {
                return Result<TransactionDTO>.Failure("Saldo insuficiente!");
            }



            var transactionModel = new TransactionModel {
                Id = Guid.NewGuid(),
                PayeeId = transaction.PayeeId,
                PayerId = transaction.PayerId,
                Amount = transaction.Amount,
                TransactionTime = DateTime.UtcNow,
            };

            payee.Balance += transaction.Amount;
            payer.Balance -= transaction.Amount;

            using var transactionContext = await _transactionRepository.BeginTransactionAsync();

            try {
                var tarefas = new List<Task> {
                    _userModelRepository.Update(payer),
                    _userModelRepository.Update(payee),
                    _transactionRepository.create(transactionModel)
                };

                await Task.WhenAll(tarefas);
                await CommitTransactionAsync(transactionContext);

                await _notifyApiService.sendNotification();
                return Result<TransactionDTO>.Success(transactionModel.ToTransactionDTO());

            } catch (Exception ex) {
                await transactionContext.RollbackAsync();

                return Result<TransactionDTO>.Failure(("Erro ao realizar a transaferência " + ex.Message));
            }   
        }

        private async Task CommitTransactionAsync(IDbContextTransaction transaction) {
            await _transactionRepository.CommitAsync();
            await transaction.CommitAsync();
        }

    }
}
