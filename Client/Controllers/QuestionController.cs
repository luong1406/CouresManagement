﻿using Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class QuestionController : Controller
    {
        private readonly string link = "http://localhost:5091/api/";
        HttpClient _client;

        public QuestionController()
        {
            _client = new HttpClient();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Question dto)
        {
            var question = new Question()
            {
                QuizId = dto.QuizId,
                Question1 = dto.Question1,
                OptionA = dto.OptionA,
                OptionB = dto.OptionB,
                OptionC = dto.OptionC,
                OptionD = dto.OptionD,
                CorrectOption = dto.CorrectOption
            };
            HttpResponseMessage response = await _client.PostAsJsonAsync(link + "Question", question);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Detail", "Quiz", new { id = question.QuizId });
            }
            return RedirectToAction("Detail", "Quiz", new { id = question.QuizId });
        }

        [HttpPost]
        public async Task<IActionResult> Update(Question dto)
        {
            var question = new Question()
            {
                QuestionId = dto.QuestionId,
                QuizId = dto.QuizId,
                Question1 = dto.Question1,
                OptionA = dto.OptionA,
                OptionB = dto.OptionB,
                OptionC = dto.OptionC,
                OptionD = dto.OptionD,
                CorrectOption = dto.CorrectOption
            };
            HttpResponseMessage response = await _client.PutAsJsonAsync(link + "Question/" + dto.QuestionId, question);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Detail", "Quiz", new { id = question.QuizId });
            }
            return RedirectToAction("Detail", "Quiz", new { id = question.QuizId });
        }

        public async Task<IActionResult> Delete(int id, int quizId)
        {
            HttpResponseMessage response = await _client.DeleteAsync(link + "Question/" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Detail", "Quiz", new { id = quizId });
            }
            return RedirectToAction("Detail", "Quiz", new { id = quizId });
        }
    }
}
