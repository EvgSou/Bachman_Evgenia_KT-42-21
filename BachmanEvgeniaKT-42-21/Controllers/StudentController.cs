using BachmanEvgeniaKT_42_21.Database;
using BachmanEvgeniaKT_42_21.Models;
using BachmanEvgeniaKT_42_21.Interfaces.StudentsInterfaces;
using BachmanEvgeniaKT_42_21.Filters.StudentFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BachmanEvgeniaKT_42_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;
        private StudentDbContext _context;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService, StudentDbContext context)
        {
            _logger = logger;
            _studentService = studentService;
            _context = context;
        }


        [HttpPost(Name = "GetStudentsByGroup")]
        public async Task<IActionResult> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByGroupAsync(filter, cancellationToken);

            return Ok(students);
        }

        [HttpPost("GetStudentsByFIO")]
        public async Task<IActionResult> GetStudentsByFIOAsync(StudentFIOFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByFIOAsync(filter, cancellationToken);
            return Ok(students);
        }

        [HttpPost("GetStudentsByFIOAll")]
        public async Task<IActionResult> GetStudentsByFIOAllAsync(StudentFIOAllFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByFIOAllAsync(filter, cancellationToken);
            return Ok(students);
        }

        [HttpPost("GetStudentsByDeletionStatus")]
        public async Task<IActionResult> GetStudentsByDeletionStatusAsync(StudentDeletionStatusFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByDeletionStatusAsync(filter, cancellationToken);
            return Ok(students);
        }

        [HttpPost("AddNewStudent")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            //проверка на корректность ввода
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Students.Add(student); //добавление в коллекцию
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpPost("EditStudent")]
        public IActionResult EditStudent(int studentid, [FromBody] Student editedStudent)
        {
            var inBaseStudent = _context.Students.FirstOrDefault(w => w.StudentId == studentid); //поиск студента по ид в бд
            if (inBaseStudent == null)
            {
                return NotFound(); 
            }
            //изменение данных о студенте
            inBaseStudent.FirstName = editedStudent.FirstName;
            inBaseStudent.LastName = editedStudent.LastName; 
            inBaseStudent.MiddleName = editedStudent.MiddleName;
            inBaseStudent.GroupId = editedStudent.GroupId;
            inBaseStudent.DeletionStatus = editedStudent.DeletionStatus;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteStudent(int studentid, [FromBody] Student editedStudent)
        {
            var inBaseStudent = _context.Students.FirstOrDefault(g => g.StudentId == studentid); //поиск студента по ид в бд
            if (inBaseStudent == null)
            {
                return NotFound();
            }
            //удаление данных о студенте
            _context.Students.Remove(inBaseStudent);
            _context.SaveChanges();
            return Ok();
        }
    }
}
