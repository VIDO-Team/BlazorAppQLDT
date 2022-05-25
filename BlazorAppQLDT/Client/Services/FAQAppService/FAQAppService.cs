using Microsoft.AspNetCore.Components;

namespace BlazorAppQLDT.Client.Services.FAQAppService
{
    public class FAQAppService : IFAQAppService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public List<FAQApp> FAQApps { get; set; } = new List<FAQApp>();
        public FAQAppService(HttpClient http , NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public async Task GetFAQApps()
        {
            var result = await _http.GetFromJsonAsync<List<FAQApp>>("api/faqapp");
            if(result != null)
            {
                FAQApps = result;
            }
        }
    }
}