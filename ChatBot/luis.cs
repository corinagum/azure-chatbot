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

        public static async Task<stockLUIS> ParseUserInput(string strInput)
        {
            string strRet = string.Empty;
            //string strEscaped = Uri.EscapeDataString(strInput);

            using (var client = new HttpClient())
            {
                string uri = "https://api.projectoxford.ai/luis/v1/application?id=ae1e26d3-1a9e-4b1a-b6a9-ec711b25eced&subscription-key=d9ee5df0dbaa48458789f025460b8aa1&q=i%20want%20to%20ssh%20into%20my%20virtual%20machine";
                HttpResponseMessage msg = await client.GetAsync(uri);

                if (msg.IsSuccessStatusCode)
                {
                    var jsonResponse = await msg.Content.ReadAsStringAsync();
                    var _Data = JsonConvert.DeserializeObject<stockLUIS>(jsonResponse);
                    return _Data;
                }
                else
                    return null;
            }
        }
    }


    public class stockLUIS
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