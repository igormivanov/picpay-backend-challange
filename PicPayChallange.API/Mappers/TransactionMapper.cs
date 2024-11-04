using PicPayChallange.API.Models;
using PicPayChallange.API.Models.Dtos;

namespace PicPayChallange.API.Mappers {
    public static class TransactionMapper {

        public static TransactionDTO ToTransactionDTO(this TransactionModel transactionModel) {
            return new TransactionDTO( 
               transactionModel.Id,
               transactionModel.Payer,
               transactionModel.Payee,
               transactionModel.Amount
            );
        }
    }
}
