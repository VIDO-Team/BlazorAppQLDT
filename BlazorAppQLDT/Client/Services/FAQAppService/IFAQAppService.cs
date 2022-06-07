namespace BlazorAppQLDT.Client.Services.FAQAppService
{
    public interface IFAQAppService
    {
        List<FAQAppModel> FAQApp { get; set; }
        List<QuestionModel> FQADetails {get; set;}
        List<AnswersModel> FQA { get; set; }

        Task GetFAQApps();
        Task GetQuestions();
        Task GetAnswers();
        Task GetQuestionByFAQId(int id);
        Task<FAQAppModel> GetSingleFAQ(int id);
        Task<QuestionModel> GetSingleQuestion(int id);
        Task<AnswersModel> GetSingleAnswers(int id);

        Task CreateFAQ(FAQAppModel faq);
        Task UpdateFAQ(FAQAppModel faq);
        Task DeleteFAQ(int id);
        Task AddQuestion(QuestionModel question);
        Task CreateFQA(QuestionModel question);
        Task UpdateQuestion(QuestionModel question);
        Task DeleteQuestion(int id);
        // Task SearchQuestion(string text);
        Task<List<QuestionModel>> SearchQuestion(string searchText);
        
    }
}