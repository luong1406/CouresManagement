using API.Models;

namespace API.Repositories
{
    public interface IQuizAttendanceRepository
    {
        Task AddQuizResult(QuizAttendance quizAttendance);
        Task<QuizAttendance> GetAttempt(int studentId, int quizId);
        Task DeleteAttempt(QuizAttendance quizAttendance);
    }
}
