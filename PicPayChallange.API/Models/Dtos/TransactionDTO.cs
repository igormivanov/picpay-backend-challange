namespace PicPayChallange.API.Models.Dtos {
    public record TransactionDTO(
        Guid transacionId,
        UserModel payer,
        UserModel payee,
        decimal transferValue
        ) {
    }
}
