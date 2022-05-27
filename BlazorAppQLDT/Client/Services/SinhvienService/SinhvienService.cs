using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Forms;
using System.Text;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace BlazorAppQLDT.Client.Services.SinhvienService
{
    public class SinhvienService : ISinhvienService
    {
        public readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        DataTable dataTable = new DataTable();
        public List<SinhvienModel> Sinhvienservices { get; set; } = new List<SinhvienModel>();
        public List<ApplicationConfig> ApplicationConfigservices { get; set; } = new List<ApplicationConfig>();
        public SinhvienService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public async Task GetSinhvienDetail()
        {
            var resutl = await _http.GetFromJsonAsync<List<SinhvienModel>>("api/sinhvien");
            if (resutl != null)
            {
                Sinhvienservices = resutl;
            }
        }
        public async Task CreateSinhvien(SinhvienModel student)
        {
            var result = await _http.PostAsJsonAsync("api/sinhvien", student);
            await SetSinhvien(result);
        }

        private async Task SetSinhvien(HttpResponseMessage result)
        {
            Console.WriteLine(result.StatusCode);
            _navigationManager.NavigateTo("sinhvien");
        }

        public async Task UpdateSinhvien(SinhvienModel student)
        {
            var result = await _http.PutAsJsonAsync($"api/sinhvien/{student.Id}", student);
            await SetSinhvien(result);
        }

        public async Task<SinhvienModel> GetSingleSinhvien(int id)
        {
            var result = await _http.GetFromJsonAsync<SinhvienModel>($"api/sinhvien/{id}");
            if (result != null)
                return result;
            throw new Exception("Student not found!");
        }

        public async Task DeleteSinhvien(int id)
        {
            var result = await _http.DeleteAsync($"api/sinhvien/{id}");
            await SetSinhvien(result);
        }

        public async Task SearchSinhvien(string name)
        {
            var resutl = await _http.GetFromJsonAsync<List<SinhvienModel>>($"api/sinhvien/search/{name}");
            if (resutl != null)
            {
                Sinhvienservices = resutl;
            }
        }
        public async Task GetApplicationConfig()
        {
            var resutl = await _http.GetFromJsonAsync<List<ApplicationConfig>>("api/sinhvienCD15/applicationconfig");
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
            HttpClient client = new HttpClient();
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
