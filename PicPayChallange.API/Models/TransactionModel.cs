namespace PicPayChallange.API.Models {
    public class TransactionModel {

        public Guid Id{ get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionTime { get; set; }
        public Guid PayerId { get; set; }
        public UserModel Payer { get; set; }
        public Guid PayeeId { get; set; }
        public UserModel Payee { get; set; }
        
    }
}
