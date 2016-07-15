using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChatBot
{
    public class Weather
    {
        public static async Task<string> GetWeatherAsync(string city)
        {
            //string openWeatherUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&APPID=2b87a40c6a1ed2a5c9d2683ce6641c3d";
            //string jsonWeatherInfo;
            //using (WebClient client = new WebClient())
            //{
            //    jsonWeatherInfo = await client.DownloadStringTaskAsync(openWeatherUrl).ConfigureAwait(false);
            //}

            //JObject parsedInfo;
            //using (WebClient client = new WebClient())
            //{
            //    parsedInfo = JsonConvert.DeserializeObject<dynamic>(await client.DownloadStringTaskAsync(openWeatherUrl).ConfigureAwait(false));
            //}
            //var temp = (double)parsedInfo.First.Next.Next.Next.First.First.First * 1.8 - 459.67;

            //return Math.Floor(temp).ToString();

            string json = @"{""temp"": 294.782,""pressure"": 970.41,""humidity"": 59,""temp_min"": 294.782,""temp_max"": 294.782,""sea_level"": 1023.41,""grnd_level"": 970.41}";
            Info info = new Info();
            JsonConvert.PopulateObject(json, info);

            return "blah";
        }
        
    }

    public class Info
    {
        public double temp { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
    }

}