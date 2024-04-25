using Blogy.WEBUI.Areas.Writer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blogy.WEBUI.Areas.Writer.ViewComponents
{
    public class _DashboardWeatherComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://weatherapi-com.p.rapidapi.com/forecast.json?q=kocaeli&days=7"),
                Headers =
    {
        { "X-RapidAPI-Key", "993ab9c561msh7beed076fa1064ap1dae43jsnd1ee335b10e2" },
        { "X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WeatherApiViewModel>(body);
                return View(values);
            }
        }
    }
}
