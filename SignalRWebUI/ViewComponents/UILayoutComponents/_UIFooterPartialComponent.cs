﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ContactDtos;
using SignalRWebUI.Dtos.SocialMediaDtos;
using System.Net.Http;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UIFooterPartialComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UIFooterPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7215/api/SocialMedia");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
            return View(values);
         
        }
    }
}
