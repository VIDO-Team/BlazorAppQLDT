namespace BlazorAppQLDT.Client.Services.ExcelService
{
    public interface IExcelService
    {
        List<SinhvienModel> Excelservices { get; set; }
        Task CreateExcelDetail(SinhvienModel student);
        Task GetExcelDetail();
        Task CreateExcelCD18Detail(SinhvienCD18Model student);
        Task GetExcelCD18Detail();
    }
}
