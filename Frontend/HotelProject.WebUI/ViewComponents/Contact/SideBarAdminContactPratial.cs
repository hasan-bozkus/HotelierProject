using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Contact
{
    public class SideBarAdminContactPratial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SideBarAdminContactPratial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:28867/api/Contact/GetContactCount");
            var responseMessage2 = await client.GetAsync("http://localhost:28867/api/SendMessage/GetSendMessageCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<int>(jsonData);
                var values2 = JsonConvert.DeserializeObject<int>(jsonData2);
                ViewBag.contactCount = values;
                ViewBag.SendMessageCount = values2;
                return View();
            }
            return View();
        }
    }
}
