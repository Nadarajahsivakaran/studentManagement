using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.DataAccess;
using StudentManagement.DataAccess.IRepository;
using StudentManagement.Models;
using StudentManagement.Models.DTO;

namespace StudentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocateSubjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AllocateSubjectController> _logger;

        public AllocateSubjectController(IUnitOfWork unitOfWork, ILogger<AllocateSubjectController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AllocateSubjectToTeacher(AllocateSubjectCreate entity)
        {
            try
            {
                foreach (var item in entity.Subjects)
                {
                    var mappedAllocateSubject = new AllocateSubject
                    {
                        TeacherId = entity.TeacherId,
                        SubjectId = item.SubjectId,
                    };
                     await _unitOfWork.AllocateSubject.Create(mappedAllocateSubject);
                }
                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when GetAllClassRoom function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetTeachersSubjects(int id)
        {
            try
            {
                var teacherSubject = await _unitOfWork.AllocateSubject.TeacherSubject(id);
                return Ok(teacherSubject);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when GetTeachersSubjects function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateTeacherSubject(AllocateSubjectCreate entity)
        {
            try
            {
                var getAllRecords = await _unitOfWork.AllocateSubject.GetTeacherAllRecords(entity.TeacherId);
                var isRemovedOldEntry =await _unitOfWork.AllocateSubject.RemoveDatas(getAllRecords);
                await AllocateSubjectToTeacher(entity);
                return Ok(entity);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when UpdateTeacherSubject function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("teacherId:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteTeacherSubject(int teacherId)
        {
            try
            {
                var getAllRecords = await _unitOfWork.AllocateSubject.GetTeacherAllRecords(teacherId);
                var isRemovedOldEntry = await _unitOfWork.AllocateSubject.RemoveDatas(getAllRecords);
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when UpdateTeacherSubject function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }


    }
}
