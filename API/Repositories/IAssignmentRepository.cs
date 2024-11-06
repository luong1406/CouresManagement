using API.Models;

namespace API.Repositories
{
    public interface IAssignmentRepository
    {
        Task CreateAssignment(Assignment assignment);
        Task<Assignment> GetAssignmentById(int id);
        Task UpdateAssignment(Assignment assignment);
    }
}
