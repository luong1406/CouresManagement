using API.Models;

namespace API.Repositories
{
    public interface IQuizRepository
    {
        Task AddQuiz(Quiz quiz);
        Task UpdateQuiz(Quiz quiz);
        Task<Quiz> GetQuizById(int id);
        Task<IEnumerable<Quiz>> GetAllQuizzes();
    }
}
