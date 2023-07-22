using Homish.ApiConsume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Homish.ApiConsume.ViewComponents.Default
{
    public class _Testimonial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _Testimonial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:5001/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TestimonialViewModel>(jsonData);
                return View(values.Data);


            }
            return View();
        }
    }
}
