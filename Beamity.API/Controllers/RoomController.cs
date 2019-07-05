using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.RoomDTOs;
using Beamity.Application.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpPost]
        public IActionResult CreateRoom(CreateRoomDTO room)
        {
            try
            {
                _roomService.CreateRoom(room);
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the creating process. Please try again !");
            }
            return Ok("The process is success");
        }
        [HttpPut]
        public IActionResult UpdateRoom(UpdateRoomDTO room)
        {
            try
            {
                _roomService.UpdateRoom(room);
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the editing process. Please try again !");
            }
            return Ok("The process is success");
        }
        [HttpDelete]
        public IActionResult DeleteRoom(DeleteRoomDTO room)
        {
            try
            {
                _roomService.DeleteRoom(room);
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the deleting process. Please try again !");
            }
            return Ok("The process is success");
        }
        [HttpGet]
        public ReadRoomDTO GetRoom(EntityDTO id)
        {
            var room = _roomService.GetRoom(id);
            return room;
        }
        [HttpGet]
        [AllowAnonymous]
        public List<ReadRoomDTO> GetAllRooms()
        {
            return _roomService.GetAllRooms();
        }
        [HttpGet("{id}")]
        public async Task<List<ReadRoomDTO>> GetRoomsOnFloor(EntityDTO room)
        {
            return await _roomService.GetRoomsOnFloor(room);
        }
    }
}