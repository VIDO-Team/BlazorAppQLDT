using Microsoft.AspNetCore.Components;
namespace BlazorAppQLDT.Client.Services.SinhvienCD15Service
{
    public class SinhvienCD15Service : ISinhvienCD15Service
    {
        public readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public List<SinhvienCD15Model> Sinhvienservices { get; set; } = new List<SinhvienCD15Model>();
        
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
    }
}
