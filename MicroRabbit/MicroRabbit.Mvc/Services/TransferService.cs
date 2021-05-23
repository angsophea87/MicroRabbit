using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using MicroRabbit.Mvc.Models.Dto;
using Newtonsoft.Json;

namespace MicroRabbit.Mvc.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;

        public TransferService(HttpClient apiClient) {
            _apiClient = apiClient;
        }

        public async Task Transfer(TransferDto transferDto) {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(transferDto), Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await _apiClient.PostAsync("https://localhost:5001/api/banking/accounts/transfer-funds", jsonContent);
            response.EnsureSuccessStatusCode();
        }

        /*services.AddHttpClient<IOrderManagementApi, OrderManagementApi>();*/
            /*services.AddRefitClient<ICountryRepository>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(Configuration.GetSection("Apis:CountryApi:Url").Value));*/

        /*public OrderManagementApi(IConfiguration config, HttpClient httpClient)
        {
            string apiHostAndPort = config.GetSection("ApiServiceLocations").
                GetValue<string>("OrdersApiLocation");
            httpClient.BaseAddress = new Uri($"http://{apiHostAndPort}/api");
            _restClient = RestService.For<IOrderManagementApi>(httpClient);

        }*/
    }
}
