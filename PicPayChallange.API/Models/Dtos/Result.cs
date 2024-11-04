namespace PicPayChallange.API.Models.Dtos {
    public class Result<T> {

        public bool IsSuccess {  get; private set; }
        public string ErrorMessage { get; private set; }
        public T Value { get; private set; }

        private Result(bool isSuccess, T value, string errorMessage) {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Value = value;
        }

        private Result(bool isSuccess) {
            IsSuccess = isSuccess;
        }

        public static Result<T> Success(T value) {
            return new Result<T>(true, value, null);
        }

        public static Result<T> Failure(string errorMessage) {
            return new Result<T>(false, default, errorMessage);
        }
    }
}
