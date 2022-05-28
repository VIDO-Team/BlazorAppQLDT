
namespace BlazorAppQLDT.Client.Services.SinhvienCD15Services
{
    public interface ISinhvienCD15Service
    {
        List<SinhvienCD15Model> Sinhvienservices { get; set; }
        ApplicationConfig ApplicationConfigservices { get; set; }
        Task GetSinhvienDetail();
        Task CreateSinhvien(SinhvienCD15Model student);
        Task UpdateSinhvien(SinhvienCD15Model student);
        Task SearchSinhvien(string name);
        Task DeleteSinhvien(int id);
        Task<SinhvienCD15Model> GetSingleSinhvien(int id);
        Task<string> SendZNS(string payload);
        Task buildZNS();
        Task GetApplicationConfig();
        
    }
}
