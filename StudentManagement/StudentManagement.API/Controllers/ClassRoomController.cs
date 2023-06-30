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
    public class ClassRoomController : ControllerBase
    {
        private readonly ILogger<ClassRoomController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClassRoomController(ILogger<ClassRoomController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllClassRoom()
        {
            try
            {
                var classRooms = await _unitOfWork.ClassRoom.GetAll();
                return Ok(classRooms);
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when GetAllClassRoom function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetClassroomById(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                var classRoom = await _unitOfWork.ClassRoom.GetData(c => c.ClassroomId == id);
                if (classRoom == null) return NoContent();
                return Ok(classRoom);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when GetClassroomById function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateClassRoom(ClassRoomCreate entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isExist = await _unitOfWork.ClassRoom.IsValueExit(c=>c.ClassRoomName.Equals(entity.ClassRoomName));
                    if(isExist) return BadRequest("Name already exist");
                    var mappedClassRoom = _mapper.Map<ClassRoom>(entity);
                    var classRoom = await _unitOfWork.ClassRoom.Create(mappedClassRoom);
                    return CreatedAtAction("GetClassroomById", new { ClassroomId = classRoom.ClassroomId }, classRoom);
                }
                return BadRequest(ModelState);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when CreateClassRoom function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateClassRoom(ClassRoom entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isExist = await _unitOfWork.ClassRoom.IsValueExit(c => c.ClassRoomName.Equals(entity.ClassRoomName) && c.ClassroomId!=entity.ClassroomId);
                    if (isExist) return BadRequest("Name already exist");

                    var classRoom = await _unitOfWork.ClassRoom.Update(entity);
                    return Ok(classRoom);
                }
                return BadRequest(ModelState);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when UpdateClassRoom function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteClassRoom(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                var deleteClassRoom = await _unitOfWork.ClassRoom.GetData(c => c.ClassroomId == id);
                if (deleteClassRoom == null) return NoContent();
                var result = await _unitOfWork.ClassRoom.Delete(deleteClassRoom);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when UpdateClassRoom function: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }


}
