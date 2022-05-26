namespace BlazorAppQLDT.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        public DbSet<SinhvienModel> Sinhviens { get; set; }
        public DbSet<SinhvienCD18Model> SinhvienCD18 { get; set; }
        public DbSet<SinhvienCD15Model> DataCD15 { get; set; }
    }
}
