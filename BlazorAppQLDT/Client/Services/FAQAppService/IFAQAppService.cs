namespace BlazorAppQLDT.Client.Services.FAQAppService
{
    public interface IFAQAppService
    {
        List<FAQApp> FAQApps { get; set; }

        Task GetFAQApps();
    }
}