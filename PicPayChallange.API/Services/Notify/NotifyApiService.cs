
namespace PicPayChallange.API.Services.Notify {
    public class NotifyApiService : INotifyApiService {

        private readonly HttpClient _httpClient;

        public NotifyApiService(IHttpClientFactory httpClientFactory) {
            _httpClient = httpClientFactory.CreateClient("Notify");
        }

        public async Task sendNotification() {
            var httpResponse = await _httpClient.PostAsync("notify", null);  
        }
    }
}
