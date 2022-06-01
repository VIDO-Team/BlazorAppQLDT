using Microsoft.AspNetCore.Components;

namespace BlazorAppQLDT.Client.Services.FAQAppService
{
    public class FAQAppService : IFAQAppService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public List<FAQAppModel> FAQApp { get; set; } = new List<FAQAppModel>();
        public List<QuestionModel> FQADetails { get; set; } = new List<QuestionModel>();
        public List<AnswersModel> FQA { get; set; } = new List<AnswersModel>();

        public FAQAppService(HttpClient http , NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public async Task GetFAQApps()
        {
            var result = await _http.GetFromJsonAsync<List<FAQAppModel>>("api/faqapp");
            if(result != null)
            {
                FAQApp = result;
            }
        }

        public async Task GetQuestions()
        {
            var result = await _http.GetFromJsonAsync<List<QuestionModel>>("api/question");
            if(result != null)
            {
                FQADetails = result;
            }
        }

        public async Task GetAnswers()
        {
            var result = await _http.GetFromJsonAsync<List<AnswersModel>>("api/question/answers");
            if (result != null)
            {
                FQA = result;
            }
        }

        public async Task GetQuestionByFAQId(int id)
        {
            var result = await _http.GetFromJsonAsync<List<QuestionModel>>($"api/question/questionsbyfaqid/{id}");
            if (result != null)
            {
                FQADetails = result;
            }
        }

        public async Task<QuestionModel> GetSingleQuestion(int id)
        {
            var result = await _http.GetFromJsonAsync<QuestionModel>($"api/question/{id}");
            //Console.WriteLine(result.ToString());
            if (result != null)
                return result;
            throw new Exception("Error not found.");
        }

        public async Task<FAQAppModel> GetSingleFAQ(int id)
        {
            var result = await _http.GetFromJsonAsync<FAQAppModel>($"api/faqapp/{id}");
            //Console.WriteLine(result.ToString());
            if (result != null)
                return result;
            throw new Exception("Error not found.");
        }

        public async Task<AnswersModel> GetSingleAnswers(int id)
        {
            var result = await _http.GetFromJsonAsync<AnswersModel>($"api/question/answers/{id}");
            //Console.WriteLine(result.ToString());
            if (result != null)
                return result;
            throw new Exception("Error not found.");
        }

        public async Task  UpdateFAQ(FAQAppModel faq)
        {
            var result = await _http.PutAsJsonAsync($"api/faqapp/{faq.QuestionId}", faq);
            //var response = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            await SetFAQs(result);
        }

        public async Task  UpdateQuestion(QuestionModel question)
        {
            var result = await _http.PutAsJsonAsync($"api/question/{question.Id}", question);
            //var response = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            await SetFAQs(result);
        }

        public async Task CreateFAQ(FAQAppModel faq)
        {
            var result = await _http.PostAsJsonAsync("api/faqapp", faq);
            await SetFAQs(result);
        }

        public async Task CreateFQA(QuestionModel question)
        {
            var result = await _http.PostAsJsonAsync("api/question/createfqa", question);
            await SetFAQs(result);
        }

        public async Task AddQuestion(QuestionModel question)
        {
            var result = await _http.PostAsJsonAsync($"api/question/{question.FQAId}", question);
            await SetFAQs(result);
        }

        private async Task SetFAQs(HttpResponseMessage result)
        {
            //var response = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            //Heroes = response;
            _navigationManager.NavigateTo("faqapps");
        }

        public async Task DeleteFAQ(int id)
        {
            var result = await _http.DeleteAsync($"api/faqapp/{id}");
            await SetFAQs(result);
        }

        public async Task DeleteQuestion(int id)
        {
            var result = await _http.DeleteAsync($"api/question/{id}");
            await SetFAQs(result);
        }

    }
}