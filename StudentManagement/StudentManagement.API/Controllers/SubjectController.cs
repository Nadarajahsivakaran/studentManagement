using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.DataAccess;
using StudentManagement.DataAccess.IRepository;
using StudentManagement.Models;
using StudentManagement.Models.DTO;

namespace StudentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ILogger<SubjectController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubjectController(ILogger<SubjectController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllSubject()
        {
            try
            {
                var subjects = await _unitOfWork.Subject.GetAll();
                return Ok(subjects);
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when GetAllSubject function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetSubjectById(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                var subject = await _unitOfWork.Subject.GetData(c => c.SubjectId == id);
                if (subject == null) return NoContent();
                return Ok(subject);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when GetSubjectById function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateSubject(SubjectCreate entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isExist = await _unitOfWork.Subject.IsValueExit(c=>c.SubjectName.Equals(entity.SubjectName));
                    if(isExist) return BadRequest("Name already exist");
                    var mappedSubject = _mapper.Map<Subject>(entity);
                    var subject = await _unitOfWork.Subject.Create(mappedSubject);
                    return CreatedAtAction("GetSubjectById", new { SubjectId = subject.SubjectId }, subject);
                }
                return BadRequest(ModelState);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when CreateSubject function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateSubject(Subject entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isExist = await _unitOfWork.Subject.IsValueExit(c => c.SubjectName.Equals(entity.SubjectName) && c.SubjectId!=entity.SubjectId);
                    if (isExist) return BadRequest("Name already exist");

                    var subject = await _unitOfWork.Subject.Update(entity);
                    return Ok(subject);
                }
                return BadRequest(ModelState);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when UpdateSubject function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteSubject(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                var deleteSubject = await _unitOfWork.Subject.GetData(c => c.SubjectId == id);
                if (deleteSubject == null) return NoContent();
                var result = await _unitOfWork.Subject.Delete(deleteSubject);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when DeleteSubject function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }


}
