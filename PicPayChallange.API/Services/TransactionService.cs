using PicPayChallange.API.Models;
using PicPayChallange.API.Models.Dtos;
using PicPayChallange.API.Models.Enums;
using PicPayChallange.API.Repositories;

namespace PicPayChallange.API.Services {
    public class TransactionService  {

        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserModelService _userModelService;

        public TransactionService(ITransactionRepository transactionRepository, IUserModelService userModelService) {
            _transactionRepository = transactionRepository;
            _userModelService = userModelService;
        }

        public async Task createTransaction(TransactionRequestDTO transaction) {

            var payer = await _userModelService.FindById(transaction.PayerId);
            var payee = await _userModelService.FindById(transaction.PayeeId);

            if (payer.UserType == UserType.LOJISTA) {
                throw new Exception();
            }

            if (payer.Balance < transaction.Amount) {
                throw new Exception();
            }

            var transactionModel = new TransactionModel {
                Id = Guid.NewGuid(),
                PayeeId = transaction.PayerId,
                PayerId = transaction.PayerId,
                Amount = transaction.Amount,
                TransactionTime = DateTime.UtcNow,
            };

            await _transactionRepository.create(transactionModel);
        }

        private bool ValidateTransaction(UserModel payer, decimal amount) {

            if (payer.UserType == UserType.LOJISTA) {
                throw new Exception();
            }

            if (payer.Balance < amount) {
                throw new Exception();
            }

            return true;
        }

    }
}
