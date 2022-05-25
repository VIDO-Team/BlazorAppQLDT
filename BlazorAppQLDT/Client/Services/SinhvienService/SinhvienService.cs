using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Forms;
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
    }
}
