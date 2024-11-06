using API.Models;

namespace API.Repositories
{
    public interface IQuestionRepository
    {
        Task AddQuestion(Question question);
        Task UpdateQuestion(Question question);
        Task<Question> GetQuestionById(int id);
        Task<IEnumerable<Question>> GetAllQuestions();
    }
}
