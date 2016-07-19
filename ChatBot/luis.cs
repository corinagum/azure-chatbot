using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ChatBot
{
    public class LUISTypeParser
    {

        public static async Task<supportLUIS> ParseUserInput(string strInput)
        {
            string strRet = string.Empty;
            using (var client = new HttpClient())
            {
                string uri = "https://api.projectoxford.ai/luis/v1/application?id=ae1e26d3-1a9e-4b1a-b6a9-ec711b25eced&subscription-key=d9ee5df0dbaa48458789f025460b8aa1&q="+strInput;
                HttpResponseMessage msg = await client.GetAsync(uri);

                if (msg.IsSuccessStatusCode)
                {
                    var jsonResponse = await msg.Content.ReadAsStringAsync();
                    var _Data = JsonConvert.DeserializeObject<supportLUIS>(jsonResponse);
                    return _Data;
                }
                else
                    return null;
            }
        }
    }


    public class supportLUIS
    {
        public string query { get; set; }
        public Intent[] intents { get; set; }
        public object[] entities { get; set; }
    }

    public class Intent
    {
        public string intent { get; set; }
        public float score { get; set; }
    }

}