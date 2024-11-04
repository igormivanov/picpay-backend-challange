namespace PicPayChallange.API.Services.Autorization {
    public interface IAuthorizationApiService {

        Task<bool> AuthorizationAsync();
    }
}
