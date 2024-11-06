﻿using API.Models;

namespace API.Repositories
{
    public class QuizAttendanceRepository : IQuizAttendanceRepository
    {
        private readonly CMSContext _context;

        public QuizAttendanceRepository(CMSContext context)
        {
            _context = context;
        }

        public async Task AddQuizResult(QuizAttendance quizAttendance)
        {
            _context.QuizAttendances.Add(quizAttendance);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAttempt(QuizAttendance quizAttendance)
        {
            _context.QuizAttendances.Remove(quizAttendance);
            await _context.SaveChangesAsync();
        }

        public async Task<QuizAttendance> GetAttempt(int studentId, int quizId)
        {
            return _context.QuizAttendances.FirstOrDefault(qa => qa.StudentId == studentId && qa.QuizId == quizId);
        }
    }
}
