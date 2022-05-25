using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Forms;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace BlazorAppQLDT.Client.Services.SinhvienCD18Service
{
    public class SinhvienCD18Service : ISinhvienCD18Service
    {
        public readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public List<SinhvienCD18Model> Sinhvienservices { get; set; } = new List<SinhvienCD18Model>();
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
    }
}
