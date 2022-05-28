namespace BlazorAppQLDT.Server.Paging
{
    public interface ISinhvienPaging
    {
        Task<PagedList<SinhvienCD15Model>> GetProducts(SinhvienParameter sinhvienParameters);
    }
}
