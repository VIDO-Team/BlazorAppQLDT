namespace BlazorAppQLDT.Client.Services.SinhvienCD18Service
{
    public interface ISinhvienCD18Service
    {
        List<SinhvienCD18Model> Sinhvienservices { get; set; }
        Task GetSinhvienDetail();
        Task CreateSinhvien(SinhvienCD18Model student);
        Task UpdateSinhvien(SinhvienCD18Model student);
        Task DeleteSinhvien(int id);
        Task<SinhvienCD18Model> GetSingleSinhvien(int id);
    }
}
