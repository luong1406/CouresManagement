using API.Models;

namespace API.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCourses();
        Task AddCourse(Course course);
        Task<Course> GetCourseById(int id);
        Task UpdateCourse(Course course);
        Task EnrollCourse(int courseId, int studentId);
        Task UnenrollCourse(int courseId, int studentId);
        Task<IEnumerable<CourseEnrollment>> GetAllEnrollments();
    }
}
