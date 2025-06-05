using Shared.DTOs;

namespace Shared.Interfaces;

public interface IQuizEvaluationService
{
    Task<StudentQuizResultDto> EvaluateAndSaveAsync(QuizSubmissionDto dto, string studentId);
}
