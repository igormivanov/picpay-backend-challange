namespace PicPayChallange.API.Models {
    public class WalletModel {

        public Guid Id { get; set; }
        public decimal Balance { get; set; }
        public DateTime UpdateAt { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
    }
}
