using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;

namespace BlazorAppQLDT.Client.Services.ExcelService
{
    public class ExcelService : IExcelService
    {
        public readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public ExcelService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<SinhvienModel> Excelservices { get; set; } = new List<SinhvienModel>();
        public List<SinhvienCD18Model> ExcelforCD18services { get; set; } = new List<SinhvienCD18Model>();

        public async Task CreateExcelCD15Detail(SinhvienCD15Model student)
        {
            var result = await _http.PostAsJsonAsync("api/sinhvienCD15", student);
            await SetSinhvienCD18(result);
        }

        public async Task CreateExcelCD18Detail(SinhvienCD18Model student)
        {
            var result = await _http.PostAsJsonAsync("api/sinhvienCD18", student);
            await SetSinhvienCD18(result);
        }

        public async Task CreateExcelDetail(SinhvienModel student)
        {
            var result = await _http.PostAsJsonAsync("api/sinhvien", student);
            await SetSinhvien(result);
        }

        public async Task GetExcelCD18Detail()
        {
            var resutl = await _http.GetFromJsonAsync<List<SinhvienCD18Model>>("api/sinhvienCD18");
            if (resutl != null)
            {
                ExcelforCD18services = resutl;
            }
        }

        public async Task GetExcelDetail()
        {
            var resutl = await _http.GetFromJsonAsync<List<SinhvienModel>>("api/sinhvien");
            if (resutl != null)
            {
                Excelservices = resutl;
            }
        }
        private async Task SetSinhvien(HttpResponseMessage result)
        {
            Console.WriteLine(result.StatusCode);
            _navigationManager.NavigateTo("sinhvien");
        }
        private async Task SetSinhvienCD18(HttpResponseMessage result)
        {
            Console.WriteLine(result.StatusCode);
            _navigationManager.NavigateTo("CD18");
        }
    }
}
