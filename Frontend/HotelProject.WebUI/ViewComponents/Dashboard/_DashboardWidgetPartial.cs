using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseStaffMessage = await client.GetAsync("http://localhost:28867/api/DashboardWidgets/GetStaffCount");

            var jsonStaffData = await responseStaffMessage.Content.ReadAsStringAsync();
            var StaffValues = JsonConvert.DeserializeObject<int>(jsonStaffData);
            ViewBag.StaffValues = StaffValues;

            var responseBookingMessage = await client.GetAsync("http://localhost:28867/api/DashboardWidgets/GetBookingCount");

            var jsonBookingData = await responseBookingMessage.Content.ReadAsStringAsync();
            var BookingValues = JsonConvert.DeserializeObject<int>(jsonBookingData);
            ViewBag.BookingValues = BookingValues;

            var responseAppUserMessage = await client.GetAsync("http://localhost:28867/api/DashboardWidgets/GetAppUserCount");

            var jsonAppUserData = await responseAppUserMessage.Content.ReadAsStringAsync();
            var AppUserValues = JsonConvert.DeserializeObject<int>(jsonAppUserData);
            ViewBag.AppUserValues = AppUserValues;

            var responseRoomMessage = await client.GetAsync("http://localhost:28867/api/DashboardWidgets/GetRoomCount");

            var jsonRoomData = await responseRoomMessage.Content.ReadAsStringAsync();
            var RoomValues = JsonConvert.DeserializeObject<int>(jsonRoomData);
            ViewBag.RoomValues = RoomValues;
            return View();
        }
    }
}
