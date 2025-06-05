using Core.Entities;
using Core.Interfaces;
using Shared.DTOs;
using Shared.Interfaces;

namespace Infrastructure.Services;

public class QuizEvaluationService(IUnitOfWork unit) : IQuizEvaluationService
{
    public async Task<StudentQuizResultDto> EvaluateAndSaveAsync(QuizSubmissionDto dto, string studentId)
    {
        var questionIds = dto.Answers.Select(a => a.QuestionId).ToList();

        var questions = await unit.Repository<Question>()
            .ListAsync(q => questionIds.Contains(q.Id));

        int total = questions.Count;
        int correct = 0;

        foreach (var answer in dto.Answers)
        {
            var question = questions.FirstOrDefault(q => q.Id == answer.QuestionId);
            if (question != null && question.CorrectAnswer.Trim().ToLower() == answer.SelectedAnswer.Trim()
                .ToLower())
            {
                correct++;
            }

            double scorePercent = total > 0 ? (double)correct / total * 100 : 0;

            var studentQuiz = new StudentQuiz
            {
                StudentId = studentId,
                TotalQuestions = total,
                CorrectAnswers = correct,
                ScorePercentage = scorePercent,
                DateTaken = DateTime.UtcNow
            };

            foreach (var answer in dto.Answers)
            {
                var studentAnswer = new StudentAnswer
                {
                    QuestionId = answer.QuestionId,
                    AnswerGiven = answer.Answer,
                    IsCorrect = questions.Any(q => q.Id == answer.QuestionId && q.CorrectAnswer.Trim()
                        .ToLower() == answer.Answer.Trim().ToLower())
                };
                studentQuiz.StundentAnswers.Add(studentAnswer);
            }

            unit.Repository<StudentQuiz>().Add(studentQuiz);

            await unit.Complete();

            return new StudentQuizResultDto
            {
                QuizId = studentQuiz.Id,
                studentId = studentQuiz.StudentId,
                TotalQuestions = studentQuiz.TotalQuestions,
                CorrectAnswer = studentQuiz.CorrectAnswers,
                ScorePercentage = studentQuiz.ScorePercentage
            };
        }
    }
}
