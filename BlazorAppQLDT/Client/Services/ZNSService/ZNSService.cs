using System.Data.SqlClient;
using BlazorAppQLDT.
namespace BlazorAppQLDT.Client.Services.ZNSService
{
    public class ZNSService : IZNSService
    {
        public ApplicationConfig GetApplicationConfig()
        {
            var resutl = _context.ApplicationConfigs.FirstOrDefault(a => a.Id >= 1);
            if (resutl.LastUpdatedDateTime.AddMinutes(-50) > DateTime.Now)
            {
                return null;
            }
            return Ok(resutl);
        }
    }
}
