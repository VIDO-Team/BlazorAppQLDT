namespace BlazorAppQLDT.Server.Paging
{
    public class SinhvienPaging : ISinhvienPaging
    {
        private readonly DataContext _context;
        public async Task<PagedList<SinhvienCD15Model>> GetProducts(SinhvienParameter sinhvienParameters)
        {
            var products = await _context.DataCD15.ToListAsync();
            return PagedList<SinhvienCD15Model>
                .ToPagedList(products, sinhvienParameters.PageNumber, sinhvienParameters.PageSize);
        }
    }
}
