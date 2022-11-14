using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestSharp;

namespace ClarissaJoy.PrePrelimExam.Pages
{
    public class FormModel : PageModel
    {
        public CourseDetails? Course { get; set; }
        public WeatherData? Data { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var client = new RestClient("https://fcc-weather-api.glitch.me/api/");

            var request = new RestRequest("", Method.Get);

            RestResponse response = client.Execute(request);

            var content = response.Content;

            var area = JsonConvert.DeserializeObject<WeatherData>(content);

            return Page();
        }
        public class WeatherData
        {
            public List<WeatherDetails>? Weather { get; set; }
            public WeatherMain? Main { get; set; }
        }
        public class WeatherMain
        {
            public string? Temp { get; set; }
            public string? FeelsLike { get; set; }
            public string? Humidity { get; set; }
            public string? Pressure { get; set; }

        }

        public class WeatherDetails
        {
            public string? Main { get; set; }
            public string? Description { get; set; }
            public string? Icon { get; set; }
        }

       
        public class CourseDetails
        {
            public string? Abbreviation { get; set; }
            public string? Name { get; set; }
            public string? Numberofyears { get; set; }
            public string? Totalunit { get; set; }
            public string? DateOfEffectivity { get; set; }


        }
        public void OnPost()
        {

        }
    }
    }

