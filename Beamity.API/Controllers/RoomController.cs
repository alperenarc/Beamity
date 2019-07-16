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
        public async Task<IActionResult> CreateRoom(CreateRoomDTO room)
        {
            try
            {
              await  _roomService.CreateRoom(room);
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the creating process. Please try again !");
            }
            return Ok("The process is success");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRoom(UpdateRoomDTO room)
        {
            try
            {
                await _roomService.UpdateRoom(room);
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the editing process. Please try again !");
            }
            return Ok("The process is success");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRoom(DeleteRoomDTO room)
        {
            try
            {
                await _roomService.DeleteRoom(room);
            }
            catch (Exception)
            {
                return BadRequest("An error occurred during the deleting process. Please try again !");
            }
            return Ok("The process is success");
        }
        [HttpGet]
        public async Task<ReadRoomDTO> GetRoom(EntityDTO id)
        {
            var room = await _roomService.GetRoom(id);
            return room;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<List<ReadRoomDTO>> GetAllRooms()
        {
            var location = HttpContext.Session.GetString("LocationId");

            EntityDTO dto = new EntityDTO
            {
                Id = Guid.Parse(location)
            };
            return await _roomService.GetAllRooms(dto);
        }
        [HttpPost]
        public async Task<List<ReadRoomDTO>> GetRoomsOnFloor(EntityDTO room)
        {
            return await _roomService.GetRoomsOnFloor(room);
        }
    }
}