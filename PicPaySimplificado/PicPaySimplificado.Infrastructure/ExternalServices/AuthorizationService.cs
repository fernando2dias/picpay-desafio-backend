using PicPaySimplificado.Application.Interfaces;

namespace PicPaySimplificado.Infrastructure.ExternalServices
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly HttpClient _httpClient;

        public AuthorizationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> Authorize()
        {
            var response = await _httpClient.GetAsync("https://util.devi.tools/api/v2/authorize");

            return response.IsSuccessStatusCode;
        }
    }
}
