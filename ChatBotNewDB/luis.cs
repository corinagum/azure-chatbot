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
                string uri = "https://api.projectoxford.ai/luis/v1/application?id=26ed7d66-9f1a-4ca2-8c49-ff2253b0e4b9&subscription-key=4f3d135e368c48ae85ecdbb398fc4199&q=" + strInput;
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

    public partial class Intent
    {
        public string intent { get; set; }
        public float score { get; set; }
    }

}