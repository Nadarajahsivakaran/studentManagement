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
    public class AllocateClassRoomController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AllocateClassRoomController> _logger;

        public AllocateClassRoomController(IUnitOfWork unitOfWork, ILogger<AllocateClassRoomController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AllocateClassRoomToTeacher(AllocateClassroomCreate entity)
        {
            try
            {
                foreach (var item in entity.ClassRooms)
                {
                    var mappedAllocateClassRoom = new AllocateClassRoom
                    {
                        TeacherId = entity.TeacherId,
                        ClassRoomId = item.ClassRoomId,
                    };
                     await _unitOfWork.AllocateClassRoom.Create(mappedAllocateClassRoom);
                }
                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when AllocateClassRoomToTeacher function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("TeacherId:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetTeacherClassRoom(int TeacherId)
        {
            try
            {
                var teacherClassroom = await _unitOfWork.AllocateClassRoom.TeacherClassRoom(TeacherId);
                return Ok(teacherClassroom);    

            }catch(Exception ex)
            {
                _logger.LogError($"An error occurred when GetTeacherClassRoom function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateTeacherClassRoom(AllocateClassroomCreate entity)
        {
            try
            {
                var getAllRecords = await _unitOfWork.AllocateClassRoom.GetTeacherAllRecords(entity.TeacherId);
                var isRemovedOldEntry = await _unitOfWork.AllocateClassRoom.RemoveDatas(getAllRecords);
                await AllocateClassRoomToTeacher(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when UpdateTeacherClassRoom function: {ex.Message}");
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("teacherId:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteTeacherClassRoom(int teacherId)
        {
            try
            {
                var getAllRecords = await _unitOfWork.AllocateClassRoom.GetTeacherAllRecords(teacherId);
                var isRemovedOldEntry = await _unitOfWork.AllocateClassRoom.RemoveDatas(getAllRecords);
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when DeleteTeacherClassRoom function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
