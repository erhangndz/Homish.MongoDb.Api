using AutoMapper;
using DtoLayer.DTOS.BannerDtos;
using Homish.ApiConsume.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Homish.ApiConsume.ViewComponents.Default
{
    public class _Banner:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
  

        public _Banner(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
         
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:5001/api/Banner");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BannerViewModel>(jsonData);
                return View(values.Data);

              
            }
            return View();
            
        }
    }
}
