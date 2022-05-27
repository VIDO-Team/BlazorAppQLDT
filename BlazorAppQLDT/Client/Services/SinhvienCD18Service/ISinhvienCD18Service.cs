namespace BlazorAppQLDT.Client.Services.SinhvienCD18Service
{
    public interface ISinhvienCD18Service
    {
        List<SinhvienCD18Model> Sinhvienservices { get; set; }
        ApplicationConfig ApplicationConfigservices { get; set; }
        Task GetSinhvienDetail();
        Task CreateSinhvien(SinhvienCD18Model student);
        Task UpdateSinhvien(SinhvienCD18Model student);
        Task DeleteSinhvien(int id);
        Task SearchSinhvien(string name);
        Task<SinhvienCD18Model> GetSingleSinhvien(int id);
        Task<string> SendZNS(string payload);
        Task GetApplicationConfig();
    }
}
