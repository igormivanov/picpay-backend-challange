using PicPayChallange.API.Models.Enums;

namespace PicPayChallange.API.Models {
    public class UserModel {

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string CPF {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public decimal Balance { get; set; }

    }
}
