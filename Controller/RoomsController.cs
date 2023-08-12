using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInnManagementSystem.Data;
using AsyncInnManagementSystem.Models;
using AsyncInnManagementSystem.Models.Interfaces;
using AsyncInnManagementSystem.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AsyncInnManagementSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomsController(IRoom Room)
        {
            _room = Room;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRooms()
        {
          return await _room.GetAllRooms();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            var room =await _room.GetRoomById(id);
            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "District Manager")]

        public async Task<IActionResult> PutRoom(int id, RoomDTO room)
        {
            if (id != room.ID)
            {
                return BadRequest();
            }

           var UpdatedRoom = await _room.UpdateRooms(id, room);
            return Ok(UpdatedRoom);
           
        }

        [Authorize(Roles = "District Manager")]
        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomDTO>> PostRoom(RoomDTO roomDTO)
        {
       await  _room.Create(roomDTO);

            return CreatedAtAction("GetRoom", new { id = roomDTO.ID }, roomDTO);
        }
        [Authorize(Roles = "District Manager")]

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
           await _room.DeleteRoom(id);

            return NoContent();
        }
        [Authorize(Roles = "District Manager, Property Manager")]

        // POST: api/Rooms/{roomId}/Amenity/{amenityId}
        [HttpPost("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId)
        {
            await _room.AddAmenityToRoom(roomId, amenityId);
            return NoContent();
        }
        [Authorize(Roles = "District Manager, Property Manager")]

        // DELETE: api/Rooms/{roomId}/Amenity/{amenityId}
        [HttpDelete("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            await _room.RemoveAmenityFromRoom(roomId, amenityId);
            return NoContent();
        }

    }
}
