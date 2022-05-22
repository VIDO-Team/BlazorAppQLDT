namespace BlazorAppQLDT.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        public DbSet<SinhvienModel> Sinhviens { get; set; }
    }
}
