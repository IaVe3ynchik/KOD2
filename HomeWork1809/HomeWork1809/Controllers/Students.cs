using Microsoft.AspNetCore.Mvc;

namespace HomeWork1809.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllStudents() => Ok("Список студентов");


    [HttpGet("{id:int}")]
    public IActionResult GetStudentById(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Некорректный id");
        }
        
        if (id == 1)
        {
            return Ok("Студент 1");
        }

        return NotFound();
    }


    [HttpPost]
    public IActionResult CreateStudent()
    {
        return Created("/api/students/1", "Создан студент с id=1");
    }


    [HttpPut("{id:int}")]
    public IActionResult UpdateStudent(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Некорректный id");
        }

        if (id != 1)
        {
            return NotFound();
        }

        return NoContent();
    }


    [HttpDelete("{id:int}")]
    public IActionResult DeleteStudent(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Некорректный id");
        }

        if (id != 1)
        {
            return NotFound();
        }

        return NoContent();
    }
}