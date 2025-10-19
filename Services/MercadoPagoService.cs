using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HBoostUltra.Services
{
    public class MercadoPagoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _accessToken;

        public MercadoPagoService()
        {
            _httpClient = new HttpClient();
            _accessToken = "APP_USR-TU_ACCESS_TOKEN_DE_PRODUCCION"; // 👈 reemplazá con tu token real
            _httpClient.BaseAddress = new System.Uri("https://api.mercadopago.com/");
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _accessToken);
        }

        public async Task<string> CrearPreferenciaAsync()
        {
            var preferencia = new
            {
                items = new[]
                {
                    new
                    {
                        title = "H-Boost Ultra",
                        quantity = 1,
                        unit_price = 10.00,
                        currency_id = "ARS"
                    }
                },
                back_urls = new
                {
                    success = "https://tu-sitio.com/exito",
                    failure = "https://tu-sitio.com/error",
                    pending = "https://tu-sitio.com/pendiente"
                },
                auto_return = "approved"
            };

            var json = JsonSerializer.Serialize(preferencia);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("checkout/preferences", content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error creando preferencia MercadoPago: {error}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(responseBody);
            string preferenceId = doc.RootElement.GetProperty("id").GetString();

            return preferenceId;
        }
    }
}
