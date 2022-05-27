using System.Text;
using Microsoft.AspNetCore.Components;
namespace BlazorAppQLDT.Client.Services.SinhvienCD15Service
{
    public class SinhvienCD15Service : ISinhvienCD15Service
    {
        public readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public List<SinhvienCD15Model> Sinhvienservices { get; set; } = new List<SinhvienCD15Model>();
        public ApplicationConfig ApplicationConfigservices { get; set; } = new ApplicationConfig();
        public SinhvienCD15Service(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public async Task GetSinhvienDetail()
        {
            var resutl = await _http.GetFromJsonAsync<List<SinhvienCD15Model>>("api/sinhvienCD15");
            if (resutl != null)
            {
                Sinhvienservices = resutl;
            }
        }
        public async Task CreateSinhvien(SinhvienCD15Model student)
        {
            var result = await _http.PostAsJsonAsync("api/sinhvienCD15", student);
            await SetSinhvien(result);
        }

        private async Task SetSinhvien(HttpResponseMessage result)
        {
            Console.WriteLine(result.StatusCode);
            _navigationManager.NavigateTo("CD15");
        }
        public async Task SearchSinhvien(string name)
        {
            var resutl = await _http.GetFromJsonAsync<List<SinhvienCD15Model>>($"api/sinhvienCD15/search/{name}");
            if (resutl != null)
            {
                Sinhvienservices = resutl;
            }
        }
        public async Task UpdateSinhvien(SinhvienCD15Model student)
        {
            var result = await _http.PutAsJsonAsync($"api/sinhvienCD15/{student.Id}", student);
            await SetSinhvien(result);
        }

        public async Task<SinhvienCD15Model> GetSingleSinhvien(int id)
        {
            var result = await _http.GetFromJsonAsync<SinhvienCD15Model>($"api/sinhvienCD15/{id}");
            if (result != null)
                return result;
            throw new Exception("Student not found!");
        }

        public async Task DeleteSinhvien(int id)
        {
            var result = await _http.DeleteAsync($"api/sinhvienCD15/{id}");
            await SetSinhvien(result);
        }

        public async Task GetApplicationConfig()
        {
            var resutl = await _http.GetFromJsonAsync<ApplicationConfig>("api/sinhvienCD15/applicationconfig");
            if (resutl != null)
            {
                ApplicationConfigservices = resutl;
            }
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
