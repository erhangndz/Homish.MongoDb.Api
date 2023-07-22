using Homish.ApiConsume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Homish.ApiConsume.ViewComponents.Default
{
    public class _About : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _About(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:5001/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<AboutViewModel>(jsonData);
                return View(values.Data);


            }
            return View();
        }
    }
}
