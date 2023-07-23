using DtoLayer.DTOS.TeamDtos;
using DtoLayer.DTOS.WhatWedoDtos;
using Homish.ApiConsume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Homish.ApiConsume.Controllers
{
    public class AdminWhatWedoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminWhatWedoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:5001/api/WhatWedo");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WhatWedoViewModel>(jsonData);
                return View(values.Data);


            }
            return View();
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateWhatWedoDto createWhatWedoDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(createWhatWedoDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5001/api/WhatWedo", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:5001/api/WhatWedo/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:5001/api/WhatWedo/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateWhatWedoViewModel>(jsonData);
                return View(values.Data);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateWhatWedoDto updateWhatWedoDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(updateWhatWedoDto), Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:5001/api/WhatWedo/", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
