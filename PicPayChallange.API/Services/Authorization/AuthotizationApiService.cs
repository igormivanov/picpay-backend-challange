
namespace PicPayChallange.API.Services.Autorization {
    public class AuthorizationApiService : IAuthorizationApiService {

        private readonly HttpClient _httpClient;

        public AuthorizationApiService(IHttpClientFactory httpClientFactory) {
            _httpClient = httpClientFactory.CreateClient("Authorization");
        }

        public async Task<bool> AuthorizationAsync() {

            var httpResponse = await _httpClient.GetAsync("authorize");

            if(!httpResponse.IsSuccessStatusCode) {
                return false;
            }

            var response = await httpResponse.Content.ReadFromJsonAsync<ApiResponse>();

            if (response == null) {
                return false;
            }

            return response.data.authorization;
        }

        private class ApiResponse {
            public string status { get; set; }
            public DataResponse data { get; set; }
        }

        private class DataResponse {
            public bool authorization { get; set; }
        }
    }
}
