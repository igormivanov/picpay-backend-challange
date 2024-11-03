using PicPayChallange.API.Models.Enums;

namespace PicPayChallange.API.Models.Dtos {
    public record UserModelRequestDTO(
        string FullName,
        string CPF,
        string Email,
        string Password,
        UserType UserType,
        decimal Balance
    ) {
    }
}
