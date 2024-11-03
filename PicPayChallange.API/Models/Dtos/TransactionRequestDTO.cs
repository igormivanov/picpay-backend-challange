namespace PicPayChallange.API.Models.Dtos {
    public record TransactionRequestDTO(
        decimal Amount,  
        Guid PayerId ,
        Guid PayeeId
        ) {
    }
}
