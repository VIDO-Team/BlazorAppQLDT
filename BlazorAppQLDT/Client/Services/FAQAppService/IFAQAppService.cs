namespace BlazorAppQLDT.Client.Services.FAQAppService
{
    public interface IFAQAppService
    {
        List<FAQAppModel> FAQApps { get; set; }

        Task GetFAQApps();
        Task<FAQAppModel> GetSingleFAQ(int id);

        Task CreateFAQ(FAQAppModel faq);
        Task UpdateFAQ(FAQAppModel faq);
        Task DeleteFAQ(int id);
    }
}