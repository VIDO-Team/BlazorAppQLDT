using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Forms;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using ZaloDotNetSDK;
using System.Text;
namespace BlazorAppQLDT.Client.Services.SinhvienCD18Service
{
    public class SinhvienCD18Service : ISinhvienCD18Service
    {
        public readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public List<SinhvienCD18Model> Sinhvienservices { get; set; } = new List<SinhvienCD18Model>();
        public ApplicationConfig ApplicationConfigservices { get; set; } = new ApplicationConfig();
        public SinhvienCD18Service(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public async Task GetSinhvienDetail()
        {
            var resutl = await _http.GetFromJsonAsync<List<SinhvienCD18Model>>("api/sinhvienCD18");
            if (resutl != null)
            {
                Sinhvienservices = resutl;
            }
        }
        public async Task CreateSinhvien(SinhvienCD18Model student)
        {
            var result = await _http.PostAsJsonAsync("api/sinhvienCD18", student);
            await SetSinhvien(result);
        }

        private async Task SetSinhvien(HttpResponseMessage result)
        {
            Console.WriteLine(result.StatusCode);
            _navigationManager.NavigateTo("CD18");
        }

        public async Task UpdateSinhvien(SinhvienCD18Model student)
        {
            var result = await _http.PutAsJsonAsync($"api/sinhvienCD18/{student.Id}", student);
            await SetSinhvien(result);
        }

        public async Task<SinhvienCD18Model> GetSingleSinhvien(int id)
        {
            var result = await _http.GetFromJsonAsync<SinhvienCD18Model>($"api/sinhvienCD18/{id}");
            if (result != null)
                return result;
            throw new Exception("Student not found!");
        }

        public async Task DeleteSinhvien(int id)
        {
            var result = await _http.DeleteAsync($"api/sinhvienCD18/{id}");
            await SetSinhvien(result);
        }
        public async Task SearchSinhvien(string name)
        {
            var resutl = await _http.GetFromJsonAsync<List<SinhvienCD18Model>>($"api/sinhvienCD18/search/{name}");
            if (resutl != null)
            {
                Sinhvienservices = resutl;
            }
        }
        public async Task GetApplicationConfig()
        {
            var resutl = await _http.GetFromJsonAsync<ApplicationConfig>("api/sinhvienCD18/applicationconfig");
            if (resutl != null)
            {
                ApplicationConfigservices = resutl;
            }
        }
        public async Task<string> GetMessageQuota()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponse = client.GetAsync("https://business.openapi.zalo.me/message/quota").GetAwaiter().GetResult();
            httpResponse.EnsureSuccessStatusCode();
            string responseString = await httpResponse.Content.ReadAsStringAsync();
            return responseString;
        }
        public async Task<string> SendZNS(string payload)
        {
            ZaloZNSClient zaloZNS = new ZaloZNSClient(ApplicationConfigservices.AccessToken);
            _http.DefaultRequestHeaders.Add("access_token", zaloZNS.AccessToken);
            Console.WriteLine(payload);
            return payload;
            //return await zaloZNS.SendZNS(payload);

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
