using API.Models;

namespace API.Repositories
{
    public interface IStudentAssignmentRepository
    {
        Task AddSubmission(StudentAssignment studentAssignment);
        Task UpdateSubmission(StudentAssignment studentAssignment);
        Task<StudentAssignment> GetSubmissionById(int id);
    }
}
