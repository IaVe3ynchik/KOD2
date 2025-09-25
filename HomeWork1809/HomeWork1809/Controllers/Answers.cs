using Microsoft.AspNetCore.Mvc;

namespace HomeWork1809.Controllers;

public class AnswersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllAnswers() => Ok("Список всех ответов");

    [HttpGet("{id}")]
    public IActionResult GetAnswerById(int id)
    {
        if (id == 1) 
            return Ok("Ответ 1");
        return NotFound();
    }

    [HttpGet("by-test/{testId}/{questionId}")]
    public IActionResult GetAnswersByTestId(int testId, int questionId) => Ok($"Ответы для вопроса {questionId} из теста {testId}");

    [HttpPost]
    public IActionResult CreateAnswer() => Created("/api/answers/1", "Ответ создан");

    [HttpPut("{id}")]
    public IActionResult UpdateAnswer(int id) => NoContent();

    [HttpDelete("{id}")]
    public IActionResult DeleteAnswer(int id) => NoContent();
}