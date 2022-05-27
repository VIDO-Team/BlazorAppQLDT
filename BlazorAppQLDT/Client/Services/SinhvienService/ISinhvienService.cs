using Microsoft.AspNetCore.Components.Forms;

namespace BlazorAppQLDT.Client.Services.SinhvienService
{
    public interface ISinhvienService
    {
        List<SinhvienModel> Sinhvienservices { get; set; }
        Task GetSinhvienDetail();
        Task CreateSinhvien(SinhvienModel student);
        Task UpdateSinhvien(SinhvienModel student);
        Task SearchSinhvien(string name);
        Task DeleteSinhvien(int id);
        Task<SinhvienModel> GetSingleSinhvien(int id);
        Task<string> SendZNS(string payload);
        Task GetApplicationConfig();
    }
}
