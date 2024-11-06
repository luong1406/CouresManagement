﻿using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly CMSContext _context;

        public QuizRepository(CMSContext context)
        {
            _context = context;
        }

        public async Task AddQuiz(Quiz quiz)
        {
            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateQuiz(Quiz quiz)
        {
            _context.Quizzes.Update(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task<Quiz> GetQuizById(int id)
        {
            return await _context.Quizzes.Include(q => q.Course).Include(q => q.Questions).Include(q => q.QuizAttendances).ThenInclude(q => q.Student).FirstOrDefaultAsync(q => q.QuizId == id);
        }

        public async Task<IEnumerable<Quiz>> GetAllQuizzes()
        {
            return _context.Quizzes.AsQueryable();
        }
    }
}
