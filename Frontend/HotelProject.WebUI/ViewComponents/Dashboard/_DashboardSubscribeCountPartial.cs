using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardSubscribeCountPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

    //        var clientInsatgram = new HttpClient();
    //        var requestInsatgram = new HttpRequestMessage
    //        {
    //            Method = HttpMethod.Get,
    //            RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/hasanbozkus0147"),
    //            Headers =
    //{
    //    { "X-RapidAPI-Key", "ed4693dd4dmshe4efd10c64d8550p1121dcjsnc10d6dbd4cb7" },
    //    { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    //},
    //        };
    //        using (var response = await clientInsatgram.SendAsync(requestInsatgram))
    //        {
    //            response.EnsureSuccessStatusCode();
    //            var bodyInstagram = await response.Content.ReadAsStringAsync();
    //            ResultInstagramFollowersDto resultInstagramFollowersDtos = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(bodyInstagram);
    //            ViewBag.instagramFollowers = resultInstagramFollowersDtos.followers;
    //            ViewBag.instagramFollowing = resultInstagramFollowersDtos.following;               
    //        }

            var clientTwitter = new HttpClient();
            var requestTwitter = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter32.p.rapidapi.com/getProfile?username=HHasanBozkus"),
                Headers =
    {
        { "X-RapidAPI-Key", "ed4693dd4dmshe4efd10c64d8550p1121dcjsnc10d6dbd4cb7" },
        { "X-RapidAPI-Host", "twitter32.p.rapidapi.com" },
    },
            };
            using (var response = await clientTwitter.SendAsync(requestTwitter))
            {
                response.EnsureSuccessStatusCode();
                var bodyTwitter = await response.Content.ReadAsStringAsync();
                ResultTwitterFollowersDto resultTwitterFollowersDto = JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(bodyTwitter);
                ViewBag.twitterFollowers = resultTwitterFollowersDto.data.user_info.followers_count;
                ViewBag.twitterFollowing = resultTwitterFollowersDto.data.user_info.friends_count;                
            }

            var clientLinkedin = new HttpClient();
            var requestLinkedin = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fhasan-bozku%25C5%259F-782355262%2F&include_skills=false"),
                Headers =
    {
        { "X-RapidAPI-Key", "ed4693dd4dmshe4efd10c64d8550p1121dcjsnc10d6dbd4cb7" },
        { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var responseLinkedin = await clientLinkedin.SendAsync(requestLinkedin))
            {
                responseLinkedin.EnsureSuccessStatusCode();
                var bodyLinkedin = await responseLinkedin.Content.ReadAsStringAsync();
                ResultLinkedinFollowersDto resultLinkedinFollowersDto = JsonConvert.DeserializeObject<ResultLinkedinFollowersDto>(bodyLinkedin);
                ViewBag.linkedinFollowers = resultLinkedinFollowersDto.data.followers_count;
            }

            return View();
        }
    }
}
