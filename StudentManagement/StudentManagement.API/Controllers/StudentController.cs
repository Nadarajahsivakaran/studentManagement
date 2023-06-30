using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.DataAccess;
using StudentManagement.DataAccess.IRepository;
using StudentManagement.Models;
using StudentManagement.Models.DTO;
using System.Diagnostics.Metrics;

namespace StudentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentController(ILogger<StudentController> logger,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllStudents()
        {
            try
            {
                var students = await _unitOfWork.Student.GetAll("ClassRoom");
                return Ok(students);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when GetAllStudents function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetStudentById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetStudentById(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                var student = await _unitOfWork.Student.GetData(c => c.StudentID == id, "ClassRoom");
                if (student == null) return NoContent();
                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when GetStudentById function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateStudent(StudentCreate entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isExist = await _unitOfWork.Student.IsValueExit(c => c.FirstName.Equals(entity.FirstName));
                    if (isExist) return BadRequest("Name already exist");
                    var mappedStudent = _mapper.Map<Student>(entity);
                    var student = await _unitOfWork.Student.Create(mappedStudent);
                    var createdStudent = await _unitOfWork.Student.GetData(c => c.StudentID == student.StudentID, "ClassRoom");
                    return CreatedAtAction("GetStudentById", new { StudentID = createdStudent.StudentID }, createdStudent);
                }
                return BadRequest(ModelState);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when CreateStudent function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateStudent(StudentUpdate entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isExist = await _unitOfWork.Student.IsValueExit(c => c.FirstName.Equals(entity.FirstName) && c.StudentID != entity.StudentID);
                    if (isExist) return BadRequest("Name already exist");
                    var mappedStudent = _mapper.Map<Student>(entity);
                    var student = await _unitOfWork.Student.Update(mappedStudent);
                    var updatedStudent = await _unitOfWork.Student.GetData(c => c.StudentID == student.StudentID, "ClassRoom");
                    return Ok(updatedStudent);
                }
                return BadRequest(ModelState);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when Updatestudent function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Deletestudent(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                var deletestudent = await _unitOfWork.Student.GetData(c => c.StudentID == id);
                if (deletestudent == null) return NoContent();
                var result = await _unitOfWork.Student.Delete(deletestudent);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when Deletestudent function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("StudentReport/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> StudentReport(int id)
        {
            try
            {
                //var student = await _unitOfWork.Student.GetData(c => c.StudentID == id, "ClassRoom");
                var report = await _unitOfWork.Student.GetReport(id);

                //var studentReport = new StudentReport
                //{
                //    Student = student,
                //    Teacher = report.Teacher
                //};
                //return Ok(studentReport);
                return Ok(report);
    }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when Deletestudent function: {ex.Message}");
                return BadRequest(ex.Message);
}
        }
    }


}
