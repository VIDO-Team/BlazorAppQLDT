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
        public async Task CreateExcelDetail(SinhvienModel student)
        {
            Console.WriteLine("1");
            var result = await _http.PostAsJsonAsync("api/sinhvien", student);
            Console.WriteLine("2");
            await SetSinhvien(result);
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
    }
}
