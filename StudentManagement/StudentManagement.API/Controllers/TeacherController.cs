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
    public class TeacherController : ControllerBase
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeacherController(ILogger<TeacherController> logger,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllTeacher()
        {
            try
            {
                var teachers = await _unitOfWork.Teacher.GetAll();
                return Ok(teachers);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when GetAllTeacher function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetTeacherById(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                var teacher = await _unitOfWork.Teacher.GetData(c => c.TeacherId == id);
                if (teacher == null) return NoContent();
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when GetTeacherById function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTeacher(TeacherCreate entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isExist = await _unitOfWork.Teacher.IsValueExit(c => c.FirstName.Equals(entity.FirstName));
                    if (isExist) return BadRequest("Name already exist");
                    var mappedTeacher = _mapper.Map<Teacher>(entity);
                    var teacher = await _unitOfWork.Teacher.Create(mappedTeacher);
                    var createdTeacher = await _unitOfWork.Teacher.GetData(c => c.TeacherId == teacher.TeacherId);
                    return CreatedAtAction("GetTeacherById", new { TeacherId = createdTeacher.TeacherId }, createdTeacher);
                }
                return BadRequest(ModelState);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when CreateTeacher function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateTeacher(Teacher entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isExist = await _unitOfWork.Teacher.IsValueExit(c => c.FirstName.Equals(entity.FirstName) && c.TeacherId != entity.TeacherId);
                    if (isExist) return BadRequest("Name already exist");
                    var teacher = await _unitOfWork.Teacher.Update(entity);
                    var updatedTeacher = await _unitOfWork.Teacher.GetData(c => c.TeacherId == teacher.TeacherId);
                    return Ok(updatedTeacher);
                }
                return BadRequest(ModelState);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when UpdateTeacher function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteTeacher(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                var deleteTeacher = await _unitOfWork.Teacher.GetData(c => c.TeacherId == id);
                if (deleteTeacher == null) return NoContent();
                var result = await _unitOfWork.Teacher.Delete(deleteTeacher);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when DeleteTeacher function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }


}
