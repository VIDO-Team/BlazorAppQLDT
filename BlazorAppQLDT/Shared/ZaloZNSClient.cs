using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaloDotNetSDK;

namespace BlazorAppQLDT.Shared
{
    public class ZaloZNSClient:ZaloBaseClient
    {
        public string AccessToken { get; set; }
        public ZaloZNSClient(string accessToken)
        {
            AccessToken = accessToken;
        }
        public async Task<string> GetMessageQuota()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("access_token", AccessToken);
            HttpResponseMessage httpResponse = client.GetAsync("https://business.openapi.zalo.me/message/quota").GetAwaiter().GetResult();
            httpResponse.EnsureSuccessStatusCode();
            string responseString = await httpResponse.Content.ReadAsStringAsync();
            return responseString;
        }
        public async Task<string> SendZNS(string payload)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("access_token", AccessToken);
            HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = client.PostAsync("https://business.openapi.zalo.me/message/template", c).GetAwaiter().GetResult();
            httpResponse.EnsureSuccessStatusCode();
            string responseString = await httpResponse.Content.ReadAsStringAsync();
            return responseString;

            /*
            {
                "phone": "84987654321",
                "template_id": "7895417a7d3f9461cd2e",
                "template_data": {
                    "ky": "1",
                    "thang": "4/2020",
                    "start_date": "20/03/2020",
                    "end_date": "20/04/2020",
                    "customer": "Nguyễn Thị Hoàng Anh",
                    "cid": "PE010299485",
                    "address": "VNG Campus, TP.HCM",
                    "amount": "100",
                    "total": "100000",
                 },
                "tracking_id":"tracking_id"
            } */
        }
    }
}
